using LeaveManagmentSystem.Application.Models.LeaveTypes;
using LeaveManagmentSystem.Application.Models.Periods;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagmentSystem.Application.Models.LeaveAllocations;

public class LeaveAllocationVM
{
    public int Id { get; set; }
    [Display(Name ="Number Of Days")]
    public int Days {  get; set; }
    [Display(Name = "Allocation Period")]
    public PeriodVM Period { get; set; } = new();
    public LeaveTypeReadOnlyVM LeaveType { get; set; }=new();
}
public class LeaveAllocationEditVM : LeaveAllocationVM
{
    public EmployeeListVM? Employee { get; set; }
}
