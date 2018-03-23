using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CinemaBookingSystem.Migrations
{
    public partial class changeToFreeSeats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookedSeats",
                table: "Screenings",
                newName: "FreeSeats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FreeSeats",
                table: "Screenings",
                newName: "BookedSeats");
        }
    }
}
