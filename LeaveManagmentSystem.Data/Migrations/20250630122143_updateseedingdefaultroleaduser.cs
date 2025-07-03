using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagmentSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateseedingdefaultroleaduser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a96210e-53e2-48ee-bdc3-c6bffb644625",
                columns: ["ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp"],
                values: ["fb0bd23c-68da-4366-b733-0f88aa83ab65", new DateOnly(1999, 12, 4), "Admin", "Default", "AQAAAAIAAYagAAAAEGvkNi7UgXltSyqoB/gS3hzfEJY3wspBx3U462iDKvPjy+hcQzTgnI5Z9FxFIgICHQ==", "62565764-bb49-4949-8b52-625bf4f64e02"]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a96210e-53e2-48ee-bdc3-c6bffb644625",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c97ada6c-9eed-4d76-b325-70a21e675b96", "AQAAAAIAAYagAAAAEMHioJ1/Hmkj3btA1sxmAWzZVS0Ra46KLbBCcin1TyCE/WzaVz+gmm/v7arVRU4niQ==", "ac6c5e6b-7ac6-4800-8bbb-18b1ce47ffd0" });
        }
    }
}
