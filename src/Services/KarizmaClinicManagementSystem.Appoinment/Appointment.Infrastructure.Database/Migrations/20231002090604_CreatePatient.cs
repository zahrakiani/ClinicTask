using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointment.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class CreatePatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                schema: "Appointment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Info_NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Info_FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Info_LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                schema: "Appointment",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                schema: "Appointment",
                table: "Appointments",
                column: "PatientId",
                principalSchema: "Appointment",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                schema: "Appointment",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "Patients",
                schema: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PatientId",
                schema: "Appointment",
                table: "Appointments");
        }
    }
}
