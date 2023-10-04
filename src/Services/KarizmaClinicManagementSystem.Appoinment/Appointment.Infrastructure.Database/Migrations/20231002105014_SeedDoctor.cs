using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Appointment.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("0a509603-2c42-4512-8de8-f81dc5e8d34c"), "KarizmaClinic is a test project on related to Karizma company, which was implemented by Zahra Kiani.", 3, new TimeSpan(0, 18, 0, 0, 0), "KarizmaClinic", 6, new TimeSpan(0, 9, 0, 0, 0) });

            migrationBuilder.InsertData(
                schema: "Appointment",
                table: "DoctorTypes",
                columns: new[] { "Id", "Description", "MaxDurationAppointmentTime", "MaxOverlap", "MinDurationAppointmentTime", "Title" },
                values: new object[,]
                {
                    { new Guid("c89c78cd-fb7f-4857-905c-1f9f444c4feb"), "General Doctor", new TimeSpan(0, 0, 15, 0, 0), 2, new TimeSpan(0, 0, 5, 0, 0), "General" },
                    { new Guid("e78d12d9-31e4-44b8-bb07-b23d297f41ab"), "Specialist Doctor", new TimeSpan(0, 0, 30, 0, 0), 3, new TimeSpan(0, 0, 10, 0, 0), "Specialist" }
                });

            migrationBuilder.InsertData(
                schema: "Appointment",
                table: "Doctors",
                columns: new[] { "Id", "DoctorTypeId", "Email", "Mobile", "Info_FirstName", "Info_LastName", "Info_Prefix" },
                values: new object[,]
                {
                    { new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0"), new Guid("3be242d6-6b44-41a4-ac50-5f35f39c71a2"), "Tehrani@clinic.com", "09121211212", "Sara", "Tehrani", "Neurologists" },
                    { new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d"), new Guid("fb92b7ef-4b57-49bb-87b4-86ac3dba0e70"), "Ahmadi@clinic.com", "09121231313", "Hamid", "Ahmadi", "Dermatologist" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "Clinics",
                keyColumn: "Id",
                keyValue: new Guid("0a509603-2c42-4512-8de8-f81dc5e8d34c"));

            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "DoctorTypes",
                keyColumn: "Id",
                keyValue: new Guid("c89c78cd-fb7f-4857-905c-1f9f444c4feb"));

            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "DoctorTypes",
                keyColumn: "Id",
                keyValue: new Guid("e78d12d9-31e4-44b8-bb07-b23d297f41ab"));

            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0"));

            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d"));

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
    }
}
