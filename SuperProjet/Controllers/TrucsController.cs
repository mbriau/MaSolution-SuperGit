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
    public class TrucsController : ControllerBase
    {
        private readonly TrucsService _service;

        public TrucsController(TrucsService service)
        {
            _service = service;
        }

        // GET: api/Trucs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Truc>>> Get()
        {
            if (_service.GetAll() == null)
            {
                return NotFound();
            }
            return await _service.GetAll().ToListAsync();
        }

        // GET: api/Trucs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Truc>> Get(int id)
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

        // PUT: api/Trucs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Truc truc)
        {
            if (id != truc.Id)
            {
                return BadRequest();
            }
            try
            {
                _service.Update(truc);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrucExists(id))
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
        public async Task<ActionResult<Truc>> Post(Truc truc)
        {
            if (_service.GetAll() == null)
            {
                return Problem("Entity set is null.");
            }
            _service.Add(truc);
            
            return CreatedAtAction("Get", new { id = truc.Id }, truc);
        }

        // DELETE: api/Trucs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrucs(int id)
        {
            if (_service.GetAll() == null)
            {
                return NotFound();
            }
            Truc? truc = _service.Delete(id);
            
            if (truc == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        private bool TrucExists(int id)
        {
            return _service.Exists(id);
        }
    }
}
