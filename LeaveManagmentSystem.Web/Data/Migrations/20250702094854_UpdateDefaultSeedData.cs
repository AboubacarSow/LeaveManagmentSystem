using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagmentSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDefaultSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1556e020-5f62-439e-b31d-394de93759fe", "584162ac-b288-4707-91ae-9b6c3c89bfb5" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "584162ac-b288-4707-91ae-9b6c3c89bfb5");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b6be7770-6c3d-42ce-97a7-7efdba0fb30a", 0, "152e516a-0c45-4813-a83a-61942ab5b823", new DateOnly(1999, 12, 4), "admin@localhost.com", true, "Admin", "Default", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEE8Yj4LaHQ2x4wzHHuN/2UWrWa/1e+7fH+lqL4ud1yr+RPm1qbcAYsp57QHEuMRUmQ==", null, false, "4d24d753-2be3-49ba-a0ec-86c11242bae8", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1556e020-5f62-439e-b31d-394de93759fe", "b6be7770-6c3d-42ce-97a7-7efdba0fb30a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1556e020-5f62-439e-b31d-394de93759fe", "b6be7770-6c3d-42ce-97a7-7efdba0fb30a" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6be7770-6c3d-42ce-97a7-7efdba0fb30a");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "584162ac-b288-4707-91ae-9b6c3c89bfb5", 0, "64c29aed-2b6a-4e40-a40e-b028962d3fa4", new DateOnly(1999, 12, 4), "admin@localhost.com", true, "Admin", "Default", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEMI3kmOJnV0MTgYL5ebM9f5r/eYwwhLAZK7SrO46REIgq5ogRjmSc9/MpWEwIzhYZQ==", null, false, "44b371d8-8cc8-4dd2-8551-df3e550e95c7", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1556e020-5f62-439e-b31d-394de93759fe", "584162ac-b288-4707-91ae-9b6c3c89bfb5" });
        }
    }
}
