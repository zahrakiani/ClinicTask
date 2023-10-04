using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointment.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class CreateDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                schema: "Appointment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Info_Prefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Info_LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DoctorTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorDailySchedules",
                schema: "Appointment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorDailySchedules", x => new { x.DoctorId, x.Id });
                    table.ForeignKey(
                        name: "FK_DoctorDailySchedules_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "Appointment",
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                schema: "Appointment",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                schema: "Appointment",
                table: "Appointments",
                column: "DoctorId",
                principalSchema: "Appointment",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                schema: "Appointment",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "DoctorDailySchedules",
                schema: "Appointment");

            migrationBuilder.DropTable(
                name: "Doctors",
                schema: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DoctorId",
                schema: "Appointment",
                table: "Appointments");
        }
    }
}
