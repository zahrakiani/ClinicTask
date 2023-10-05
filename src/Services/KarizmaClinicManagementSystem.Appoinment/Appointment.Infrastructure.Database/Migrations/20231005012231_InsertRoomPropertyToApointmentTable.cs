using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Appointment.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class InsertRoomPropertyToApointmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
           
            
            
            migrationBuilder.AddColumn<string>(
                name: "Room",
                schema: "Appointment",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            
        }

        /// <inheritdoc />

    }
}
