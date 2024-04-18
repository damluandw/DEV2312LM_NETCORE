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
    public class AccountadminsController : BaseController
    {
        private readonly DanhGiaRenLuyenContext _context;

        public AccountadminsController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }

        // GET: Admins/Accountadmins
        public async Task<IActionResult> Index()
        {
            var danhGiaRenLuyenContext = _context.Accountadmins.Include(a => a.Role);
            return View(await danhGiaRenLuyenContext.ToListAsync());
        }

        // GET: Admins/Accountadmins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Accountadmins == null)
            {
                return NotFound();
            }

            var accountadmin = await _context.Accountadmins
                .Include(a => a.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountadmin == null)
            {
                return NotFound();
            }

            return View(accountadmin);
        }

        // GET: Admins/Accountadmins/Create
        public IActionResult Create()
        {
            ViewData["Roleid"] = new SelectList(_context.Roles, "Id", "Id");
            return View();
        }

        // POST: Admins/Accountadmins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fullname,Username,Password,Createby,Createdate,Updatedate,Isactive,Roleid")] Accountadmin accountadmin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountadmin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Roleid"] = new SelectList(_context.Roles, "Id", "Id", accountadmin.Roleid);
            return View(accountadmin);
        }

        // GET: Admins/Accountadmins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Accountadmins == null)
            {
                return NotFound();
            }

            var accountadmin = await _context.Accountadmins.FindAsync(id);
            if (accountadmin == null)
            {
                return NotFound();
            }
            ViewData["Roleid"] = new SelectList(_context.Roles, "Id", "Id", accountadmin.Roleid);
            return View(accountadmin);
        }

        // POST: Admins/Accountadmins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fullname,Username,Password,Createby,Createdate,Updatedate,Isactive,Roleid")] Accountadmin accountadmin)
        {
            if (id != accountadmin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountadmin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountadminExists(accountadmin.Id))
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
            ViewData["Roleid"] = new SelectList(_context.Roles, "Id", "Id", accountadmin.Roleid);
            return View(accountadmin);
        }

        // GET: Admins/Accountadmins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Accountadmins == null)
            {
                return NotFound();
            }

            var accountadmin = await _context.Accountadmins
                .Include(a => a.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountadmin == null)
            {
                return NotFound();
            }

            return View(accountadmin);
        }

        // POST: Admins/Accountadmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Accountadmins == null)
            {
                return Problem("Entity set 'DanhGiaRenLuyenContext.Accountadmins'  is null.");
            }
            var accountadmin = await _context.Accountadmins.FindAsync(id);
            if (accountadmin != null)
            {
                _context.Accountadmins.Remove(accountadmin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountadminExists(int id)
        {
          return (_context.Accountadmins?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
