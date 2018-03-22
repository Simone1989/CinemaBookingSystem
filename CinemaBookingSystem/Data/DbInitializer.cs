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
                    Time = DateTime.Parse("2018-03-03 21:00:00"),
                    BookedSeats = 34,
                    Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.",
                    Auditorium =  audi1,
                    ImageUrl = "/images/LotR.jpg"
                };
                var movie2 = new Screening
                {
                    Title = "Bill & Ted's Excellent Adventure",
                    Time = DateTime.Parse("2018-03-03 20:30:00"),
                    BookedSeats = 100,
                    Description = "Two seemingly dumb teens set off on a quest to prepare the ultimate historical presentation with the help of a time machine.",
                    Auditorium = audi2,
                    ImageUrl = "/images/BillTed.jpg"
                };
                var movie3 = new Screening
                {
                    Title = "Mad Max: Fury Road",
                    Time = DateTime.Parse("2018-03-03 19:00:00"),
                    BookedSeats = 22,
                    Description = "A woman rebels against a tyrannical ruler in postapocalyptic Australia in search for her home-land with the help of a group of female prisoners, a psychotic worshipper, and a drifter named Max.",
                    Auditorium = audi1,
                    ImageUrl = "/images/MadMax.jpg"
                };
                var movie4 = new Screening
                {
                    Title = "Dark City",
                    Time = DateTime.Parse("2018-03-03 22:30:00"),
                    BookedSeats = 4,
                    Description = "A man struggles with memories of his past, including a wife he cannot remember, in a nightmarish world with no sun.",
                    Auditorium = audi2,
                    ImageUrl = "/images/DarkCity.jpg"
                };
                var movie5 = new Screening
                {
                    Title = "Inception",
                    Time = DateTime.Parse("2018-03-03 12:00:00"),
                    BookedSeats = 80,
                    Description = "A thief, who steals corporate secrets through the use of dream-sharing technology, is given the inverse task of planting an idea into the mind of a CEO.",
                    Auditorium = audi2,
                    ImageUrl = "/images/Inception.jpg"
                };
                var movie6 = new Screening
                {
                    Title = "Donnie Darko",
                    Time = DateTime.Parse("2018-03-03 18:45:00"),
                    BookedSeats = 50,
                    Description = "A troubled teenager is plagued by visions of a man in a large rabbit suit who manipulates him to commit a series of crimes, after he narrowly escapes a bizarre accident.",
                    Auditorium = audi1,
                    ImageUrl = "/images/DonnieDarko.jpg"
                };
                context.Screenings.AddRange(
                    movie1,
                    movie2,
                    movie3,
                    movie4,
                    movie5,
                    movie6
                    );
                context.SaveChanges();
            }
        }
    }
}
