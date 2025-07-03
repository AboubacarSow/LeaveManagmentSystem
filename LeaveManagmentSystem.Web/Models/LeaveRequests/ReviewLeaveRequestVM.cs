using LeaveManagmentSystem.Web.Models.LeaveAllocations;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagmentSystem.Web.Models.LeaveRequests;

public class ReviewLeaveRequestVM : LeaveRequestReadOnlyVM
{
    public EmployeeListVM Employee { get; set; } = new();
    [Display(Name ="Additional Information")]
    public string? RequestComments { get; set; }

}
