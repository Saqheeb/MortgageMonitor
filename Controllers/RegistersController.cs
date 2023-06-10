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
    public class RegistersController : Controller
    {
        private readonly RiskManagerContext _context;

        public RegistersController(RiskManagerContext context)
        {
            _context = context;
        }

        // GET: Registers
        public async Task<IActionResult> Index()
        {
              return _context.Registers != null ? 
                          View(await _context.Registers.ToListAsync()) :
                          Problem("Entity set 'RiskManagerContext.Registers'  is null.");
        }

        // GET: Registers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Registers == null)
            {
                return NotFound();
            }

            var register = await _context.Registers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // GET: Registers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Username,UserPassword,Access")] Register register)
        {
            if (ModelState.IsValid)
            {
                _context.Add(register);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(register);
        }

        // GET: Registers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Registers == null)
            {
                return NotFound();
            }

            var register = await _context.Registers.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }
            return View(register);
        }

        // POST: Registers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Username,UserPassword,Access")] Register register)
        {
            if (id != register.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(register);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterExists(register.Id))
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
            return View(register);
        }

        // GET: Registers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Registers == null)
            {
                return NotFound();
            }

            var register = await _context.Registers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // POST: Registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Registers == null)
            {
                return Problem("Entity set 'RiskManagerContext.Registers'  is null.");
            }
            var register = await _context.Registers.FindAsync(id);
            if (register != null)
            {
                _context.Registers.Remove(register);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterExists(int id)
        {
          return (_context.Registers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        //PATCH: Registers/ToggleAccess
        [HttpPatch]
        public IActionResult ToggleAccess(int id, bool access)
        {
            Console.WriteLine();
            Console.WriteLine("patch method getting triggered!!!" + " " + id + " " + access);
            var record = _context.Registers.Find(id);//
            Console.WriteLine(record.Access);
            if (record != null)
            {
                if (access)
                {
                    record.Access = "allow";
                }
                else
                {
                    record.Access = "deny";
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
