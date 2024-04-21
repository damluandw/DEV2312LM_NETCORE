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
    public class SumaryOfPointsController : Controller
    {
        private readonly DanhGiaRenLuyenContext _context;

        public SumaryOfPointsController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }

        // GET: Admins/SumaryOfPoints
        public async Task<IActionResult> Index()
        {
            var danhGiaRenLuyenContext = _context.SumaryOfPoints.Include(s => s.Semester).Include(s => s.Student);
            return View(await danhGiaRenLuyenContext.ToListAsync());
        }

        // GET: Admins/SumaryOfPoints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sumaryOfPoint = await _context.SumaryOfPoints
                .Include(s => s.Semester)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sumaryOfPoint == null)
            {
                return NotFound();
            }

            return View(sumaryOfPoint);
        }

        // GET: Admins/SumaryOfPoints/Create
        public IActionResult Create()
        {
            ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Id");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
            return View();
        }

        // POST: Admins/SumaryOfPoints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,SemesterId,SelfPoint,ClassPoint,LecturerPoint,Classify,CreateBy,CreateDate,UpdateDate")] SumaryOfPoint sumaryOfPoint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sumaryOfPoint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Id", sumaryOfPoint.SemesterId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", sumaryOfPoint.StudentId);
            return View(sumaryOfPoint);
        }

        // GET: Admins/SumaryOfPoints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sumaryOfPoint = await _context.SumaryOfPoints.FindAsync(id);
            if (sumaryOfPoint == null)
            {
                return NotFound();
            }
            ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Id", sumaryOfPoint.SemesterId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", sumaryOfPoint.StudentId);
            return View(sumaryOfPoint);
        }

        // POST: Admins/SumaryOfPoints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,SemesterId,SelfPoint,ClassPoint,LecturerPoint,Classify,CreateBy,CreateDate,UpdateDate")] SumaryOfPoint sumaryOfPoint)
        {
            if (id != sumaryOfPoint.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sumaryOfPoint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SumaryOfPointExists(sumaryOfPoint.Id))
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
            ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Id", sumaryOfPoint.SemesterId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", sumaryOfPoint.StudentId);
            return View(sumaryOfPoint);
        }

        // GET: Admins/SumaryOfPoints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sumaryOfPoint = await _context.SumaryOfPoints
                .Include(s => s.Semester)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sumaryOfPoint == null)
            {
                return NotFound();
            }

            return View(sumaryOfPoint);
        }

        // POST: Admins/SumaryOfPoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sumaryOfPoint = await _context.SumaryOfPoints.FindAsync(id);
            if (sumaryOfPoint != null)
            {
                _context.SumaryOfPoints.Remove(sumaryOfPoint);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SumaryOfPointExists(int id)
        {
            return _context.SumaryOfPoints.Any(e => e.Id == id);
        }
    }
}
