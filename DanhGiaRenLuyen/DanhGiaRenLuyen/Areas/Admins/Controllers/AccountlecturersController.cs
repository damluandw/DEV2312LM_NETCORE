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
    public class AccountlecturersController : BaseController
    {
        private readonly DanhGiaRenLuyenContext _context;

        public AccountlecturersController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }

        // GET: Admins/Accountlecturers
        public async Task<IActionResult> Index()
        {
            var danhGiaRenLuyenContext = _context.Accountlecturers.Include(a => a.Lecturer);
            return View(await danhGiaRenLuyenContext.ToListAsync());
        }

        // GET: Admins/Accountlecturers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Accountlecturers == null)
            {
                return NotFound();
            }

            var accountlecturer = await _context.Accountlecturers
                .Include(a => a.Lecturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountlecturer == null)
            {
                return NotFound();
            }

            return View(accountlecturer);
        }

        // GET: Admins/Accountlecturers/Create
        public IActionResult Create()
        {
            ViewData["Lecturerid"] = new SelectList(_context.Lecturers, "Id", "Id");
            return View();
        }

        // POST: Admins/Accountlecturers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,Createby,Createdate,Updatedate,Isactive,Lecturerid")] Accountlecturer accountlecturer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountlecturer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Lecturerid"] = new SelectList(_context.Lecturers, "Id", "Id", accountlecturer.Lecturerid);
            return View(accountlecturer);
        }

        // GET: Admins/Accountlecturers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Accountlecturers == null)
            {
                return NotFound();
            }

            var accountlecturer = await _context.Accountlecturers.FindAsync(id);
            if (accountlecturer == null)
            {
                return NotFound();
            }
            ViewData["Lecturerid"] = new SelectList(_context.Lecturers, "Id", "Id", accountlecturer.Lecturerid);
            return View(accountlecturer);
        }

        // POST: Admins/Accountlecturers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,Createby,Createdate,Updatedate,Isactive,Lecturerid")] Accountlecturer accountlecturer)
        {
            if (id != accountlecturer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountlecturer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountlecturerExists(accountlecturer.Id))
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
            ViewData["Lecturerid"] = new SelectList(_context.Lecturers, "Id", "Id", accountlecturer.Lecturerid);
            return View(accountlecturer);
        }

        // GET: Admins/Accountlecturers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Accountlecturers == null)
            {
                return NotFound();
            }

            var accountlecturer = await _context.Accountlecturers
                .Include(a => a.Lecturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountlecturer == null)
            {
                return NotFound();
            }

            return View(accountlecturer);
        }

        // POST: Admins/Accountlecturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Accountlecturers == null)
            {
                return Problem("Entity set 'DanhGiaRenLuyenContext.Accountlecturers'  is null.");
            }
            var accountlecturer = await _context.Accountlecturers.FindAsync(id);
            if (accountlecturer != null)
            {
                _context.Accountlecturers.Remove(accountlecturer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountlecturerExists(int id)
        {
          return (_context.Accountlecturers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
