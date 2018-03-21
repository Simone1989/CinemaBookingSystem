using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CinemaBookingSystem.Migrations
{
    public partial class AddedScreeningDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Screenings",
                maxLength: 400,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Auditoriums",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Screenings");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Auditoriums",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);
        }
    }
}
