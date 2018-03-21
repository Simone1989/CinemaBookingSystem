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
                var audi1 = new Auditorium { NumberOfSeats = 50, BookedSeats = 0 };
                var audi2 = new Auditorium { NumberOfSeats = 100, BookedSeats = 0 };
                context.Auditoriums.AddRange(
                    audi1,
                    audi2
                    );
                context.SaveChanges();

                var movie1 = new Screening { Title = "Lord of the Rings: Fellowship of the Ring", Time = DateTime.Parse("2003-09-01") };
                context.Screenings.AddRange(
                    movie1
                    );
                context.SaveChanges();
            }
        }
    }
}
