using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BizHacks.Context;
using BizHacks.Models;
using Microsoft.AspNetCore.Cors;

namespace BizHacks.Controllers
{
    [EnableCors("CorsPolicy")]
    public class SocialsController : Controller
    {
        private readonly ApiDbContext _context;

        public SocialsController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: Socials
        public async Task<IActionResult> Index()
        {
            return View(await _context.Socials.ToListAsync());
        }

        // GET: Socials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var social = await _context.Socials
                .SingleOrDefaultAsync(m => m.SocialId == id);
            if (social == null)
            {
                return NotFound();
            }

            return View(social);
        }

        // GET: Socials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Socials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SocialId,CampaignName,FiscalYear,FiscalMonth,Impressions,Clicks,CTR,Cost,Visit,TotalOnlineOrders,TotalOnlineRevenue,BounceRate")] Social social)
        {
            if (ModelState.IsValid)
            {
                _context.Add(social);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(social);
        }

        // GET: Socials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var social = await _context.Socials.SingleOrDefaultAsync(m => m.SocialId == id);
            if (social == null)
            {
                return NotFound();
            }
            return View(social);
        }

        // POST: Socials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SocialId,CampaignName,FiscalYear,FiscalMonth,Impressions,Clicks,CTR,Cost,Visit,TotalOnlineOrders,TotalOnlineRevenue,BounceRate")] Social social)
        {
            if (id != social.SocialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(social);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialExists(social.SocialId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(social);
        }

        // GET: Socials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var social = await _context.Socials
                .SingleOrDefaultAsync(m => m.SocialId == id);
            if (social == null)
            {
                return NotFound();
            }

            return View(social);
        }

        // POST: Socials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var social = await _context.Socials.SingleOrDefaultAsync(m => m.SocialId == id);
            _context.Socials.Remove(social);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialExists(int id)
        {
            return _context.Socials.Any(e => e.SocialId == id);
        }
    }
}
