using AutoMapper;
using LeaveManagmentSystem.Data;
using LeaveManagmentSystem.Data.Entities;
using LeaveManagmentSystem.Data.Enums;
using LeaveManagmentSystem.Application.Models.LeaveAllocations;
using LeaveManagmentSystem.Application.Models.LeaveRequests;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace LeaveManagmentSystem.Application.Services.LeaveRequests;

public class LeaveRequestService(IMapper _mapper,UserManager<ApplicationUser> _userManager,
   IHttpContextAccessor _httpContextAccessor,ApplicationDbContext _context ) : ILeaveRequestService
{
    public async Task<EmployeeLeaveRequestListVM> AdminGetAllLeaveRequests()
    {
        var leaveRequests = await _context.LeaveRequests
            .Include(l => l.LeaveType)
            .ToListAsync();
        var leaveRequestReadOnly = leaveRequests.Select(l => new LeaveRequestReadOnlyVM
        {
            Id = l.Id,
            StartDate = l.StartDate,
            EndDate = l.EndDate,
            LeaveRequestStatus = (LeaveRequestStatusEnum)l.LeaveRequestStatusId,
            LeaveType=l.LeaveType.Name,
            NumberOfDays=l.EndDate.DayNumber - l.StartDate.DayNumber,
        }).ToList();
        var employeeLeaveRequests = new EmployeeLeaveRequestListVM
        {
            ApprovedRequests=leaveRequests.Count(l=>l.LeaveRequestStatusId==(int)LeaveRequestStatusEnum.Approved),
            PendingRequests= leaveRequests.Count(l => l.LeaveRequestStatusId == (int)LeaveRequestStatusEnum.Pending),
            DeclinedRequests= leaveRequests.Count(l => l.LeaveRequestStatusId == (int)LeaveRequestStatusEnum.Declined),
            TotalRequests= leaveRequests.Count,
            LeaveRequests= leaveRequestReadOnly
        };

        return employeeLeaveRequests;
    }

    public async Task CancelLeaveRequest(int leaveRequestId)
    {
        var leaveRequest= await _context.LeaveRequests.FindAsync(leaveRequestId);
        leaveRequest.LeaveRequestStatusId = (int)LeaveRequestStatusEnum.Cancelled;
        await _context.SaveChangesAsync();
    }

    public async Task CreateLeaveRequest(LeaveRequestCreateVM model)
    {
        //mapping the model
        var leaveRequest = _mapper.Map<LeaveRequest>(model);

        //GET Logged in user
        var user = await GetLoggeedUserAsync();
        leaveRequest.EmployeeId = user.Id;

        //set leaveRequestStatusId
        leaveRequest.LeaveRequestStatusId=(int)LeaveRequestStatusEnum.Pending;

        //add to database
        _context.Add(leaveRequest);

        //deduct allocation based on the request
        // I don't think it's logical to deduct here the related allocation
        //var numberofDays = model.EndDate.DayNumber - model.StartDate.DayNumber;
        //var allocation = await _context
        //    .LeaveAllocations
        //    .FirstOrDefaultAsync(l => l.LeaveTypeId == model.LeaveTypeId
        //                        && l.EmployeeId == leaveRequest.EmployeeId);
        //allocation.Days-=numberofDays;

        await _context.SaveChangesAsync();
    }
   

    public async Task<List<LeaveRequestReadOnlyVM>> GetEmployeeLeaveRequests()
    {
        var user = await GetLoggeedUserAsync();
        var leaveRequests = await _context.LeaveRequests
            .Include(l=>l.LeaveType)
            .Where(l=>l.EmployeeId==user.Id).ToListAsync();
        return [.. leaveRequests.Select(l => new LeaveRequestReadOnlyVM
        {
            Id = l.Id,
            StartDate = l.StartDate,
            EndDate = l.EndDate,
            NumberOfDays = l.EndDate.DayNumber - l.StartDate.DayNumber,
            LeaveType = l.LeaveType.Name,
            LeaveRequestStatus=(LeaveRequestStatusEnum)l.LeaveRequestStatusId,
        })];
    }

    public async Task<ReviewLeaveRequestVM> GetLeaveRequestForReview(int id)
    {
        var leaveRequest= await _context
            .LeaveRequests
            .Include(l=>l.LeaveType)
            .FirstAsync(l=>l.Id==id);
        var user= await _userManager.FindByIdAsync(leaveRequest.EmployeeId);
        var model = new ReviewLeaveRequestVM
        {
            Id = leaveRequest.Id,
            StartDate = leaveRequest.StartDate,
            EndDate = leaveRequest.EndDate,
            LeaveRequestStatus = (LeaveRequestStatusEnum)leaveRequest.LeaveRequestStatusId,
            LeaveType = leaveRequest.LeaveType.Name,
            NumberOfDays = leaveRequest.EndDate.DayNumber - leaveRequest.StartDate.DayNumber,
            RequestComments = leaveRequest.RequestComments,
            Employee= new EmployeeListVM
            {
                Id = leaveRequest.EmployeeId,
                FirstName=user.FirstName,
                LastName=user.LastName,
                Email=user.Email, 
            }
        };
        return model;
    }

    public async Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model)
    {
        var user = await GetLoggeedUserAsync();
        var allocation = await _context
           .LeaveAllocations
           .FirstOrDefaultAsync(l => l.LeaveTypeId == model.LeaveTypeId
                               && l.EmployeeId == user.Id);
        return allocation.Days < (model.EndDate.DayNumber-model.StartDate.DayNumber);
    }

    public async Task ReviewLeaveRequest(int leaveRequestId, bool approved)
    {
       var user= await GetLoggeedUserAsync();
        var leaveRequest= await _context.LeaveRequests
            .Include(l=>l.LeaveType)
            .FirstAsync(l=>l.Id==leaveRequestId);
        leaveRequest.LeaveRequestStatusId=approved 
            ? (int)LeaveRequestStatusEnum.Approved
            :(int)LeaveRequestStatusEnum.Declined;
        leaveRequest.ReviewerId=user.Id;

        if (leaveRequest.LeaveRequestStatusId == (int)LeaveRequestStatusEnum.Approved)
        {
            var currentDate = DateTime.Now;
            var period= await _context.Periods.SingleAsync(p=>p.EndOn.Year==currentDate.Year);
            var allocation = await _context
                .LeaveAllocations
                .FirstOrDefaultAsync(l => l.LeaveTypeId == leaveRequest.LeaveTypeId
                                    && l.EmployeeId == leaveRequest.EmployeeId
                                    && l.PeriodId==period.Id);
            allocation.Days -= (leaveRequest.EndDate.DayNumber-leaveRequest.StartDate.DayNumber);
        }
        await _context.SaveChangesAsync();  
    }

    private async Task<ApplicationUser> GetLoggeedUserAsync()
    {
        return await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
    }
}

public interface ILeaveRequestService
{
    Task CreateLeaveRequest(LeaveRequestCreateVM model);
    Task<List<LeaveRequestReadOnlyVM>> GetEmployeeLeaveRequests();
    Task<EmployeeLeaveRequestListVM> AdminGetAllLeaveRequests();
    Task CancelLeaveRequest(int leaveRequestId);
    Task ReviewLeaveRequest(int leaveRequestId, bool approved);
    Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model);
    Task<ReviewLeaveRequestVM> GetLeaveRequestForReview(int id);
}

