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
    public class KendaraanMasukksController : Controller
    {
        private readonly UasParkirContext _context;

        public KendaraanMasukksController(UasParkirContext context)
        {
            _context = context;
        }

        // GET: KendaraanMasukks
        public async Task<IActionResult> Index()
        {
            return View(await _context.KendaraanMasukk.ToListAsync());
        }

        // GET: KendaraanMasukks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kendaraanMasukk = await _context.KendaraanMasukk
                .FirstOrDefaultAsync(m => m.IdParkir == id);
            if (kendaraanMasukk == null)
            {
                return NotFound();
            }

            return View(kendaraanMasukk);
        }

        // GET: KendaraanMasukks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KendaraanMasukks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdParkir,NoPolisi,JenisKendaraan")] KendaraanMasukk kendaraanMasukk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kendaraanMasukk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kendaraanMasukk);
        }

        // GET: KendaraanMasukks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kendaraanMasukk = await _context.KendaraanMasukk.FindAsync(id);
            if (kendaraanMasukk == null)
            {
                return NotFound();
            }
            return View(kendaraanMasukk);
        }

        // POST: KendaraanMasukks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdParkir,NoPolisi,JenisKendaraan")] KendaraanMasukk kendaraanMasukk)
        {
            if (id != kendaraanMasukk.IdParkir)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kendaraanMasukk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KendaraanMasukkExists(kendaraanMasukk.IdParkir))
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
            return View(kendaraanMasukk);
        }

        // GET: KendaraanMasukks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kendaraanMasukk = await _context.KendaraanMasukk
                .FirstOrDefaultAsync(m => m.IdParkir == id);
            if (kendaraanMasukk == null)
            {
                return NotFound();
            }

            return View(kendaraanMasukk);
        }

        // POST: KendaraanMasukks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kendaraanMasukk = await _context.KendaraanMasukk.FindAsync(id);
            _context.KendaraanMasukk.Remove(kendaraanMasukk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KendaraanMasukkExists(int id)
        {
            return _context.KendaraanMasukk.Any(e => e.IdParkir == id);
        }
    }
}
