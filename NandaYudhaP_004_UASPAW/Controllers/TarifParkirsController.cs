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
    public class TarifParkirsController : Controller
    {
        private readonly UasParkirContext _context;

        public TarifParkirsController(UasParkirContext context)
        {
            _context = context;
        }

        // GET: TarifParkirs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TarifParkir.ToListAsync());
        }

        // GET: TarifParkirs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarifParkir = await _context.TarifParkir
                .FirstOrDefaultAsync(m => m.IdTarif == id);
            if (tarifParkir == null)
            {
                return NotFound();
            }

            return View(tarifParkir);
        }

        // GET: TarifParkirs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TarifParkirs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTarif,JenisKendaraan,Harga")] TarifParkir tarifParkir)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarifParkir);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarifParkir);
        }

        // GET: TarifParkirs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarifParkir = await _context.TarifParkir.FindAsync(id);
            if (tarifParkir == null)
            {
                return NotFound();
            }
            return View(tarifParkir);
        }

        // POST: TarifParkirs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTarif,JenisKendaraan,Harga")] TarifParkir tarifParkir)
        {
            if (id != tarifParkir.IdTarif)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarifParkir);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarifParkirExists(tarifParkir.IdTarif))
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
            return View(tarifParkir);
        }

        // GET: TarifParkirs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarifParkir = await _context.TarifParkir
                .FirstOrDefaultAsync(m => m.IdTarif == id);
            if (tarifParkir == null)
            {
                return NotFound();
            }

            return View(tarifParkir);
        }

        // POST: TarifParkirs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarifParkir = await _context.TarifParkir.FindAsync(id);
            _context.TarifParkir.Remove(tarifParkir);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarifParkirExists(int id)
        {
            return _context.TarifParkir.Any(e => e.IdTarif == id);
        }
    }
}
