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
                var audi1 = new Auditorium { NumberOfSeats = 50, Name = "Keaton Theatre"};
                var audi2 = new Auditorium { NumberOfSeats = 100, Name = "Burton Hall"};
                context.Auditoriums.AddRange(
                    audi1,
                    audi2
                    );
                context.SaveChanges();

                var movie1 = new Screening
                {
                    Title = "Lord of the Rings: Fellowship of the Ring",
                    Time = DateTime.Parse("2006-03-03"),
                    BookedSeats = 34,
                    Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.",
                    Auditorium =  audi1
                };
                var movie2 = new Screening
                {
                    Title = "Bill & Ted's Excellent Adventure",
                    Time = DateTime.Parse("2006-03-03"),
                    BookedSeats = 100,
                    Description = "Two seemingly dumb teens set off on a quest to prepare the ultimate historical presentation with the help of a time machine.",
                    Auditorium = audi2
                };
                var movie3 = new Screening
                {
                    Title = "Mad Max: Fury Road",
                    Time = DateTime.Parse("2006-03-03"),
                    BookedSeats = 22,
                    Description = "A woman rebels against a tyrannical ruler in postapocalyptic Australia in search for her home-land with the help of a group of female prisoners, a psychotic worshipper, and a drifter named Max.",
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
