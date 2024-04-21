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
    public class AccountAdminsController : Controller
    {
        private readonly DanhGiaRenLuyenContext _context;

        public AccountAdminsController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }

        // GET: Admins/AccountAdmins
        public async Task<IActionResult> Index()
        {
            var danhGiaRenLuyenContext = _context.AccountAdmins.Include(a => a.Role);
            return View(await danhGiaRenLuyenContext.ToListAsync());
        }

        // GET: Admins/AccountAdmins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountAdmin = await _context.AccountAdmins
                .Include(a => a.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountAdmin == null)
            {
                return NotFound();
            }

            return View(accountAdmin);
        }

        // GET: Admins/AccountAdmins/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id");
            return View();
        }

        // POST: Admins/AccountAdmins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,UserName,Password,CreateBy,CreateDate,UpdateDate,IsActive,RoleId")] AccountAdmin accountAdmin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountAdmin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", accountAdmin.RoleId);
            return View(accountAdmin);
        }

        // GET: Admins/AccountAdmins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountAdmin = await _context.AccountAdmins.FindAsync(id);
            if (accountAdmin == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", accountAdmin.RoleId);
            return View(accountAdmin);
        }

        // POST: Admins/AccountAdmins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,UserName,Password,CreateBy,CreateDate,UpdateDate,IsActive,RoleId")] AccountAdmin accountAdmin)
        {
            if (id != accountAdmin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountAdmin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountAdminExists(accountAdmin.Id))
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
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", accountAdmin.RoleId);
            return View(accountAdmin);
        }

        // GET: Admins/AccountAdmins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountAdmin = await _context.AccountAdmins
                .Include(a => a.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountAdmin == null)
            {
                return NotFound();
            }

            return View(accountAdmin);
        }

        // POST: Admins/AccountAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountAdmin = await _context.AccountAdmins.FindAsync(id);
            if (accountAdmin != null)
            {
                _context.AccountAdmins.Remove(accountAdmin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountAdminExists(int id)
        {
            return _context.AccountAdmins.Any(e => e.Id == id);
        }
    }
}
