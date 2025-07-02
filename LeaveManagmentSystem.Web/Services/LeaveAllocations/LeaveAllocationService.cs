using AutoMapper;
using LeaveManagmentSystem.Web.Data;
using LeaveManagmentSystem.Web.Models.LeaveAllocations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagmentSystem.Web.Services.LeaveAllocations;

public class LeaveAllocationService(ApplicationDbContext _context,
    IHttpContextAccessor _httpContextAccessor, UserManager<ApplicationUser> _userManager
, IMapper _mapper) : ILeaveAllocationService
{

    public async Task AllocateLeave(string employeeId)
    {
        //get all the leave types
        var leavetypes = await _context.LeaveTypes.ToListAsync();

        //get the current period based on the year
        var currentDate = DateTime.Now;
        var period = await _context.Periods.SingleAsync(p => p.EndOn.Year == currentDate.Year);
        var monthRemaining = period.EndOn.Month - currentDate.Month;

        //for each leave type, create an allocation entry
        foreach (var leavetype in leavetypes)
        {
            var accuralRate = decimal.Divide(leavetype.NumberOfDays, 12);
            var leaveAllocation = new LeaveAllocation
            {
                EmployeeId = employeeId,
                LeaveTypeId = leavetype.Id,
                PeriodId = period.Id,
                Days = (int)Math.Ceiling(accuralRate * monthRemaining)
            };
            _context.Add(leaveAllocation);
        }
        await _context.SaveChangesAsync();
    }

    public async Task<List<LeaveAllocation>> GetAllocations()
    {
        var user =await GetCurrentUserAsync() ;
        var leaveAllocations = await _context.LeaveAllocations
            .Include(l => l.LeaveType)
            .Include(l => l.Period)
            .Where(q => q.EmployeeId == user.Id)
            .ToListAsync();
        return leaveAllocations;
    }

    public async Task<EmployeeAllocationVM> GetEmployeeAllocations()
    {
        var allocations = await GetAllocations();
        var allocationVMs = _mapper.Map<List<LeaveAllocationVM>>(allocations);
        var user=await GetCurrentUserAsync();
        var employeeVm = new EmployeeAllocationVM
        {
            DateOfBirth=user.DateOfBirth,
            Email=user.Email,
            FirstName=user.FirstName,
            LastName=user.LastName, 
            Id=user.Id,
            LeaveAllocations=allocationVMs,
        };
        return employeeVm;
    }
    private async Task<ApplicationUser> GetCurrentUserAsync()
    {
        return await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);
    }
}

public interface ILeaveAllocationService
{
    Task AllocateLeave(string employeeId);
    Task<List<LeaveAllocation>> GetAllocations();
    Task<EmployeeAllocationVM> GetEmployeeAllocations();
}
