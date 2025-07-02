using AutoMapper;
using LeaveManagmentSystem.Web.Common;
using LeaveManagmentSystem.Web.Data;
using LeaveManagmentSystem.Web.Models.LeaveAllocations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace LeaveManagmentSystem.Web.Services.LeaveAllocations;

public class LeaveAllocationService(ApplicationDbContext _context,
    IHttpContextAccessor _httpContextAccessor, UserManager<ApplicationUser> _userManager
, IMapper _mapper) : ILeaveAllocationService
{

    public async Task AllocateLeave(string employeeId)
    {
        //get all the leave types
        var leavetypes = await _context.LeaveTypes
            .Where(q=>!q.LeaveAllocations.Any(e=>e.EmployeeId==employeeId))
            .ToListAsync();

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

    public async Task EditAllocation(LeaveAllocationEditVM allocationVm)
    {
        //var leaveAllocation = await GetEmployeeAllocation(allocationVm.Id) ?? throw new Exception("Leave Allocation record does not exist") ;
        //leaveAllocation.Days= allocationVm.Days;
        //option 1 _context.Update(leavAllocatin);
        //option 2 _context.Entry(leaveAllocation).State = EntityState.Modified;
        // _context.SaveChanges()

        //But here it seems like we are making partial update, so we can proced this way
        await _context
            .LeaveAllocations
            .Where(l=>l.Id==allocationVm.Id)
            .ExecuteUpdateAsync(v=>v.SetProperty(e=>e.Days,allocationVm.Days));
    }

    public async Task<LeaveAllocationEditVM?> GetEmployeeAllocation(int id)
    {
        var allocation= await _context.LeaveAllocations
            .Include(e=>e.LeaveType)
            .Include(e=>e.Employee)
            .FirstOrDefaultAsync(a=>a.Id==id);
        return _mapper.Map<LeaveAllocationEditVM?>(allocation);
    }

    public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId)
    {
        var user= string.IsNullOrEmpty(userId) 
            ? await GetCurrentUserAsync() 
            : await _userManager.FindByIdAsync(userId);
        var allocations = await GetAllocations(user.Id);
        var allocationVMs = _mapper.Map<List<LeaveAllocationVM>>(allocations);
       var leaveTypesCount= await _context.LeaveTypes.CountAsync();
        var employeeVm = new EmployeeAllocationVM
        {
            DateOfBirth=user.DateOfBirth,
            Email=user.Email,
            FirstName=user.FirstName,
            LastName=user.LastName, 
            Id=user.Id,
            LeaveAllocations=allocationVMs,
            IsCompletedAllocation = leaveTypesCount == allocations.Count
        };
        return employeeVm;
    }

    public async Task<List<EmployeeListVM>> GetEmployees()
    {
        var users = (await _userManager.GetUsersInRoleAsync(Roles.Employee)).ToList();
        return  _mapper.Map<List<EmployeeListVM>>(users);
    }

    private async Task<List<LeaveAllocation>> GetAllocations(string userId)
    {
        var currentDate = DateTime.Now;
        var leaveAllocations = await _context.LeaveAllocations
            .Include(l => l.LeaveType)
            .Include(l => l.Period)
            .Where(q => q.EmployeeId == userId && q.Period.EndOn.Year == currentDate.Year)
            .ToListAsync();
        return leaveAllocations;
    }
    private async Task<ApplicationUser> GetCurrentUserAsync()
    {
        return await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);
    }

    //private async Task<bool> AllocationExists(string userId,int periodId,int leaveTypeId)
    //{
    //    return await _context.LeaveAllocations.AnyAsync(
    //        e => e.EmployeeId == userId &&
    //        e.PeriodId == periodId &&
    //        e.LeaveTypeId == leaveTypeId
    //        );
    //}
}

public interface ILeaveAllocationService
{
    Task AllocateLeave(string employeeId);
    Task EditAllocation(LeaveAllocationEditVM allocationVm);
    Task<LeaveAllocationEditVM?> GetEmployeeAllocation(int id);
    Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId);
    Task<List<EmployeeListVM>> GetEmployees();
}
