using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CinemaBookingSystem.Migrations
{
    public partial class MovedBookedSeats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookedSeats",
                table: "Auditoriums");

            migrationBuilder.AddColumn<int>(
                name: "BookedSeats",
                table: "Screenings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookedSeats",
                table: "Screenings");

            migrationBuilder.AddColumn<int>(
                name: "BookedSeats",
                table: "Auditoriums",
                nullable: false,
                defaultValue: 0);
        }
    }
}
