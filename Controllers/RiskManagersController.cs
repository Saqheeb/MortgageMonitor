using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MortgageMoniteringSystem.Models;

namespace MortgageMoniteringSystem.Controllers
{
    public class RiskManagersController : Controller
    {
        private readonly RiskManagerContext _context;

        public RiskManagersController(RiskManagerContext context)
        {
            _context = context;
        }

        // GET: RiskManagers
        public async Task<IActionResult> Index()
        {
              return _context.RiskManagers != null ? 
                          View(await _context.RiskManagers.ToListAsync()) :
                          Problem("Entity set 'RiskManagerContext.RiskManagers'  is null.");
        }

        // GET: RiskManagers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RiskManagers == null)
            {
                return NotFound();
            }

            var riskManager = await _context.RiskManagers
                .FirstOrDefaultAsync(m => m.RiskManagerId == id);
            if (riskManager == null)
            {
                return NotFound();
            }

            return View(riskManager);
        }

        // GET: RiskManagers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RiskManagers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RiskManagerId,RiskManagerName,RiskManagerMail,RiskManagerPassword,RiskManagerAccess")] RiskManager riskManager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(riskManager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(riskManager);
        }

        // GET: RiskManagers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RiskManagers == null)
            {
                return NotFound();
            }

            var riskManager = await _context.RiskManagers.FindAsync(id);
            if (riskManager == null)
            {
                return NotFound();
            }
            return View(riskManager);
        }

        // POST: RiskManagers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RiskManagerId,RiskManagerName,RiskManagerMail,RiskManagerPassword,RiskManagerAccess")] RiskManager riskManager)
        {
            if (id != riskManager.RiskManagerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(riskManager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RiskManagerExists(riskManager.RiskManagerId))
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
            return View(riskManager);
        }

        // GET: RiskManagers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RiskManagers == null)
            {
                return NotFound();
            }

            var riskManager = await _context.RiskManagers
                .FirstOrDefaultAsync(m => m.RiskManagerId == id);
            if (riskManager == null)
            {
                return NotFound();
            }

            return View(riskManager);
        }

        // POST: RiskManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RiskManagers == null)
            {
                return Problem("Entity set 'RiskManagerContext.RiskManagers'  is null.");
            }
            var riskManager = await _context.RiskManagers.FindAsync(id);
            if (riskManager != null)
            {
                _context.RiskManagers.Remove(riskManager);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RiskManagerExists(int id)
        {
          return (_context.RiskManagers?.Any(e => e.RiskManagerId == id)).GetValueOrDefault();
        }

        //PATCH: RiskManagers/ToggleAccess
        [HttpPatch]
        public IActionResult ToggleAccess(int id, bool access)
        {
            Console.WriteLine();
            Console.WriteLine("patch method getting triggered!!!" + " " + id + " " + access);
            var record = _context.RiskManagers.Find(id);
            if (record != null)
            {
                if (access)
                {
                    record.RiskManagerAccess = "allow";
                }
                else
                {
                    record.RiskManagerAccess = "deny";
                }
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return UnprocessableEntity();
            }
        }
    }
}
