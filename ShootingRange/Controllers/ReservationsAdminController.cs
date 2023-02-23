using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ShootingRange.Data;
using ShootingRange.Models;
using System.Security.Claims;

namespace ShootingRange.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReservationsAdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationsAdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {

            var applicationDbContext = _context.Reservations.Include(r => r.Instructors).Include(r => r.Guns);
            return View(await applicationDbContext.ToListAsync());

        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservations = await _context.Reservations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservations == null)
            {
                return NotFound();
            }

            return View(reservations);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            var instructors = _context.Instructors.ToList();
            ViewBag.Instructors = new SelectList(instructors, "Id", "Name");

            var guns = _context.Guns.ToList();
            ViewBag.Guns = new SelectList(guns, "Id", "Name");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReservationDate,UsersNumber,TrackNumber,AmmunitionNumber,InstructorsId,GunsId")] Reservations reservations)
        {
            //reservations.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                _context.Add(reservations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
          
            return View(reservations);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var instructors = _context.Instructors.ToList();
            ViewBag.Instructors = new SelectList(instructors, "Id", "Name");

            var guns = _context.Guns.ToList();
            ViewBag.Guns = new SelectList(guns, "Id", "Name");
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservations = await _context.Reservations.FindAsync(id);
            if (reservations == null)
            {
                return NotFound();
            }
            return View(reservations);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReservationDate,UsersNumber,TrackNumber,AmmunitionNumber,InstructorsId,GunsId")] Reservations reservations)
        {
            if (id != reservations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationsExists(reservations.Id))
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
            return View(reservations);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservations = await _context.Reservations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservations == null)
            {
                return NotFound();
            }

            return View(reservations);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reservations'  is null.");
            }
            var reservations = await _context.Reservations.FindAsync(id);
            if (reservations != null)
            {
                _context.Reservations.Remove(reservations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationsExists(int id)
        {
          return _context.Reservations.Any(e => e.Id == id);
        }
    }
}
