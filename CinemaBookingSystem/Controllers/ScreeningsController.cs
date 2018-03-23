using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CinemaBookingSystem.Data;
using System.Linq;
using CinemaBookingSystem.Models.CinemaViewModel;
using System.Collections.Generic;
using CinemaBookingSystem.Models;

namespace CinemaBookingSystem.Controllers
{
    public class ScreeningsController : Controller
    {
        private readonly CinemaContext _context;

        public ScreeningsController(CinemaContext context)
        {
            _context = context;
        }

        // GET: Screenings
        public async Task<IActionResult> Index(string sortOrder)
        {
            // Sorterig i screeninglistan
            ViewData["TimeSortParm"] = string.IsNullOrEmpty(sortOrder) ? "time_desc" : "";
            ViewData["SeatsSortParm"] = sortOrder == "Seats" ? "seats_desc" : "Seats";
            ViewData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "Name";
            var screeningSort = from s in _context.Screenings.Include(s => s.Auditorium)
                                select s;

            switch (sortOrder)
            {
                case "Name":
                    screeningSort = screeningSort.OrderBy(s => s.Title);
                    break;
                case "name_desc":
                    screeningSort = screeningSort.OrderByDescending(s => s.Title);
                    break;
                case "time_desc":
                    screeningSort = screeningSort.OrderByDescending(s => s.Time);
                    break;
                case "Seats":
                    screeningSort = screeningSort.OrderBy(s => s.BookedTickets);
                    break;
                case "seats_desc":
                    screeningSort = screeningSort.OrderByDescending(s => s.BookedTickets);
                    break;
                default:
                    screeningSort = screeningSort.OrderBy(s => s.Time);
                    break; 
            }
            return View(await screeningSort.AsNoTracking().ToListAsync());
        }

        // GET: Screenings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screening = await _context.Screenings
                .Include(s => s.Auditorium)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (screening == null)
            {
                return NotFound();
            }

            return View(screening);
        }

        [HttpGet]
        public async Task<IActionResult> Booking(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screening = _context.Screenings
                .Include(s => s.Auditorium)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (screening == null)
            {
                return NotFound();
            }
            return View(await screening);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult BookingConfirmation(int? id, int numberOfTickets)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screening = _context.Screenings
                .Include(s => s.Auditorium)
                .SingleOrDefault(m => m.Id == id);

            var updateBookedSeats = screening.BookedTickets;

            updateBookedSeats = screening.BookedTickets + numberOfTickets;

            if(screening != null)
            {
                var totalTickets = screening.BookedTickets = screening.BookedTickets + numberOfTickets;

                if(totalTickets > screening.Auditorium.NumberOfSeats || numberOfTickets > 12 || numberOfTickets < 1)
                {
                    // returnera nått annat här
                    return NotFound();
                }
                else
                {
                    _context.SaveChanges();
                }
            }
            else
            {
                return NotFound();
            }

            return View(screening);
        }




        // POST: Screenings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Time")] Screening screening)
        //{
        //    if (id != screening.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(screening);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ScreeningExists(screening.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(screening);
        //}
    }
}
