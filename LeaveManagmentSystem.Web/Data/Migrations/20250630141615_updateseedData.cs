using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagmentSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateseedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e4bdfc66-ff31-4cae-9e50-b37bf4e84950", "3a96210e-53e2-48ee-bdc3-c6bffb644625" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4bdfc66-ff31-4cae-9e50-b37bf4e84950");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a96210e-53e2-48ee-bdc3-c6bffb644625");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1556e020-5f62-439e-b31d-394de93759fe", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "584162ac-b288-4707-91ae-9b6c3c89bfb5", 0, "6be1af78-4086-4669-ada8-047c8ebafb45", new DateOnly(1999, 12, 4), "admin@localhost.com", true, "Admin", "Default", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEF8DmTB2azKZeQY9dS6gnWxfy9nijYm59aUwzCmT/l9v9+rXctghPQp1GJ3Z/OjlMQ==", null, false, "3987c8a1-425a-48c5-922c-ebe2b975c416", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1556e020-5f62-439e-b31d-394de93759fe", "584162ac-b288-4707-91ae-9b6c3c89bfb5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1556e020-5f62-439e-b31d-394de93759fe", "584162ac-b288-4707-91ae-9b6c3c89bfb5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1556e020-5f62-439e-b31d-394de93759fe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "584162ac-b288-4707-91ae-9b6c3c89bfb5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e4bdfc66-ff31-4cae-9e50-b37bf4e84950", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3a96210e-53e2-48ee-bdc3-c6bffb644625", 0, "fb0bd23c-68da-4366-b733-0f88aa83ab65", new DateOnly(1999, 12, 4), "admin@localhost.com", true, "Admin", "Default", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEGvkNi7UgXltSyqoB/gS3hzfEJY3wspBx3U462iDKvPjy+hcQzTgnI5Z9FxFIgICHQ==", null, false, "62565764-bb49-4949-8b52-625bf4f64e02", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e4bdfc66-ff31-4cae-9e50-b37bf4e84950", "3a96210e-53e2-48ee-bdc3-c6bffb644625" });
        }
    }
}
