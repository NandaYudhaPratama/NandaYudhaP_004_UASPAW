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
    public class RekapKeuntungansController : Controller
    {
        private readonly UasParkirContext _context;

        public RekapKeuntungansController(UasParkirContext context)
        {
            _context = context;
        }

        // GET: RekapKeuntungans
        public async Task<IActionResult> Index()
        {
            return View(await _context.RekapKeuntungan.ToListAsync());
        }

        // GET: RekapKeuntungans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rekapKeuntungan = await _context.RekapKeuntungan
                .FirstOrDefaultAsync(m => m.IdRekap == id);
            if (rekapKeuntungan == null)
            {
                return NotFound();
            }

            return View(rekapKeuntungan);
        }

        // GET: RekapKeuntungans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RekapKeuntungans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRekap,TotalPemasukan,Laba,Bulan")] RekapKeuntungan rekapKeuntungan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rekapKeuntungan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rekapKeuntungan);
        }

        // GET: RekapKeuntungans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rekapKeuntungan = await _context.RekapKeuntungan.FindAsync(id);
            if (rekapKeuntungan == null)
            {
                return NotFound();
            }
            return View(rekapKeuntungan);
        }

        // POST: RekapKeuntungans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRekap,TotalPemasukan,Laba,Bulan")] RekapKeuntungan rekapKeuntungan)
        {
            if (id != rekapKeuntungan.IdRekap)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rekapKeuntungan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RekapKeuntunganExists(rekapKeuntungan.IdRekap))
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
            return View(rekapKeuntungan);
        }

        // GET: RekapKeuntungans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rekapKeuntungan = await _context.RekapKeuntungan
                .FirstOrDefaultAsync(m => m.IdRekap == id);
            if (rekapKeuntungan == null)
            {
                return NotFound();
            }

            return View(rekapKeuntungan);
        }

        // POST: RekapKeuntungans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rekapKeuntungan = await _context.RekapKeuntungan.FindAsync(id);
            _context.RekapKeuntungan.Remove(rekapKeuntungan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RekapKeuntunganExists(int id)
        {
            return _context.RekapKeuntungan.Any(e => e.IdRekap == id);
        }
    }
}
