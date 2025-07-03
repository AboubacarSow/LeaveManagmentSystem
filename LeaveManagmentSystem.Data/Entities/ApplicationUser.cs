using Microsoft.AspNetCore.Identity;

namespace LeaveManagmentSystem.Data.Entities;

public class ApplicationUser :IdentityUser
{
    public string FirstName {  get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }   
}
