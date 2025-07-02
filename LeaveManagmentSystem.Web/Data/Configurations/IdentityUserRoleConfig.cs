using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagmentSystem.Web.Data.Configurations;

public class IdentityUserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {

        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "1556e020-5f62-439e-b31d-394de93759fe",
                UserId = "b6be7770-6c3d-42ce-97a7-7efdba0fb30a"
            });
    }
}
