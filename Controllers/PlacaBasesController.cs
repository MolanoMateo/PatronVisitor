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
    public class PlacaBasesController : Controller
    {
        private readonly PatronVisitorContext _context;

        public PlacaBasesController(PatronVisitorContext context)
        {
            _context = context;
        }

        // GET: PlacaBases
        public async Task<IActionResult> Index()
        {
              return View(await _context.PlacaBase.ToListAsync());
        }

        // GET: PlacaBases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PlacaBase == null)
            {
                return NotFound();
            }

            var placaBase = await _context.PlacaBase
                .FirstOrDefaultAsync(m => m.id == id);
            if (placaBase == null)
            {
                return NotFound();
            }

            return View(placaBase);
        }

        // GET: PlacaBases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlacaBases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Nombre,NSerie")] PlacaBase placaBase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placaBase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(placaBase);
        }

        // GET: PlacaBases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PlacaBase == null)
            {
                return NotFound();
            }

            var placaBase = await _context.PlacaBase.FindAsync(id);
            if (placaBase == null)
            {
                return NotFound();
            }
            return View(placaBase);
        }

        // POST: PlacaBases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Nombre,NSerie")] PlacaBase placaBase)
        {
            if (id != placaBase.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placaBase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacaBaseExists(placaBase.id))
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
            return View(placaBase);
        }

        // GET: PlacaBases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PlacaBase == null)
            {
                return NotFound();
            }

            var placaBase = await _context.PlacaBase
                .FirstOrDefaultAsync(m => m.id == id);
            if (placaBase == null)
            {
                return NotFound();
            }

            return View(placaBase);
        }

        // POST: PlacaBases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PlacaBase == null)
            {
                return Problem("Entity set 'PatronVisitorContext.PlacaBase'  is null.");
            }
            var placaBase = await _context.PlacaBase.FindAsync(id);
            if (placaBase != null)
            {
                _context.PlacaBase.Remove(placaBase);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlacaBaseExists(int id)
        {
          return _context.PlacaBase.Any(e => e.id == id);
        }
    }
}
