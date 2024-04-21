using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DanhGiaRenLuyen_V2.Models.DBModel;

namespace DanhGiaRenLuyen_V2.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class AccountLecturersController : Controller
    {
        private readonly DanhGiaRenLuyenContext _context;

        public AccountLecturersController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }

        // GET: Admins/AccountLecturers
        public async Task<IActionResult> Index()
        {
            var danhGiaRenLuyenContext = _context.AccountLecturers.Include(a => a.Lecturer);
            return View(await danhGiaRenLuyenContext.ToListAsync());
        }

        // GET: Admins/AccountLecturers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountLecturer = await _context.AccountLecturers
                .Include(a => a.Lecturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountLecturer == null)
            {
                return NotFound();
            }

            return View(accountLecturer);
        }

        // GET: Admins/AccountLecturers/Create
        public IActionResult Create()
        {
            ViewData["LecturerId"] = new SelectList(_context.Lecturers, "Id", "Id");
            return View();
        }

        // POST: Admins/AccountLecturers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Password,CreateBy,CreateDate,UpdateDate,IsActive,LecturerId")] AccountLecturer accountLecturer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountLecturer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LecturerId"] = new SelectList(_context.Lecturers, "Id", "Id", accountLecturer.LecturerId);
            return View(accountLecturer);
        }

        // GET: Admins/AccountLecturers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountLecturer = await _context.AccountLecturers.FindAsync(id);
            if (accountLecturer == null)
            {
                return NotFound();
            }
            ViewData["LecturerId"] = new SelectList(_context.Lecturers, "Id", "Id", accountLecturer.LecturerId);
            return View(accountLecturer);
        }

        // POST: Admins/AccountLecturers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Password,CreateBy,CreateDate,UpdateDate,IsActive,LecturerId")] AccountLecturer accountLecturer)
        {
            if (id != accountLecturer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountLecturer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountLecturerExists(accountLecturer.Id))
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
            ViewData["LecturerId"] = new SelectList(_context.Lecturers, "Id", "Id", accountLecturer.LecturerId);
            return View(accountLecturer);
        }

        // GET: Admins/AccountLecturers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountLecturer = await _context.AccountLecturers
                .Include(a => a.Lecturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountLecturer == null)
            {
                return NotFound();
            }

            return View(accountLecturer);
        }

        // POST: Admins/AccountLecturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountLecturer = await _context.AccountLecturers.FindAsync(id);
            if (accountLecturer != null)
            {
                _context.AccountLecturers.Remove(accountLecturer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountLecturerExists(int id)
        {
            return _context.AccountLecturers.Any(e => e.Id == id);
        }
    }
}
