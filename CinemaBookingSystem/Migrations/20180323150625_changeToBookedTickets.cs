using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CinemaBookingSystem.Migrations
{
    public partial class changeToBookedTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FreeSeats",
                table: "Screenings",
                newName: "BookedTickets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookedTickets",
                table: "Screenings",
                newName: "FreeSeats");
        }
    }
}
