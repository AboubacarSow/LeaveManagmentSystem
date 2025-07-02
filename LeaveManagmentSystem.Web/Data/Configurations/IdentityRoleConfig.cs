using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagmentSystem.Web.Data.Configurations;

public class IdentityRoleConfig : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "a55f271b-e1f6-4121-a98c-2ee8c08ec747",
                Name = "Employee",
                NormalizedName = "EMPLYEE"
            },
            new IdentityRole
            {
                Id = "8d7b6299-c6f8-4586-b623-2184b3c59b04",
                Name = "Supervisor",
                NormalizedName = "SUPERVISOR"
            },
            new IdentityRole
            {
                Id = "1556e020-5f62-439e-b31d-394de93759fe",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            });
    }
}
