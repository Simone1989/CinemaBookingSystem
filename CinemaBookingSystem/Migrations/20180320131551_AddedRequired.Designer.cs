﻿// <auto-generated />
using CinemaBookingSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CinemaBookingSystem.Migrations
{
    [DbContext(typeof(CinemaContext))]
    [Migration("20180320131551_AddedRequired")]
    partial class AddedRequired
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CinemaBookingSystem.Models.Auditorium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookedSeats");

                    b.Property<int>("NumberOfSeats");

                    b.HasKey("Id");

                    b.ToTable("Auditoriums");
                });

            modelBuilder.Entity("CinemaBookingSystem.Models.Screening", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuditoriumId");

                    b.Property<DateTime>("Time");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("AuditoriumId");

                    b.ToTable("Screenings");
                });

            modelBuilder.Entity("CinemaBookingSystem.Models.Screening", b =>
                {
                    b.HasOne("CinemaBookingSystem.Models.Auditorium", "Auditorium")
                        .WithMany("Screenings")
                        .HasForeignKey("AuditoriumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
