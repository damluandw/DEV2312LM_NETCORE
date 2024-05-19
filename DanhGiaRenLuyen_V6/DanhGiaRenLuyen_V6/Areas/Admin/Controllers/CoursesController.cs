﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DanhGiaRenLuyen_V6.Models.DBModel;

namespace DanhGiaRenLuyen_V6.Areas.Admin.Controllers
{
    public class CoursesController : BaseController
    {
        private readonly DanhGiaRenLuyenContext _context;

        public CoursesController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }

        // GET: Admin/Courses
        public async Task<IActionResult> Index(bool? isDelete)
        {
            ViewBag.IsDelete = isDelete;
            return View(await _context.Courses.Where(x => x.IsDelete == isDelete).ToListAsync());
        }

        // GET: Admin/Courses/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var course = await _context.Courses
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (course == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(course);
        //}

        // GET: Admin/Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsDelete")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {isDelete=false});
            }
            return View(course);
        }

        // GET: Admin/Courses/Edit/5
        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var course = await _context.Courses.FindAsync(id);
        //    if (course == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(course);
        //}

        //// POST: Admin/Courses/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("Id,Name,IsDelete")] Course course)
        //{
        //    if (id != course.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(course);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CourseExists(course.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(course);
        //}

        //GET: Admin/Courses/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        //POST: Admin/Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course != null)
            {
                course.IsDelete = true;
                var c = _context.Classes.Where(x => x.CourseId == id).ToList();
                foreach (var item in c)
                {
                    item.IsDelete = true;
                    item.IsActive = 0;
                    var students = _context.Students.Where(x => x.ClassId == item.Id).ToList();
                    foreach (var student in students)
                    {
                        student.IsActive = 3;
                        student.IsDelete = true;
                        var acc = _context.AccountStudents.FirstOrDefault(x => x.StudentId == student.Id);
                        acc.IsActive = 0;
                    }
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new {isDelete=false});
        }

        private bool CourseExists(string id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
        public IActionResult Show(string id)
        {
            var course = _context.Courses.Find(id);
     
            if (course != null)
            {
                course.IsDelete = false;
                var c = _context.Classes.Where(x => x.CourseId == id).ToList();
                foreach (var item in c)
                {
                    item.IsDelete = false;
                    item.IsActive = 1;
                    var students = _context.Students.Where(x => x.ClassId == item.Id).ToList();
                    foreach (var student in students)
                    {
                        student.IsActive = 1;
                        student.IsDelete = false;
                        var acc = _context.AccountStudents.FirstOrDefault(x => x.StudentId == student.Id);
                        acc.IsActive = 1;
                    }
                }
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), new {isDelete=true});
        }
        public async Task<IActionResult> Remove(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        //POST: Admin/Courses/Delete/5
        [HttpPost, ActionName("Remove")]
        public async Task<IActionResult> RemoveConfirmed(string id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                var c = _context.Classes.Where(x => x.CourseId == id).Include(x => x.Students).ToList();
                foreach (var item in c)
                {
                    var students = _context.Students.Where(x => x.ClassId == item.Id).ToList();

                    foreach (var student in students)
                    {
                        var acc = _context.AccountStudents.FirstOrDefault(x => x.StudentId == student.Id);
                        _context.Remove(acc);
                    }
                    _context.SaveChanges();
                    _context.RemoveRange(students);
                }
                _context.SaveChanges();
                _context.Classes.RemoveRange(c);
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { isDelete = true });
        }

    }
}
