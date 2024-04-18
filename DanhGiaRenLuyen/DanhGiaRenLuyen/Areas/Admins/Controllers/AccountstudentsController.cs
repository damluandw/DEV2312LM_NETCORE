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
    public class AccountstudentsController : BaseController
    {
        private readonly DanhGiaRenLuyenContext _context;

        public AccountstudentsController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }

        // GET: Admins/Accountstudents
        public async Task<IActionResult> Index()
        {
            var danhGiaRenLuyenContext = _context.Accountstudents.Include(a => a.Student);
            return View(await danhGiaRenLuyenContext.ToListAsync());
        }

        // GET: Admins/Accountstudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Accountstudents == null)
            {
                return NotFound();
            }

            var accountstudent = await _context.Accountstudents
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountstudent == null)
            {
                return NotFound();
            }

            return View(accountstudent);
        }

        // GET: Admins/Accountstudents/Create
        public IActionResult Create()
        {
            ViewData["Studentid"] = new SelectList(_context.Students, "Id", "Id");
            return View();
        }

        // POST: Admins/Accountstudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,Createby,Createdate,Updatedate,Isactive,Studentid")] Accountstudent accountstudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountstudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Studentid"] = new SelectList(_context.Students, "Id", "Id", accountstudent.Studentid);
            return View(accountstudent);
        }

        // GET: Admins/Accountstudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Accountstudents == null)
            {
                return NotFound();
            }

            var accountstudent = await _context.Accountstudents.FindAsync(id);
            if (accountstudent == null)
            {
                return NotFound();
            }
            ViewData["Studentid"] = new SelectList(_context.Students, "Id", "Id", accountstudent.Studentid);
            return View(accountstudent);
        }

        // POST: Admins/Accountstudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,Createby,Createdate,Updatedate,Isactive,Studentid")] Accountstudent accountstudent)
        {
            if (id != accountstudent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountstudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountstudentExists(accountstudent.Id))
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
            ViewData["Studentid"] = new SelectList(_context.Students, "Id", "Id", accountstudent.Studentid);
            return View(accountstudent);
        }

        // GET: Admins/Accountstudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Accountstudents == null)
            {
                return NotFound();
            }

            var accountstudent = await _context.Accountstudents
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountstudent == null)
            {
                return NotFound();
            }

            return View(accountstudent);
        }

        // POST: Admins/Accountstudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Accountstudents == null)
            {
                return Problem("Entity set 'DanhGiaRenLuyenContext.Accountstudents'  is null.");
            }
            var accountstudent = await _context.Accountstudents.FindAsync(id);
            if (accountstudent != null)
            {
                _context.Accountstudents.Remove(accountstudent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountstudentExists(int id)
        {
          return (_context.Accountstudents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
