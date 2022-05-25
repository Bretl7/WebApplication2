using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class BotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bots
        public async Task<IActionResult> Index()
        {
              return _context.Bots != null ? 
                          View(await _context.Bots.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Bots'  is null.");
        }

        // GET: Bots/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Bots == null)
            {
                return NotFound();
            }

            var bot = await _context.Bots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bot == null)
            {
                return NotFound();
            }

            return View(bot);
        }

        // GET: Bots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Power,Level")] Bot bot)
        {
            if (ModelState.IsValid)
            {
                bot.Id = Guid.NewGuid();
                _context.Add(bot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bot);
        }

        // GET: Bots/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Bots == null)
            {
                return NotFound();
            }

            var bot = await _context.Bots.FindAsync(id);
            if (bot == null)
            {
                return NotFound();
            }
            return View(bot);
        }

        // POST: Bots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Email,Power,Level")] Bot bot)
        {
            if (id != bot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BotExists(bot.Id))
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
            return View(bot);
        }

        // GET: Bots/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Bots == null)
            {
                return NotFound();
            }

            var bot = await _context.Bots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bot == null)
            {
                return NotFound();
            }

            return View(bot);
        }

        // POST: Bots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Bots == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Bots'  is null.");
            }
            var bot = await _context.Bots.FindAsync(id);
            if (bot != null)
            {
                _context.Bots.Remove(bot);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BotExists(Guid id)
        {
          return (_context.Bots?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
