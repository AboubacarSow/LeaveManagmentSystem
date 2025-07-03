using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagmentSystem.Application.Models.LeaveRequests;

public class LeaveRequestCreateVM : IValidatableObject
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

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (StartDate > EndDate)
        {
            yield return new ValidationResult("The Start Date must be before the End Date",
                [nameof(StartDate), nameof(EndDate)]);
        }
    }
}
