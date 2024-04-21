﻿using System;
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
    public class AccountStudentsController : Controller
    {
        private readonly DanhGiaRenLuyenContext _context;

        public AccountStudentsController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }

        // GET: Admins/AccountStudents
        public async Task<IActionResult> Index()
        {
            var danhGiaRenLuyenContext = _context.AccountStudents.Include(a => a.Student);
            return View(await danhGiaRenLuyenContext.ToListAsync());
        }

        // GET: Admins/AccountStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountStudent = await _context.AccountStudents
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountStudent == null)
            {
                return NotFound();
            }

            return View(accountStudent);
        }

        // GET: Admins/AccountStudents/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
            return View();
        }

        // POST: Admins/AccountStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Password,CreateBy,CreateDate,UpdateDate,IsActive,StudentId")] AccountStudent accountStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", accountStudent.StudentId);
            return View(accountStudent);
        }

        // GET: Admins/AccountStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountStudent = await _context.AccountStudents.FindAsync(id);
            if (accountStudent == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", accountStudent.StudentId);
            return View(accountStudent);
        }

        // POST: Admins/AccountStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Password,CreateBy,CreateDate,UpdateDate,IsActive,StudentId")] AccountStudent accountStudent)
        {
            if (id != accountStudent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountStudentExists(accountStudent.Id))
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
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", accountStudent.StudentId);
            return View(accountStudent);
        }

        // GET: Admins/AccountStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountStudent = await _context.AccountStudents
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountStudent == null)
            {
                return NotFound();
            }

            return View(accountStudent);
        }

        // POST: Admins/AccountStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountStudent = await _context.AccountStudents.FindAsync(id);
            if (accountStudent != null)
            {
                _context.AccountStudents.Remove(accountStudent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountStudentExists(int id)
        {
            return _context.AccountStudents.Any(e => e.Id == id);
        }
    }
}
