using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Appointment.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedDoctorWeeklySchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "Clinics",
                keyColumn: "Id",
                keyValue: new Guid("9f708dfd-5a9b-44ff-97a3-a1cd5f4168e2"));



            migrationBuilder.InsertData(
                schema: "Appointment",
                table: "Clinics",
                columns: new[] { "Id", "Description", "EndDay", "EndTime", "Name", "StartDay", "StartTime" },
                values: new object[] { new Guid("03483fd2-2537-4da7-bc5f-2c5051f4f3db"), "KarizmaClinic is a test project on related to Karizma company, which was implemented by Zahra Kiani.", 3, new TimeSpan(0, 18, 0, 0, 0), "KarizmaClinic", 6, new TimeSpan(0, 9, 0, 0, 0) });

            migrationBuilder.InsertData(
                schema: "Appointment",
                table: "DoctorDailySchedules",
                columns: new[] { "DoctorId", "Id", "Date", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0"), new Guid("17fa0b02-05ef-46af-9cea-04b8da99ebe9"), new DateTime(2023, 10, 11, 14, 16, 46, 809, DateTimeKind.Local).AddTicks(7012), new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0"), new Guid("445389f6-1caf-439e-8896-d3751a2875b5"), new DateTime(2023, 10, 10, 14, 16, 46, 809, DateTimeKind.Local).AddTicks(7009), new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 14, 0, 0, 0) },
                    { new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0"), new Guid("6f5df522-404b-4288-a510-93c8c287fa41"), new DateTime(2023, 10, 9, 14, 16, 46, 809, DateTimeKind.Local).AddTicks(7006), new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0"), new Guid("7674b44d-064a-453c-afd8-eb32cc75f03a"), new DateTime(2023, 10, 7, 14, 16, 46, 809, DateTimeKind.Local).AddTicks(6977), new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0"), new Guid("ba0340f6-79e5-4676-b65b-966c8d38e380"), new DateTime(2023, 10, 8, 14, 16, 46, 809, DateTimeKind.Local).AddTicks(7003), new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 14, 0, 0, 0) },
                    { new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d"), new Guid("2193079e-00b3-4de2-abb5-2a49b118756a"), new DateTime(2023, 10, 10, 14, 16, 46, 809, DateTimeKind.Local).AddTicks(7029), new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d"), new Guid("582ab276-142c-4992-8168-8c45f3701c3c"), new DateTime(2023, 10, 8, 14, 16, 46, 809, DateTimeKind.Local).AddTicks(7017), new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 14, 0, 0, 0) },
                    { new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d"), new Guid("87f3dcc4-255b-445d-b8b2-5b35a05a373a"), new DateTime(2023, 10, 7, 14, 16, 46, 809, DateTimeKind.Local).AddTicks(7014), new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d"), new Guid("ac918875-76e9-4c3a-80ac-5ccfc542308a"), new DateTime(2023, 10, 9, 14, 16, 46, 809, DateTimeKind.Local).AddTicks(7025), new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0) }
                });

          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "Clinics",
                keyColumn: "Id",
                keyValue: new Guid("03483fd2-2537-4da7-bc5f-2c5051f4f3db"));

            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "DoctorDailySchedules",
                keyColumns: new[] { "DoctorId", "Id" },
                keyValues: new object[] { new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0"), new Guid("17fa0b02-05ef-46af-9cea-04b8da99ebe9") });

            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "DoctorDailySchedules",
                keyColumns: new[] { "DoctorId", "Id" },
                keyValues: new object[] { new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0"), new Guid("445389f6-1caf-439e-8896-d3751a2875b5") });

            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "DoctorDailySchedules",
                keyColumns: new[] { "DoctorId", "Id" },
                keyValues: new object[] { new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0"), new Guid("6f5df522-404b-4288-a510-93c8c287fa41") });

            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "DoctorDailySchedules",
                keyColumns: new[] { "DoctorId", "Id" },
                keyValues: new object[] { new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0"), new Guid("7674b44d-064a-453c-afd8-eb32cc75f03a") });

            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "DoctorDailySchedules",
                keyColumns: new[] { "DoctorId", "Id" },
                keyValues: new object[] { new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0"), new Guid("ba0340f6-79e5-4676-b65b-966c8d38e380") });

            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "DoctorDailySchedules",
                keyColumns: new[] { "DoctorId", "Id" },
                keyValues: new object[] { new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d"), new Guid("2193079e-00b3-4de2-abb5-2a49b118756a") });

            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "DoctorDailySchedules",
                keyColumns: new[] { "DoctorId", "Id" },
                keyValues: new object[] { new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d"), new Guid("582ab276-142c-4992-8168-8c45f3701c3c") });

            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "DoctorDailySchedules",
                keyColumns: new[] { "DoctorId", "Id" },
                keyValues: new object[] { new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d"), new Guid("87f3dcc4-255b-445d-b8b2-5b35a05a373a") });

            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "DoctorDailySchedules",
                keyColumns: new[] { "DoctorId", "Id" },
                keyValues: new object[] { new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d"), new Guid("ac918875-76e9-4c3a-80ac-5ccfc542308a") });

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
                values: new object[] { new Guid("9f708dfd-5a9b-44ff-97a3-a1cd5f4168e2"), "KarizmaClinic is a test project on related to Karizma company, which was implemented by Zahra Kiani.", 3, new TimeSpan(0, 18, 0, 0, 0), "KarizmaClinic", 6, new TimeSpan(0, 9, 0, 0, 0) });

            migrationBuilder.InsertData(
                schema: "Appointment",
                table: "DoctorTypes",
                columns: new[] { "Id", "Description", "MaxDurationAppointmentTime", "MaxOverlap", "MinDurationAppointmentTime", "Title" },
                values: new object[,]
                {
                    { new Guid("18091297-a21a-43ea-b273-ec1ade36c332"), "General Doctor", new TimeSpan(0, 0, 15, 0, 0), 2, new TimeSpan(0, 0, 5, 0, 0), "General" },
                    { new Guid("90b6d815-6ae1-40e5-b530-0af5c46cebe2"), "Specialist Doctor", new TimeSpan(0, 0, 30, 0, 0), 3, new TimeSpan(0, 0, 10, 0, 0), "Specialist" }
                });
        }
    }
}
