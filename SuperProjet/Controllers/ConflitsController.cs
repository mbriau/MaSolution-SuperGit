using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperProjet.Data;
using SuperProjet.Models;

namespace SuperProjet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConflitsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ConflitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Conflits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conflit>>> GetConflit()
        {
          if (_context.Conflit == null)
          {
              return NotFound();
          }
            return await _context.Conflit.ToListAsync();
        }

        // GET: api/Conflits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conflit>> GetConflit(int id)
        {
          if (_context.Conflit == null)
          {
              return NotFound();
          }
            var conflit = await _context.Conflit.FindAsync(id);

            if (conflit == null)
            {
                return NotFound();
            }

            return conflit;
        }

        // PUT: api/Conflits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConflit(int id, Conflit conflit)
        {
            if (id != conflit.Id)
            {
                return BadRequest();
            }

            _context.Entry(conflit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConflitExists(id))
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

        // POST: api/Conflits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Conflit>> PostConflit(Conflit conflit)
        {
          if (_context.Conflit == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Conflit'  is null.");
          }
            _context.Conflit.Add(conflit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConflit", new { id = conflit.Id }, conflit);
        }

        // DELETE: api/Conflits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConflit(int id)
        {
            if (_context.Conflit == null)
            {
                return NotFound();
            }
            var conflit = await _context.Conflit.FindAsync(id);
            if (conflit == null)
            {
                return NotFound();
            }

            _context.Conflit.Remove(conflit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConflitExists(int id)
        {
            return (_context.Conflit?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
