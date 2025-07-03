using AutoMapper;
using LeaveManagmentSystem.Data.Entities;
using LeaveManagmentSystem.Application.Models.LeaveAllocations;
using LeaveManagmentSystem.Application.Models.Periods;

namespace LeaveManagmentSystem.Application.AutoMapper;

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
