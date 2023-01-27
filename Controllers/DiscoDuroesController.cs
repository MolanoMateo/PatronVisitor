using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PatronVisitor.Data;
using PatronVisitor.Models;

namespace PatronVisitor.Controllers
{
    public class DiscoDuroesController : Controller
    {
        private readonly PatronVisitorContext _context;

        public DiscoDuroesController(PatronVisitorContext context)
        {
            _context = context;
        }

        // GET: DiscoDuroes
        public async Task<IActionResult> Index()
        {
              return View(await _context.DiscoDuro.ToListAsync());
        }

        // GET: DiscoDuroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DiscoDuro == null)
            {
                return NotFound();
            }

            var discoDuro = await _context.DiscoDuro
                .FirstOrDefaultAsync(m => m.id == id);
            if (discoDuro == null)
            {
                return NotFound();
            }

            return View(discoDuro);
        }

        // GET: DiscoDuroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DiscoDuroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Nombre,NSerie")] DiscoDuro discoDuro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(discoDuro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(discoDuro);
        }

        // GET: DiscoDuroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DiscoDuro == null)
            {
                return NotFound();
            }

            var discoDuro = await _context.DiscoDuro.FindAsync(id);
            if (discoDuro == null)
            {
                return NotFound();
            }
            return View(discoDuro);
        }

        // POST: DiscoDuroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Nombre,NSerie")] DiscoDuro discoDuro)
        {
            if (id != discoDuro.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discoDuro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscoDuroExists(discoDuro.id))
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
            return View(discoDuro);
        }

        // GET: DiscoDuroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DiscoDuro == null)
            {
                return NotFound();
            }

            var discoDuro = await _context.DiscoDuro
                .FirstOrDefaultAsync(m => m.id == id);
            if (discoDuro == null)
            {
                return NotFound();
            }

            return View(discoDuro);
        }

        // POST: DiscoDuroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DiscoDuro == null)
            {
                return Problem("Entity set 'PatronVisitorContext.DiscoDuro'  is null.");
            }
            var discoDuro = await _context.DiscoDuro.FindAsync(id);
            if (discoDuro != null)
            {
                _context.DiscoDuro.Remove(discoDuro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiscoDuroExists(int id)
        {
          return _context.DiscoDuro.Any(e => e.id == id);
        }
    }
}
