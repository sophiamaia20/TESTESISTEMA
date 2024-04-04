using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testtt.Repository;
using testtt.Repository.Models;

namespace testtt.Controllers
{
    public class MotoristumsController : Controller
    {
        private readonly SistemaTesteDbContext _context = new SistemaTesteDbContext();

        
        

        // GET: Motoristums
        public async Task<IActionResult> Index()
        {
              return _context.Motorista != null ? 
                          View(await _context.Motorista.ToListAsync()) :
                          Problem("Entity set 'SistemaTesteDbContext.Motorista'  is null.");
        }

        // GET: Motoristums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Motorista == null)
            {
                return NotFound();
            }

            var motoristum = await _context.Motorista
                .FirstOrDefaultAsync(m => m.Cpf == id);
            if (motoristum == null)
            {
                return NotFound();
            }

            return View(motoristum);
        }

        // GET: Motoristums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Motoristums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cpf,NomeCompleto,CategoriaCarteira")] Motoristum motoristum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motoristum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motoristum);
        }

        // GET: Motoristums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Motorista == null)
            {
                return NotFound();
            }

            var motoristum = await _context.Motorista.FindAsync(id);
            if (motoristum == null)
            {
                return NotFound();
            }
            return View(motoristum);
        }

        // POST: Motoristums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cpf,NomeCompleto,CategoriaCarteira")] Motoristum motoristum)
        {
            if (id != motoristum.Cpf)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motoristum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotoristumExists(motoristum.Cpf))
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
            return View(motoristum);
        }

        // GET: Motoristums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Motorista == null)
            {
                return NotFound();
            }

            var motoristum = await _context.Motorista
                .FirstOrDefaultAsync(m => m.Cpf == id);
            if (motoristum == null)
            {
                return NotFound();
            }

            return View(motoristum);
        }

        // POST: Motoristums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Motorista == null)
            {
                return Problem("Entity set 'SistemaTesteDbContext.Motorista'  is null.");
            }
            var motoristum = await _context.Motorista.FindAsync(id);
            if (motoristum != null)
            {
                _context.Motorista.Remove(motoristum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotoristumExists(int id)
        {
          return (_context.Motorista?.Any(e => e.Cpf == id)).GetValueOrDefault();
        }
    }
}
