using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShootingRange.Data;
using ShootingRange.Models;

namespace ShootingRange.Controllers
{
    public class GunsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GunsController(ApplicationDbContext context)
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

    }
}
