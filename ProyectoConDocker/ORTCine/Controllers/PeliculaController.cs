using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ORTCine.Context;
using ORTCine.Migrations;
using ORTCine.Models;

namespace ORTCine.Controllers
{
    public class PeliculaController : Controller
    {
        private readonly ORTCineDBContext _context;

        public PeliculaController(ORTCineDBContext context)
        {
            _context = context;
        }

        // GET: Pelicula
        public async Task<IActionResult> Index(string id)
        {
            var peliculas = from m in _context.Pelicula
                            select m;

            if (!String.IsNullOrEmpty(id))
            {
                peliculas = peliculas.Where(s => s.nombre!.Contains(id));
            }


            return View(await peliculas.Include(e => e.sala).ToListAsync());



        }

        // GET: Pelicula/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Pelicula
                .Include(p => p.sala)
                .FirstOrDefaultAsync(m => m.peliculaID == id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        // GET: Pelicula/Create
        public IActionResult Create()
        {
            ViewData["salaId"] = new SelectList(_context.Sala, "salaID", "salaID");
            return View();
        }

        // POST: Pelicula/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("peliculaID,nombre,genero,estaDoblada,esAtp,salaId")] Pelicula pelicula)
        {
            var peliculas = _context.Pelicula.Where(e => e.nombre.Equals(pelicula.nombre)).ToList();

            if (peliculas.Count > 0)
            {
                ModelState.AddModelError("", "Ya existe una pelicula con ese nombre");
            }
            if (ModelState.IsValid)
            {
                _context.Add(pelicula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["salaId"] = new SelectList(_context.Sala, "salaID", "numeroSala", pelicula.salaId);
            return View(pelicula);
        }

        // GET: Pelicula/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Pelicula.FindAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            ViewData["salaId"] = new SelectList(_context.Sala, "salaID", "salaID", pelicula.salaId);
            return View(pelicula);
        }

        // POST: Pelicula/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("peliculaID,nombre,genero,estaDoblada,esAtp,salaId")] Pelicula pelicula)
        {
            if (id != pelicula.peliculaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pelicula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeliculaExists(pelicula.peliculaID))
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
            ViewData["salaId"] = new SelectList(_context.Sala, "salaID", "salaID", pelicula.salaId);
            return View(pelicula);
        }

        // GET: Pelicula/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Pelicula
                .Include(p => p.sala)
                .FirstOrDefaultAsync(m => m.peliculaID == id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        // POST: Pelicula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pelicula = await _context.Pelicula.FindAsync(id);
            _context.Pelicula.Remove(pelicula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeliculaExists(int id)
        {
            return _context.Pelicula.Any(e => e.peliculaID == id);
        }
    }
}
