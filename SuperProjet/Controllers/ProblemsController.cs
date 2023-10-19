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
    public class ProblemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProblemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Problems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Problems>>> GetProblems()
        {
          if (_context.Problems == null)
          {
              return NotFound();
          }
            return await _context.Problems.ToListAsync();
        }

        // GET: api/Problems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Problems>> GetProblems(int id)
        {
          if (_context.Problems == null)
          {
              return NotFound();
          }
            var problems = await _context.Problems.FindAsync(id);

            if (problems == null)
            {
                return NotFound();
            }

            return problems;
        }

        // PUT: api/Problems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProblems(int id, Problems problems)
        {
            if (id != problems.Id)
            {
                return BadRequest();
            }

            _context.Entry(problems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProblemsExists(id))
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

        // POST: api/Problems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Problems>> PostProblems(Problems problems)
        {
          if (_context.Problems == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Problems'  is null.");
          }
            _context.Problems.Add(problems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProblems", new { id = problems.Id }, problems);
        }

        // DELETE: api/Problems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProblems(int id)
        {
            if (_context.Problems == null)
            {
                return NotFound();
            }
            var problems = await _context.Problems.FindAsync(id);
            if (problems == null)
            {
                return NotFound();
            }

            _context.Problems.Remove(problems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProblemsExists(int id)
        {
            return (_context.Problems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
