using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ORTCine.Context;
using ORTCine.Models;

namespace ORTCine.Controllers
{
    public class EntradaController : Controller
    {
        private readonly ORTCineDBContext _context;

        public EntradaController(ORTCineDBContext context)
        {
            _context = context;
        }

        // GET: Entrada
        public async Task<IActionResult> Index()
        {
            var oRTCineDBContext = _context.Entrada.Include(e => e.cliente).Include(e => e.pelicula).Include(e => e.sala);
            return View(await oRTCineDBContext.ToListAsync());
        }

        // GET: Entrada/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrada = await _context.Entrada
                .Include(e => e.cliente)
                .Include(e => e.pelicula)
                .Include(e => e.sala)
                .FirstOrDefaultAsync(m => m.entradaID == id);
            if (entrada == null)
            {
                return NotFound();
            }

            return View(entrada);
        }

        // GET: Entrada/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "apellido");
            ViewData["PeliculaId"] = new SelectList(_context.Pelicula, "peliculaID", "nombre");
            //ViewData["salaId"] = new SelectList(_context.Sala, "salaID", "salaID");
            return View();
        }

        // POST: Entrada/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("entradaID,numeroButaca,PeliculaId,ClienteId")] Entrada entrada)
        { 
            var pelicula = _context.Pelicula.FirstOrDefault(e => e.peliculaID == entrada.PeliculaId);
            entrada.salaId = pelicula.salaId;
            var entradas = _context.Entrada.Where(e => e.numeroButaca == entrada.numeroButaca).ToList();
           
            if (entradas.Count > 0)
            {
                ModelState.AddModelError("", "La butaca ya ha sido seleccionada por otro usuario");
            }
           
            
            if (ModelState.IsValid)
            {
                _context.Add(entrada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "apellido", entrada.ClienteId);
            ViewData["PeliculaId"] = new SelectList(_context.Pelicula, "peliculaID", "nombre", entrada.PeliculaId);
            ViewData["salaId"] = new SelectList(_context.Sala, "salaID", "salaID", entrada.salaId);
            return View(entrada);
        }

        // GET: Entrada/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrada = await _context.Entrada.FindAsync(id);
            if (entrada == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "apellido", entrada.ClienteId);
            ViewData["PeliculaId"] = new SelectList(_context.Pelicula, "peliculaID", "nombre", entrada.PeliculaId);
            ViewData["salaId"] = new SelectList(_context.Sala, "salaID", "salaID", entrada.salaId);
            return View(entrada);
        }

        // POST: Entrada/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("entradaID,numeroButaca,PeliculaId,ClienteId,salaId")] Entrada entrada)
        {
            if (id != entrada.entradaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entrada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntradaExists(entrada.entradaID))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "apellido", entrada.ClienteId);
            ViewData["PeliculaId"] = new SelectList(_context.Pelicula, "peliculaID", "nombre", entrada.PeliculaId);
            ViewData["salaId"] = new SelectList(_context.Sala, "salaID", "salaID", entrada.salaId);
            return View(entrada);
        }

        // GET: Entrada/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrada = await _context.Entrada
                .Include(e => e.cliente)
                .Include(e => e.pelicula)
                .Include(e => e.sala)
                .FirstOrDefaultAsync(m => m.entradaID == id);
            if (entrada == null)
            {
                return NotFound();
            }

            return View(entrada);
        }

        // POST: Entrada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entrada = await _context.Entrada.FindAsync(id);
            _context.Entrada.Remove(entrada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntradaExists(int id)
        {
            return _context.Entrada.Any(e => e.entradaID == id);
        }
    }
}
