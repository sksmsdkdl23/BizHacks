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
    [Route("api/SocialsApi")]
    public class SocialsApiController : Controller
    {
        private readonly ApiDbContext _context;

        public SocialsApiController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/SocialsApi
        [HttpGet]
        public IEnumerable<Social> GetSocials()
        {
            return _context.Socials;
        }

        // GET: api/SocialsApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocial([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var social = await _context.Socials.SingleOrDefaultAsync(m => m.SocialId == id);

            if (social == null)
            {
                return NotFound();
            }

            return Ok(social);
        }

        // PUT: api/SocialsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSocial([FromRoute] int id, [FromBody] Social social)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != social.SocialId)
            {
                return BadRequest();
            }

            _context.Entry(social).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocialExists(id))
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

        // POST: api/SocialsApi
        [HttpPost]
        public async Task<IActionResult> PostSocial([FromBody] Social social)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Socials.Add(social);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSocial", new { id = social.SocialId }, social);
        }

        // DELETE: api/SocialsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocial([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var social = await _context.Socials.SingleOrDefaultAsync(m => m.SocialId == id);
            if (social == null)
            {
                return NotFound();
            }

            _context.Socials.Remove(social);
            await _context.SaveChangesAsync();

            return Ok(social);
        }

        private bool SocialExists(int id)
        {
            return _context.Socials.Any(e => e.SocialId == id);
        }
    }
}