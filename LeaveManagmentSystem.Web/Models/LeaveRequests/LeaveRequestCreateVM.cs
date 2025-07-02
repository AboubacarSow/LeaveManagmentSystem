using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagmentSystem.Web.Models.LeaveRequests;

public class LeaveRequestCreateVM
{
    [Display(Name ="Start Date")]
    [Required]
    public DateOnly StartDate { get; set; }
    [Display(Name = "End Date")]
    [Required]
    public DateOnly EndDate { get; set; }
    [Display(Name = "Desired Leave Type ")]
    [Required]
    public int LeaveTypeId { get; set; }
    [Display(Name = "Additional Information")]
    public string? RequestComments { get; set; }
    public SelectList? LeaveTypes { get; set; }    
}
