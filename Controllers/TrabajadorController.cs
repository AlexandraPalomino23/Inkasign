using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inkasign.Data;
using Inkasign.Models;

namespace Inkasign.Controllers
{
    public class TrabajadorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrabajadorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trabajador
       
        public async Task<IActionResult> Index()
        {
            return View(await _context.DataTrabajador.ToListAsync());
        }


        // GET: Trabajador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DataTrabajador == null)
            {
                return NotFound();
            }

            var trabajador = await _context.DataTrabajador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trabajador == null)
            {
                return NotFound();
            }

            return View(trabajador);
        }

        // GET: Trabajador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trabajador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Descripcion,Precio,ImageName,Status")] Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trabajador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trabajador);
        }
public IActionResult ElegirAccion(){
            return View();
        }
        // GET: Trabajador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DataTrabajador == null)
            {
                return NotFound();
            }

            var trabajador = await _context.DataTrabajador.FindAsync(id);
            if (trabajador == null)
            {
                return NotFound();
            }
            return View(trabajador);
        }

        // POST: Trabajador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Descripcion,Precio,ImageName,Status")] Trabajador trabajador)
        {
            if (id != trabajador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trabajador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrabajadorExists(trabajador.Id))
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
            return View(trabajador);
        }

        // GET: Trabajador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DataTrabajador == null)
            {
                return NotFound();
            }

            var trabajador = await _context.DataTrabajador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trabajador == null)
            {
                return NotFound();
            }

            return View(trabajador);
        }

        // POST: Trabajador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DataTrabajador == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DataTrabajador'  is null.");
            }
            var trabajador = await _context.DataTrabajador.FindAsync(id);
            if (trabajador != null)
            {
                _context.DataTrabajador.Remove(trabajador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrabajadorExists(int id)
        {
          return (_context.DataTrabajador?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
