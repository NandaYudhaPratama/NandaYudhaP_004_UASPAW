using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NandaYudhaP_004_UASPAW.Models;

namespace NandaYudhaP_004_UASPAW.Controllers
{
    public class PersetujuansController : Controller
    {
        private readonly UasParkirContext _context;

        public PersetujuansController(UasParkirContext context)
        {
            _context = context;
        }

        // GET: Persetujuans
        public async Task<IActionResult> Index()
        {
            var uasParkirContext = _context.Persetujuan.Include(p => p.IdParkirNavigation);
            return View(await uasParkirContext.ToListAsync());
        }

        // GET: Persetujuans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persetujuan = await _context.Persetujuan
                .Include(p => p.IdParkirNavigation)
                .FirstOrDefaultAsync(m => m.IdParkir == id);
            if (persetujuan == null)
            {
                return NotFound();
            }

            return View(persetujuan);
        }

        // GET: Persetujuans/Create
        public IActionResult Create()
        {
            ViewData["IdParkir"] = new SelectList(_context.KendaraanMasukk, "IdParkir", "JenisKendaraan");
            return View();
        }

        // POST: Persetujuans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdParkir,Status")] Persetujuan persetujuan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persetujuan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdParkir"] = new SelectList(_context.KendaraanMasukk, "IdParkir", "JenisKendaraan", persetujuan.IdParkir);
            return View(persetujuan);
        }

        // GET: Persetujuans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persetujuan = await _context.Persetujuan.FindAsync(id);
            if (persetujuan == null)
            {
                return NotFound();
            }
            ViewData["IdParkir"] = new SelectList(_context.KendaraanMasukk, "IdParkir", "JenisKendaraan", persetujuan.IdParkir);
            return View(persetujuan);
        }

        // POST: Persetujuans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdParkir,Status")] Persetujuan persetujuan)
        {
            if (id != persetujuan.IdParkir)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persetujuan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersetujuanExists(persetujuan.IdParkir))
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
            ViewData["IdParkir"] = new SelectList(_context.KendaraanMasukk, "IdParkir", "JenisKendaraan", persetujuan.IdParkir);
            return View(persetujuan);
        }

        // GET: Persetujuans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persetujuan = await _context.Persetujuan
                .Include(p => p.IdParkirNavigation)
                .FirstOrDefaultAsync(m => m.IdParkir == id);
            if (persetujuan == null)
            {
                return NotFound();
            }

            return View(persetujuan);
        }

        // POST: Persetujuans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persetujuan = await _context.Persetujuan.FindAsync(id);
            _context.Persetujuan.Remove(persetujuan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersetujuanExists(int id)
        {
            return _context.Persetujuan.Any(e => e.IdParkir == id);
        }
    }
}
