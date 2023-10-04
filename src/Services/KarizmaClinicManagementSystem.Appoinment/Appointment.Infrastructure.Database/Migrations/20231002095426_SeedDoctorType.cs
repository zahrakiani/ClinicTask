using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Appointment.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedDoctorType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "Clinics",
                keyColumn: "Id",
                keyValue: new Guid("e3df7e31-ab6b-4f6d-a975-7ed1bac1faca"));

            migrationBuilder.InsertData(
                schema: "Appointment",
                table: "Clinics",
                columns: new[] { "Id", "Description", "EndDay", "EndTime", "Name", "StartDay", "StartTime" },
                values: new object[] { new Guid("c17c0d98-df43-491e-83d2-039f0e2148b6"), "KarizmaClinic is a test project on related to Karizma company, which was implemented by Zahra Kiani.", 3, new TimeSpan(0, 18, 0, 0, 0), "KarizmaClinic", 6, new TimeSpan(0, 9, 0, 0, 0) });

            migrationBuilder.InsertData(
                schema: "Appointment",
                table: "DoctorTypes",
                columns: new[] { "Id", "Description", "MaxDurationAppointmentTime", "MaxOverlap", "MinDurationAppointmentTime", "Title" },
                values: new object[,]
                {
                    { new Guid("3be242d6-6b44-41a4-ac50-5f35f39c71a2"), "Specialist Doctor", new TimeSpan(0, 0, 30, 0, 0), 3, new TimeSpan(0, 0, 10, 0, 0), "Specialist" },
                    { new Guid("fb92b7ef-4b57-49bb-87b4-86ac3dba0e70"), "General Doctor", new TimeSpan(0, 0, 15, 0, 0), 2, new TimeSpan(0, 0, 5, 0, 0), "General" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "Clinics",
                keyColumn: "Id",
                keyValue: new Guid("c17c0d98-df43-491e-83d2-039f0e2148b6"));

            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "DoctorTypes",
                keyColumn: "Id",
                keyValue: new Guid("3be242d6-6b44-41a4-ac50-5f35f39c71a2"));

            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "DoctorTypes",
                keyColumn: "Id",
                keyValue: new Guid("fb92b7ef-4b57-49bb-87b4-86ac3dba0e70"));

            migrationBuilder.InsertData(
                schema: "Appointment",
                table: "Clinics",
                columns: new[] { "Id", "Description", "EndDay", "EndTime", "Name", "StartDay", "StartTime" },
                values: new object[] { new Guid("e3df7e31-ab6b-4f6d-a975-7ed1bac1faca"), "", 3, new TimeSpan(0, 18, 0, 0, 0), "", 6, new TimeSpan(0, 9, 0, 0, 0) });
        }
    }
}
