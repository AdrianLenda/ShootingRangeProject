using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShootingRange.Data;
using ShootingRange.Models;

namespace ShootingRange.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GunsAdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GunsAdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Guns
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Guns.Include(g => g.Manufacturer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Guns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Guns == null)
            {
                return NotFound();
            }

            var guns = await _context.Guns
                .Include(g => g.Manufacturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guns == null)
            {
                return NotFound();
            }

            return View(guns);
        }

        // GET: Guns/Create
        public IActionResult Create()
        {
            var manufacturers = _context.Manufacturers.ToList();
            ViewBag.Manufacturers = new SelectList(manufacturers, "Id", "Name");
            return View();
        }

        // POST: Guns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Name,Description,ProductionDate,SerialNumber,ManufacturerId")] Guns guns)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guns);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ManufacturerId"] = new SelectList(_context.Set<Manufacturers>(), "Id", "Country", guns.ManufacturerId);
            return View(guns);
        }

        // GET: Guns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var manufacturers = _context.Manufacturers.ToList();
            ViewBag.Manufacturers = new SelectList(manufacturers, "Id", "Name");
            if (id == null || _context.Guns == null)
            {
                return NotFound();
            }

            var guns = await _context.Guns.FindAsync(id);
            if (guns == null)
            {
                return NotFound();
            }
            ViewData["ManufacturerId"] = new SelectList(_context.Set<Manufacturers>(), "Id", "Country", guns.ManufacturerId);
            return View(guns);
        }

        // POST: Guns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Name,Description,ProductionDate,SerialNumber,ManufacturerId")] Guns guns)
        {
            if (id != guns.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guns);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GunsExists(guns.Id))
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
            ViewData["ManufacturerId"] = new SelectList(_context.Set<Manufacturers>(), "Id", "Country", guns.ManufacturerId);
            return View(guns);
        }

        // GET: Guns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Guns == null)
            {
                return NotFound();
            }

            var guns = await _context.Guns
                .Include(g => g.Manufacturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guns == null)
            {
                return NotFound();
            }

            return View(guns);
        }

        // POST: Guns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Guns == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Guns'  is null.");
            }
            var guns = await _context.Guns.FindAsync(id);
            if (guns != null)
            {
                _context.Guns.Remove(guns);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GunsExists(int id)
        {
          return _context.Guns.Any(e => e.Id == id);
        }
    }
}
