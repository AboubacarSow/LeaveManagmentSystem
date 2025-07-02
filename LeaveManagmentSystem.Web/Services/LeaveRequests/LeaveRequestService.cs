using AutoMapper;
using Humanizer;
using LeaveManagmentSystem.Web.Data;
using LeaveManagmentSystem.Web.Data.Entities;
using LeaveManagmentSystem.Web.Data.Enums;
using LeaveManagmentSystem.Web.Data.Migrations;
using LeaveManagmentSystem.Web.Models.LeaveRequests;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LeaveManagmentSystem.Web.Services.LeaveRequests;

public class LeaveRequestService(IMapper _mapper,UserManager<ApplicationUser> _userManager,
   IHttpContextAccessor _httpContextAccessor,ApplicationDbContext _context ) : ILeaveRequestService
{
    public Task<EmployeeLeaveRequestListVM> AdminGetAllLeaveRequests()
    {
        throw new NotImplementedException();
    }

    public Task CancelLeaveRequest(int leaveRequestId)
    {
        throw new NotImplementedException();
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
        var numberofDays = model.EndDate.DayNumber - model.StartDate.DayNumber;
        var allocation = await _context
            .LeaveAllocations
            .FirstOrDefaultAsync(l=>l.LeaveTypeId==model.LeaveTypeId 
                                && l.EmployeeId==leaveRequest.EmployeeId);
        allocation.Days-=numberofDays;
        
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

    public Task<ReviewLeaveRequestVM> GetLeaveRequestForReview(int id)
    {
        throw new NotImplementedException();
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

    public Task ReviewLeaveRequest(int leaveRequestId, bool approved)
    {
        throw new NotImplementedException();
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

