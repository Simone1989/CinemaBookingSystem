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
                    screeningSort = screeningSort.OrderBy(s => s.BookedSeats);
                    break;
                case "seats_desc":
                    screeningSort = screeningSort.OrderByDescending(s => s.BookedSeats);
                    break;
                default:
                    screeningSort = screeningSort.OrderBy(s => s.Time);
                    break; 
            }

            //ScreeningAuditoriumVM screenVM =  new ScreeningAuditoriumVM();
            //screenVM.Screenings = _context.Screenings.ToList();
            //screenVM.Auditoriums = 

            // För att ta med info från både screening och auditorium i listan
            //var screenings = _context.Screenings
            //    .Include(s => s.Auditorium)
            //    .AsNoTracking();

            // Hitta ett sätt att returna både screenings och screeningSort. 
            /*await screeningSort.AsNoTracking().ToListAsync()*/
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
                .SingleOrDefaultAsync(m => m.Id == id);
            if (screening == null)
            {
                return NotFound();
            }

            return View(screening);
        }

        //POST: Screenings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookedSeats")] Screening screening)
        {
            if (id != screening.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(screening);
                    await _context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
            }
            return View(screening);
        }

        private bool ScreeningExists(int id)
        {
            return _context.Screenings.Any(e => e.Id == id);
        }

        // GET: Screenings/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Screenings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Title,Time")] Screening screening)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(screening);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(screening);
        //}

        // GET: Screenings/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var screening = await _context.Screenings.SingleOrDefaultAsync(m => m.Id == id);
        //    if (screening == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(screening);
        //}

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

        //// GET: Screenings/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var screening = await _context.Screenings
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (screening == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(screening);
        //}

        //// POST: Screenings/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var screening = await _context.Screenings.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.Screenings.Remove(screening);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ScreeningExists(int id)
        //{
        //    return _context.Screenings.Any(e => e.Id == id);
        //}
    }
}
