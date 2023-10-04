using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Appointment.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("fb92b7ef-4b57-49bb-87b4-86ac3dba0e70"), "General Doctor", new TimeSpan(0, 0, 15, 0, 0), 2, new TimeSpan(0, 0, 5, 0, 0), "General" },
                    { new Guid("3be242d6-6b44-41a4-ac50-5f35f39c71a2"), "Specialist Doctor", new TimeSpan(0, 0, 30, 0, 0), 3, new TimeSpan(0, 0, 10, 0, 0), "Specialist" }
                });

            migrationBuilder.InsertData(
                schema: "Appointment",
                table: "Patients",
                columns: new[] { "Id", "Email", "Mobile", "Info_FirstName", "Info_LastName", "Info_NationalCode" },
                values: new object[,]
                {
                    { new Guid("8fce7d4f-2607-4588-8211-373b21850844"), "client2@yahoo.com", "09125235353", "Mina", "Amiri", "1230012300" },
                    { new Guid("929dd2a4-a952-4400-897d-4e0a683f5a66"), "client1@gmail.com", "09124214242", "Ali", "Alizade", "0023456789" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "Clinics",
                keyColumn: "Id",
                keyValue: new Guid("9f708dfd-5a9b-44ff-97a3-a1cd5f4168e2"));

            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "DoctorTypes",
                keyColumn: "Id",
                keyValue: new Guid("18091297-a21a-43ea-b273-ec1ade36c332"));

            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "DoctorTypes",
                keyColumn: "Id",
                keyValue: new Guid("90b6d815-6ae1-40e5-b530-0af5c46cebe2"));

            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("8fce7d4f-2607-4588-8211-373b21850844"));

            migrationBuilder.DeleteData(
                schema: "Appointment",
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("929dd2a4-a952-4400-897d-4e0a683f5a66"));

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
        }
    }
}
