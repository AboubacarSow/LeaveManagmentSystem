using System.ComponentModel.DataAnnotations;

namespace LeaveManagmentSystem.Web.Models.LeaveTypes;

public class LeaveTypeCreateVM
{
    [Required]
    [Length(4,150,ErrorMessage ="Name field must contain 4 to 150 characters")]
    public string Name { get; set; }
    [Required]
    [Range(1,90)]
    public int Days {  get; set; }
}
public class LeaveTypeEditVM
{
    public int Id {  get; set; }
    [Required]
    [Length(4,150,ErrorMessage ="Name field must contain 4 to 150 characters")]
    public string Name { get; set; }
    [Required]
    [Range(1,90)]
    public int Days {  get; set; }
}

 
