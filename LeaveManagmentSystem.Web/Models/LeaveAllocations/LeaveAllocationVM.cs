using LeaveManagmentSystem.Web.Models.LeaveTypes;
using LeaveManagmentSystem.Web.Models.Periods;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagmentSystem.Web.Models.LeaveAllocations;

public class LeaveAllocationVM
{
    public int Id { get; set; }
    [Display(Name ="Number Of Days")]
    public int NumberOfDays {  get; set; }
    [Display(Name = "Allocation Period")]
    public PeriodVM Period { get; set; } = new();
    public LeaveTypeReadOnlyVM LeaveType { get; set; }=new();
}
