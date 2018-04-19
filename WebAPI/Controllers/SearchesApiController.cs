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
    [Route("api/SearchesApi")]
    public class SearchesApiController : Controller
    {
        private readonly ApiDbContext _context;

        public SearchesApiController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/SearchesApi
        [HttpGet]
        public IEnumerable<Search> GetSearches()
        {
            return _context.Searches;
        }

        // GET: api/SearchesApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSearch([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var search = await _context.Searches.SingleOrDefaultAsync(m => m.SearchId == id);

            if (search == null)
            {
                return NotFound();
            }

            return Ok(search);
        }

        // PUT: api/SearchesApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSearch([FromRoute] int id, [FromBody] Search search)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != search.SearchId)
            {
                return BadRequest();
            }

            _context.Entry(search).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SearchExists(id))
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

        // POST: api/SearchesApi
        [HttpPost]
        public async Task<IActionResult> PostSearch([FromBody] Search search)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Searches.Add(search);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSearch", new { id = search.SearchId }, search);
        }

        // DELETE: api/SearchesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSearch([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var search = await _context.Searches.SingleOrDefaultAsync(m => m.SearchId == id);
            if (search == null)
            {
                return NotFound();
            }

            _context.Searches.Remove(search);
            await _context.SaveChangesAsync();

            return Ok(search);
        }

        private bool SearchExists(int id)
        {
            return _context.Searches.Any(e => e.SearchId == id);
        }
    }
}