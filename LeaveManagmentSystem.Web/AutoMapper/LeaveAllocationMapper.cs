using AutoMapper;
using LeaveManagmentSystem.Web.Models.LeaveAllocations;
using LeaveManagmentSystem.Web.Models.Periods;

namespace LeaveManagmentSystem.Web.AutoMapper;

public class LeaveAllocationMapper :Profile
{
    public LeaveAllocationMapper()
    {
        CreateMap<LeaveAllocation, LeaveAllocationVM>();
        CreateMap<LeaveAllocation, LeaveAllocationEditVM>();
        CreateMap<ApplicationUser, EmployeeListVM>();
        CreateMap<Period, PeriodVM>();
    }
}
