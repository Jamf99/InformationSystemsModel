using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibreriaParciales;
using TallerParciales.Data;

namespace TallerParciales.Controllers
{
    public class ParcialesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParcialesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Parciales
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Parcial.Include(p => p.Curso).Include(p => p.Estudiante);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Parciales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcial = await _context.Parcial
                .Include(p => p.Curso)
                .Include(p => p.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parcial == null)
            {
                return NotFound();
            }

            return View(parcial);
        }

        // GET: Parciales/Create
        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_context.Set<Curso>(), "Id", "Profesor");
            ViewData["EstudianteId"] = new SelectList(_context.Estudiante, "Id", "Email");
            return View();
        }

        // POST: Parciales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Número,Fecha,Nota,Porcentaje,EstudianteId,CursoId")] Parcial parcial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parcial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.Set<Curso>(), "Id", "Profesor", parcial.CursoId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiante, "Id", "Email", parcial.EstudianteId);
            return View(parcial);
        }

        // GET: Parciales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcial = await _context.Parcial.FindAsync(id);
            if (parcial == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Set<Curso>(), "Id", "Profesor", parcial.CursoId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiante, "Id", "Email", parcial.EstudianteId);
            return View(parcial);
        }

        // POST: Parciales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Número,Fecha,Nota,Porcentaje,EstudianteId,CursoId")] Parcial parcial)
        {
            if (id != parcial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parcial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParcialExists(parcial.Id))
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
            ViewData["CursoId"] = new SelectList(_context.Set<Curso>(), "Id", "Profesor", parcial.CursoId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiante, "Id", "Email", parcial.EstudianteId);
            return View(parcial);
        }

        // GET: Parciales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcial = await _context.Parcial
                .Include(p => p.Curso)
                .Include(p => p.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parcial == null)
            {
                return NotFound();
            }

            return View(parcial);
        }

        // POST: Parciales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parcial = await _context.Parcial.FindAsync(id);
            _context.Parcial.Remove(parcial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParcialExists(int id)
        {
            return _context.Parcial.Any(e => e.Id == id);
        }
    }
}
