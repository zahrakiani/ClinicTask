using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointment.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedClinic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Appointment",
                table: "Clinics",
                columns: new[] { "Id", "Description", "EndDay", "EndTime", "Name", "StartDay", "StartTime" },
                values: new object[] { new Guid("e3df7e31-ab6b-4f6d-a975-7ed1bac1faca"), "KarizmaClinic is a test project on related to Karizma company, which was implemented by Zahra Kiani.", 3, new TimeSpan(0, 18, 0, 0, 0), "KarizmaClinic", 6, new TimeSpan(0, 9, 0, 0, 0) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "Clinics",
                keyColumn: "Id",
                keyValue: new Guid("e3df7e31-ab6b-4f6d-a975-7ed1bac1faca"));
        }
    }
}
