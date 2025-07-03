using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagmentSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRoleAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: ["Id", "ConcurrencyStamp", "Name", "NormalizedName"],
                values: new object[,]
                {
                    { "8d7b6299-c6f8-4586-b623-2184b3c59b04", null, "Supervisor", "SUPERVISOR" },
                    { "a55f271b-e1f6-4121-a98c-2ee8c08ec747", null, "Employee", "EMPLYEE" },
                    { "e4bdfc66-ff31-4cae-9e50-b37bf4e84950", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: ["Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName"],
                values: ["3a96210e-53e2-48ee-bdc3-c6bffb644625", 0, "c97ada6c-9eed-4d76-b325-70a21e675b96", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEMHioJ1/Hmkj3btA1sxmAWzZVS0Ra46KLbBCcin1TyCE/WzaVz+gmm/v7arVRU4niQ==", null, false, "ac6c5e6b-7ac6-4800-8bbb-18b1ce47ffd0", false, "admin@localhost.com"]);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: ["RoleId", "UserId"],
                values: ["e4bdfc66-ff31-4cae-9e50-b37bf4e84950", "3a96210e-53e2-48ee-bdc3-c6bffb644625"]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d7b6299-c6f8-4586-b623-2184b3c59b04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a55f271b-e1f6-4121-a98c-2ee8c08ec747");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: ["RoleId", "UserId"],
                keyValues: ["e4bdfc66-ff31-4cae-9e50-b37bf4e84950", "3a96210e-53e2-48ee-bdc3-c6bffb644625"]);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4bdfc66-ff31-4cae-9e50-b37bf4e84950");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a96210e-53e2-48ee-bdc3-c6bffb644625");
        }
    }
}
