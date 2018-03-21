using CinemaBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Data
{
    public class DbInitializer
    {
        public static void Initialize(CinemaContext context)
        {
            if (context.Screenings.Any())
            {
                return;
            }
            else
            {
                var audi1 = new Auditorium { NumberOfSeats = 50, BookedSeats = 0, Name = "Keaton Theatre"};
                var audi2 = new Auditorium { NumberOfSeats = 100, BookedSeats = 0, Name = "Burton Hall"};
                context.Auditoriums.AddRange(
                    audi1,
                    audi2
                    );
                context.SaveChanges();

                var movie1 = new Screening
                {
                    Title = "Lord of the Rings: Fellowship of the Ring",
                    Time = DateTime.Parse("2006-03-03"),
                    Auditorium =  audi1
                };
                var movie2 = new Screening
                {
                    Title = "Bill & Ted's Excellent Adventure",
                    Time = DateTime.Parse("2006-03-03"),
                    Auditorium = audi2
                };
                var movie3 = new Screening
                {
                    Title = "Mad Max: Fury Road",
                    Time = DateTime.Parse("2006-03-03"),
                    Auditorium = audi1
                };
                context.Screenings.AddRange(
                    movie1,
                    movie2,
                    movie3
                    );
                context.SaveChanges();
            }
        }
    }
}
