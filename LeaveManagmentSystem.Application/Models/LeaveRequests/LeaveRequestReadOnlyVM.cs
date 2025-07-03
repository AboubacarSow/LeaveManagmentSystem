using LeaveManagmentSystem.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagmentSystem.Application.Models.LeaveRequests;

public class LeaveRequestReadOnlyVM
{
    public int Id {  get; set; }
    [Display(Name = "Start Date")]
    public DateOnly StartDate { get; set; }
    [Display(Name="End Date")]
    public DateOnly EndDate { get; set; }
    [Display(Name ="Total Days")]
    public int NumberOfDays {  get; set; }
    [Display(Name = "Leave Type")]
    public string LeaveType { get; set; }=string.Empty;
    [Display(Name = "Leave Request Status")]
    public LeaveRequestStatusEnum LeaveRequestStatus { get; set; }

}
