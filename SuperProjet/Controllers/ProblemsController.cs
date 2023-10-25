using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperProjet.Data;
using SuperProjet.Models;
using SuperProjet.Services;

namespace SuperProjet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemsController : ControllerBase
    {
        private readonly ProblemsService _service;

        public ProblemsController(ProblemsService service)
        {
            _service = service;
        }

        // GET: api/Problems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Problem>>> Get()
        {
            if (_service.GetAll() == null)
            {
                return NotFound();
            }
            return await _service.GetAll().ToListAsync();
        }

        // GET: api/Problems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Problem>> Get(int id)
        {
            if (_service.GetAll() == null)
            {
                return NotFound();
            }
            var item = _service.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/Problems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Problem problem)
        {
            if (id != problem.Id)
            {
                return BadRequest();
            }
            try
            {
                _service.Update(problem);
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
        public async Task<ActionResult<Problem>> Post(Problem problem)
        {
            if (_service.GetAll() == null)
            {
                return Problem("Entity set is null.");
            }
            _service.Add(problem);
            
            return CreatedAtAction("Get", new { id = problem.Id }, problem);
        }

        // DELETE: api/Problems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProblems(int id)
        {
            if (_service.GetAll() == null)
            {
                return NotFound();
            }
            Problem? problem = _service.Delete(id);
            
            if (problem == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        private bool ProblemsExists(int id)
        {
            return _service.Exists(id);
        }
    }
}
