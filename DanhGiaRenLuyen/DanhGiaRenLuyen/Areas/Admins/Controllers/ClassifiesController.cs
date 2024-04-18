using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DanhGiaRenLuyen.Models.DBModel;

namespace DanhGiaRenLuyen.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class ClassifiesController : BaseController
    {
        private readonly DanhGiaRenLuyenContext _context;

        public ClassifiesController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }

        // GET: Admins/Classifies
        public async Task<IActionResult> Index()
        {
              return _context.Classifies != null ? 
                          View(await _context.Classifies.ToListAsync()) :
                          Problem("Entity set 'DanhGiaRenLuyenContext.Classifies'  is null.");
        }

        // GET: Admins/Classifies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Classifies == null)
            {
                return NotFound();
            }

            var classify = await _context.Classifies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classify == null)
            {
                return NotFound();
            }

            return View(classify);
        }

        // GET: Admins/Classifies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Classifies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Pointmin,Pointmax,Orderby")] Classify classify)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classify);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classify);
        }

        // GET: Admins/Classifies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Classifies == null)
            {
                return NotFound();
            }

            var classify = await _context.Classifies.FindAsync(id);
            if (classify == null)
            {
                return NotFound();
            }
            return View(classify);
        }

        // POST: Admins/Classifies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Pointmin,Pointmax,Orderby")] Classify classify)
        {
            if (id != classify.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classify);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassifyExists(classify.Id))
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
            return View(classify);
        }

        // GET: Admins/Classifies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Classifies == null)
            {
                return NotFound();
            }

            var classify = await _context.Classifies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classify == null)
            {
                return NotFound();
            }

            return View(classify);
        }

        // POST: Admins/Classifies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Classifies == null)
            {
                return Problem("Entity set 'DanhGiaRenLuyenContext.Classifies'  is null.");
            }
            var classify = await _context.Classifies.FindAsync(id);
            if (classify != null)
            {
                _context.Classifies.Remove(classify);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassifyExists(int id)
        {
          return (_context.Classifies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
