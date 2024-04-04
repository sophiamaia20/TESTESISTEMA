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
    public class OrdemServiçoController : Controller
    {
        private readonly SistemaTesteDbContext _context = new SistemaTesteDbContext(); 

       

        // GET: OrdemServiço
        public async Task<IActionResult> Index()
        {
            var sistemaTesteDbContext = _context.OrdemServiços.Include(o => o.MotoristaCpfNavigation);
            return View(await sistemaTesteDbContext.ToListAsync());
        }

        // GET: OrdemServiço/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrdemServiços == null)
            {
                return NotFound();
            }

            var ordemServiço = await _context.OrdemServiços
                .Include(o => o.MotoristaCpfNavigation)
                .FirstOrDefaultAsync(m => m.OrdemId == id);
            if (ordemServiço == null)
            {
                return NotFound();
            }

            return View(ordemServiço);
        }

        // GET: OrdemServiço/Create
        public IActionResult Create()
        {
            ViewData["MotoristaCpf"] = new SelectList(_context.Motorista, "Cpf", "Cpf");
            return View();
        }

        // POST: OrdemServiço/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrdemId,MotoristaCpf,Dataservico,QuantidadeCombustivel,Servicodesc")] OrdemServiço ordemServiço)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordemServiço);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MotoristaCpf"] = new SelectList(_context.Motorista, "Cpf", "Cpf", ordemServiço.MotoristaCpf);
            return View(ordemServiço);
        }

        // GET: OrdemServiço/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrdemServiços == null)
            {
                return NotFound();
            }

            var ordemServiço = await _context.OrdemServiços.FindAsync(id);
            if (ordemServiço == null)
            {
                return NotFound();
            }
            ViewData["MotoristaCpf"] = new SelectList(_context.Motorista, "Cpf", "Cpf", ordemServiço.MotoristaCpf);
            return View(ordemServiço);
        }

        // POST: OrdemServiço/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrdemId,MotoristaCpf,Dataservico,QuantidadeCombustivel,Servicodesc")] OrdemServiço ordemServiço)
        {
            if (id != ordemServiço.OrdemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordemServiço);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdemServiçoExists(ordemServiço.OrdemId))
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
            ViewData["MotoristaCpf"] = new SelectList(_context.Motorista, "Cpf", "Cpf", ordemServiço.MotoristaCpf);
            return View(ordemServiço);
        }

        // GET: OrdemServiço/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrdemServiços == null)
            {
                return NotFound();
            }

            var ordemServiço = await _context.OrdemServiços
                .Include(o => o.MotoristaCpfNavigation)
                .FirstOrDefaultAsync(m => m.OrdemId == id);
            if (ordemServiço == null)
            {
                return NotFound();
            }

            return View(ordemServiço);
        }

        // POST: OrdemServiço/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrdemServiços == null)
            {
                return Problem("Entity set 'SistemaTesteDbContext.OrdemServiços'  is null.");
            }
            var ordemServiço = await _context.OrdemServiços.FindAsync(id);
            if (ordemServiço != null)
            {
                _context.OrdemServiços.Remove(ordemServiço);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdemServiçoExists(int id)
        {
          return (_context.OrdemServiços?.Any(e => e.OrdemId == id)).GetValueOrDefault();
        }
    }
}
