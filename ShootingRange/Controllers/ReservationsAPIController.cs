using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShootingRange.Data;
using ShootingRange.Models;

namespace ShootingRange.Controllers
{
    [Route("api/Reservations")]
    [ApiController]
    public class ReservationsAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReservationsAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ReservationsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservations>>> GetReservations()
        {
            return await _context.Reservations.ToListAsync();
        }

        // GET: api/ReservationsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservations>> GetReservations(int id)
        {
            var reservations = await _context.Reservations.FindAsync(id);

            if (reservations == null)
            {
                return NotFound();
            }

            return reservations;
        }

        // PUT: api/ReservationsAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservations(int id, Reservations reservations)
        {
            if (id != reservations.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ReservationsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reservations>> PostReservations(Reservations reservations)
        {
            _context.Reservations.Add(reservations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservations", new { id = reservations.Id }, reservations);
        }

        // DELETE: api/ReservationsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservations(int id)
        {
            var reservations = await _context.Reservations.FindAsync(id);
            if (reservations == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(reservations);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservationsExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }
    }
}
