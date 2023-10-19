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
    public class TrucsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TrucsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Trucs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trucs>>> GetTrucs()
        {
          if (_context.Trucs == null)
          {
              return NotFound();
          }
            return await _context.Trucs.ToListAsync();
        }

        // GET: api/Trucs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trucs>> GetTrucs(int id)
        {
          if (_context.Trucs == null)
          {
              return NotFound();
          }
            var trucs = await _context.Trucs.FindAsync(id);

            if (trucs == null)
            {
                return NotFound();
            }

            return trucs;
        }

        // PUT: api/Trucs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrucs(int id, Trucs trucs)
        {
            if (id != trucs.Id)
            {
                return BadRequest();
            }

            _context.Entry(trucs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrucsExists(id))
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

        // POST: api/Trucs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trucs>> PostTrucs(Trucs trucs)
        {
          if (_context.Trucs == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Trucs'  is null.");
          }
            _context.Trucs.Add(trucs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrucs", new { id = trucs.Id }, trucs);
        }

        // DELETE: api/Trucs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrucs(int id)
        {
            if (_context.Trucs == null)
            {
                return NotFound();
            }
            var trucs = await _context.Trucs.FindAsync(id);
            if (trucs == null)
            {
                return NotFound();
            }

            _context.Trucs.Remove(trucs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrucsExists(int id)
        {
            return (_context.Trucs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
