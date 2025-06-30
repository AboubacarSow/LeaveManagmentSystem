using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagmentSystem.Web.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id= "a55f271b-e1f6-4121-a98c-2ee8c08ec747",
                Name="Employee",
                NormalizedName="EMPLYEE"
            },
            new IdentityRole
            {
                Id= "8d7b6299-c6f8-4586-b623-2184b3c59b04",
                Name="Supervisor",
                NormalizedName="SUPERVISOR"
            },
            new IdentityRole
            {
                Id= "1556e020-5f62-439e-b31d-394de93759fe",
                Name="Administrator",
                NormalizedName="ADMINISTRATOR"
            });
        var hasher =new PasswordHasher<ApplicationUser>();
        builder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                Id = "584162ac-b288-4707-91ae-9b6c3c89bfb5",
                Email = "admin@localhost.com",
                NormalizedEmail = "ADMIN@LOCALHOST.COM",
                UserName = "admin@localhost.com",
                NormalizedUserName = "ADMIN@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null, "P@ssword12"),
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "Default",
                DateOfBirth = new DateOnly(1999, 12, 04)
            });
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> 
            { 
                RoleId= "1556e020-5f62-439e-b31d-394de93759fe",
                UserId= "584162ac-b288-4707-91ae-9b6c3c89bfb5"
            });
    }

    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
    public DbSet<Period> Periods { get; set; }
}
