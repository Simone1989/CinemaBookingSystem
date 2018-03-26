using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CinemaBookingSystem.Data;
using System.Linq;
using Microsoft.AspNetCore.Routing;

namespace CinemaBookingSystem.Controllers
{
    public class ScreeningsController : Controller
    {
        private readonly CinemaContext _context;

        public ScreeningsController(CinemaContext context)
        {
            _context = context;
        }


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

        [HttpGet]
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

        //[HttpGet]
        //public async Task<IActionResult> Booking(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var screening = _context.Screenings
        //        .Include(s => s.Auditorium)
        //        .SingleOrDefaultAsync(m => m.Id == id);

        //    if (screening == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(await screening);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Får det inte att fungera med async och await här
        public IActionResult Details(int? id, int numberOfTickets)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screening = _context.Screenings
                .Include(s => s.Auditorium)
                .SingleOrDefault(m => m.Id == id);

            if (ModelState.IsValid)
            {
                var totalTickets = screening.BookedTickets = screening.BookedTickets + numberOfTickets;
                try
                {
                    if (totalTickets > screening.Auditorium.NumberOfSeats)
                    {
                        ModelState.AddModelError(string.Empty, "You can't buy more tickets than there are seats.");
                        return View(screening);
                    }
                    else if(numberOfTickets > 12)
                    {
                        ModelState.AddModelError(string.Empty, "You can't buy more than 12 tickets per screening");
                        return View(screening);
                    }
                    else if(numberOfTickets < 1)
                    {
                        ModelState.AddModelError(string.Empty, "You must choose at least 1 ticket.");
                        return View(screening);
                    }
                    else
                    {
                        _context.Update(screening);
                        _context.SaveChanges();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScreeningExists(screening.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(BookingConfirmation), new { id });
            }
            return View(screening);
        }

        public async Task<IActionResult> BookingConfirmation(int? id)
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


        private bool ScreeningExists(int id)
        {
            return _context.Screenings.Any(e => e.Id == id);
        }
    }
}
