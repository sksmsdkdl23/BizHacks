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
    public class DisplaysController : Controller
    {
        private readonly ApiDbContext _context;

        public DisplaysController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: Displays
        public async Task<IActionResult> Index()
        {
            return View(await _context.Displays.ToListAsync());
        }

        // GET: Displays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var display = await _context.Displays
                .SingleOrDefaultAsync(m => m.DisplayId == id);
            if (display == null)
            {
                return NotFound();
            }

            return View(display);
        }

        // GET: Displays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Displays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DisplayId,CampaignName,FiscalYear,FiscalMonth,Impressions,Clicks,CTR,Cost,Visit,TotalOnlineOrders,TotalOnlineRevenue,BounceRate")] Display display)
        {
            if (ModelState.IsValid)
            {
                _context.Add(display);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(display);
        }

        // GET: Displays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var display = await _context.Displays.SingleOrDefaultAsync(m => m.DisplayId == id);
            if (display == null)
            {
                return NotFound();
            }
            return View(display);
        }

        // POST: Displays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DisplayId,CampaignName,FiscalYear,FiscalMonth,Impressions,Clicks,CTR,Cost,Visit,TotalOnlineOrders,TotalOnlineRevenue,BounceRate")] Display display)
        {
            if (id != display.DisplayId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(display);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisplayExists(display.DisplayId))
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
            return View(display);
        }

        // GET: Displays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var display = await _context.Displays
                .SingleOrDefaultAsync(m => m.DisplayId == id);
            if (display == null)
            {
                return NotFound();
            }

            return View(display);
        }

        // POST: Displays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var display = await _context.Displays.SingleOrDefaultAsync(m => m.DisplayId == id);
            _context.Displays.Remove(display);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisplayExists(int id)
        {
            return _context.Displays.Any(e => e.DisplayId == id);
        }
    }
}
