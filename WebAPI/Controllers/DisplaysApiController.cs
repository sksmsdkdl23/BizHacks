using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BizHacks.Context;
using BizHacks.Models;
using Microsoft.AspNetCore.Cors;

namespace BizHacks.Controllers
{
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("api/DisplaysApi")]
    public class DisplaysApiController : Controller
    {
        private readonly ApiDbContext _context;

        public DisplaysApiController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/DisplaysApi
        [HttpGet]
        public IEnumerable<Display> GetDisplays()
        {
            return _context.Displays;
        }

        // GET: api/DisplaysApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDisplay([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var display = await _context.Displays.SingleOrDefaultAsync(m => m.DisplayId == id);

            if (display == null)
            {
                return NotFound();
            }

            return Ok(display);
        }

        // PUT: api/DisplaysApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisplay([FromRoute] int id, [FromBody] Display display)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != display.DisplayId)
            {
                return BadRequest();
            }

            _context.Entry(display).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisplayExists(id))
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

        // POST: api/DisplaysApi
        [HttpPost]
        public async Task<IActionResult> PostDisplay([FromBody] Display display)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Displays.Add(display);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDisplay", new { id = display.DisplayId }, display);
        }

        // DELETE: api/DisplaysApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisplay([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var display = await _context.Displays.SingleOrDefaultAsync(m => m.DisplayId == id);
            if (display == null)
            {
                return NotFound();
            }

            _context.Displays.Remove(display);
            await _context.SaveChangesAsync();

            return Ok(display);
        }

        private bool DisplayExists(int id)
        {
            return _context.Displays.Any(e => e.DisplayId == id);
        }
    }
}