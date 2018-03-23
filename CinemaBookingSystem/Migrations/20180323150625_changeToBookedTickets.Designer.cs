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
    [Migration("20180323150625_changeToBookedTickets")]
    partial class changeToBookedTickets
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("NumberOfSeats");

                    b.HasKey("Id");

                    b.ToTable("Auditoriums");
                });

            modelBuilder.Entity("CinemaBookingSystem.Models.Screening", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AuditoriumId");

                    b.Property<int>("BookedTickets");

                    b.Property<string>("Description")
                        .HasMaxLength(400);

                    b.Property<string>("ImageUrl");

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
                        .HasForeignKey("AuditoriumId");
                });
#pragma warning restore 612, 618
        }
    }
}