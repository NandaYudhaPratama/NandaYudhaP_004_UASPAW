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
    public class KendaraanKeluarsController : Controller
    {
        private readonly UasParkirContext _context;

        public KendaraanKeluarsController(UasParkirContext context)
        {
            _context = context;
        }

        // GET: KendaraanKeluars
        public async Task<IActionResult> Index()
        {
            var uasParkirContext = _context.KendaraanKeluar.Include(k => k.IdParkirNavigation);
            return View(await uasParkirContext.ToListAsync());
        }

        // GET: KendaraanKeluars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kendaraanKeluar = await _context.KendaraanKeluar
                .Include(k => k.IdParkirNavigation)
                .FirstOrDefaultAsync(m => m.IdParkir == id);
            if (kendaraanKeluar == null)
            {
                return NotFound();
            }

            return View(kendaraanKeluar);
        }

        // GET: KendaraanKeluars/Create
        public IActionResult Create()
        {
            ViewData["IdParkir"] = new SelectList(_context.Persetujuan, "IdParkir", "IdParkir");
            return View();
        }

        // POST: KendaraanKeluars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdParkir,NoPolisi,Tarif")] KendaraanKeluar kendaraanKeluar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kendaraanKeluar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdParkir"] = new SelectList(_context.Persetujuan, "IdParkir", "IdParkir", kendaraanKeluar.IdParkir);
            return View(kendaraanKeluar);
        }

        // GET: KendaraanKeluars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kendaraanKeluar = await _context.KendaraanKeluar.FindAsync(id);
            if (kendaraanKeluar == null)
            {
                return NotFound();
            }
            ViewData["IdParkir"] = new SelectList(_context.Persetujuan, "IdParkir", "IdParkir", kendaraanKeluar.IdParkir);
            return View(kendaraanKeluar);
        }

        // POST: KendaraanKeluars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdParkir,NoPolisi,Tarif")] KendaraanKeluar kendaraanKeluar)
        {
            if (id != kendaraanKeluar.IdParkir)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kendaraanKeluar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KendaraanKeluarExists(kendaraanKeluar.IdParkir))
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
            ViewData["IdParkir"] = new SelectList(_context.Persetujuan, "IdParkir", "IdParkir", kendaraanKeluar.IdParkir);
            return View(kendaraanKeluar);
        }

        // GET: KendaraanKeluars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kendaraanKeluar = await _context.KendaraanKeluar
                .Include(k => k.IdParkirNavigation)
                .FirstOrDefaultAsync(m => m.IdParkir == id);
            if (kendaraanKeluar == null)
            {
                return NotFound();
            }

            return View(kendaraanKeluar);
        }

        // POST: KendaraanKeluars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kendaraanKeluar = await _context.KendaraanKeluar.FindAsync(id);
            _context.KendaraanKeluar.Remove(kendaraanKeluar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KendaraanKeluarExists(int id)
        {
            return _context.KendaraanKeluar.Any(e => e.IdParkir == id);
        }
    }
}
