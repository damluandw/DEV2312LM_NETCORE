﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using DanhGiaRenLuyen_V5.Models.DBModel;
namespace DanhGiaRenLuyen_V5.Areas.Admin.Controllers
{
    public class StudentsController : BaseController
    {
        private readonly DanhGiaRenLuyenContext _context;

        public StudentsController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }

        // GET: Admin/Students
        public async Task<IActionResult> Index(string? name,int? classId, bool? isDelete, int? departmentId)
        {
            if(isDelete == null)
            {
                isDelete = false;
            }
            ViewBag.IsDelete = isDelete;
            var students = _context.Students.Include(s => s.Class).ThenInclude(s => s.Department).Include(s => s.Position);
            var DanhGiaRenLuyenContext = students.Where(x => x.IsDelete == isDelete && x.Class.DepartmentId == departmentId);
            if (classId != null)
            {
                DanhGiaRenLuyenContext = students.Where(x => x.IsDelete == isDelete && x.ClassId == classId);
                if (!name.IsNullOrEmpty())
                {
                    DanhGiaRenLuyenContext = students.Where(x => x.IsDelete == isDelete && x.Class.DepartmentId == departmentId && x.ClassId == classId && x.FullName.Contains(name));
                }
            }else if (!name.IsNullOrEmpty())
            {
                    DanhGiaRenLuyenContext = students.Where(x => x.IsDelete == isDelete && x.Class.DepartmentId == departmentId && x.FullName.Contains(name));
            }
            ViewData["ClassId"] = new SelectList(_context.Classes.Where(x => x.DepartmentId == departmentId), "Id", "Name");
            ViewBag.DepartmentId = departmentId;
            
            return View(await DanhGiaRenLuyenContext.ToListAsync());
        }

        // GET: Admin/Students/Details/5
        public async Task<IActionResult> Details(string id, int? departmentId, bool? isDelete)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Class)
                .Include(s => s.Position)
                .FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.DepartmentId = departmentId;
            ViewBag.IsDelete = isDelete;
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Admin/Students/Create
        public IActionResult Create(int? departmentId)
        {
            ViewData["ClassId"] = new SelectList(_context.Classes.Where(x => x.IsDelete == false), "Id", "Name");
            ViewData["PositionId"] = new SelectList(_context.Positions.Where(x => x.Id != "GV"), "Id", "Name");
            ViewBag.DepartmentId = departmentId;
            return View();
        }

        // POST: Admin/Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Birthday,Email,Phone,Gender,ClassId,PositionId,IsActive")] Students student, int?departmentId)
        {
            if (ModelState.IsValid)
            {
                var admin = JsonConvert.DeserializeObject<AccountAdmin>(HttpContext.Session.GetString("AdminLogin"));
                AccountStudent accountStudent = new AccountStudent() {
                    UserName = student.Id,
                    Password = "12345",
                    CreateBy = admin.UserName,
                    CreateDate = DateTime.Now,
                    IsActive = 1,
                    StudentId = student.Id                    
                };
                student.IsDelete = false;
                _context.AccountStudents.Add(accountStudent);
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {departmentId = departmentId});
            }
            ViewData["ClassId"] = new SelectList(_context.Classes.Where(x => x.IsDelete == false), "Id", "Name", student.ClassId);
            ViewData["PositionId"] = new SelectList(_context.Positions.Where(x => x.Id != "GV"), "Id", "Name", student.PositionId);
            return View(student);
        }

        // GET: Admin/Students/Edit/5
        public async Task<IActionResult> Edit(string id, int? departmentId, bool? isDelete)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Classes.Where(x => x.IsDelete == false), "Id", "Name", student.ClassId);
            ViewData["PositionId"] = new SelectList(_context.Positions.Where(x => x.Id != "GV"), "Id", "Name", student.PositionId);
            ViewBag.DepartmentId = departmentId;
            ViewBag.IsDelete=isDelete;
            return View(student);
        }

        // POST: Admin/Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FullName,Birthday,Email,Phone,Gender,ClassId,PositionId,IsActive")] Students student, int? departmentId, bool? isDelete)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    student.IsDelete = (bool)isDelete;
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                    var st = _context.Students.FirstOrDefault(x => x.Id == id);
                    var acc = _context.AccountStudents.FirstOrDefault(x => x.StudentId == id);
                    if(st.IsActive == 1)
                    {
                        acc.IsActive = 1;
                    }
                    else
                    {
                        acc.IsActive = 0;
                    }
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new {departmentId = departmentId, isDelete = isDelete });
            }
            ViewData["ClassId"] = new SelectList(_context.Classes.Where(x => x.IsDelete == false), "Id", "Name", student.ClassId);
            ViewData["PositionId"] = new SelectList(_context.Positions.Where(x => x.Id !="GV"), "Id", "Name", student.PositionId);
            return RedirectToAction(nameof(Index), new { departmentId = departmentId, isDelete = isDelete });
        }

        // GET: Admin/Students/Delete/5
        public async Task<IActionResult> Delete(string id, int? departmentId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Class)
                .Include(s => s.Position)
                .FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.DepartmentId = departmentId;
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Admin/Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id, int? departmentId)
        {
            var student = await _context.Students.FindAsync(id);
            var acc = _context.AccountStudents.Where(x => x.StudentId == id).FirstOrDefault();
            if (student != null)
            {
                student.IsDelete = true;
                acc.IsActive = 0;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { departmentId = departmentId, isDelete = false});
        }

        private bool StudentExists(string id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
        public IActionResult Show(string? id, int? departmentId)
        {
            var student =  _context.Students.Find(id);
            var acc = _context.AccountStudents.Where(x => x.StudentId == id).FirstOrDefault();
            if (student != null)
            {
                student.IsDelete = false;
                acc.IsActive = 1;
            }
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), new { isDelete = true, departmentId = departmentId });
        }
        public async Task<IActionResult> Remove(string id, int? departmentId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Class)
                .Include(s => s.Position)
                .FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.DepartmentId = departmentId;
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Admin/Students/Delete/5
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveConfirmed(string id, int? departmentId)
        {
            var student = await _context.Students.FindAsync(id);
            var acc = _context.AccountStudents.Where(x => x.StudentId == id).FirstOrDefault();
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.AccountStudents.Remove(acc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { departmentId = departmentId, isDelete = true });
        }

    }
}