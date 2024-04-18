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
    public class SumaryofpointsController : Controller
    {
        private readonly DanhGiaRenLuyenContext _context;

        public SumaryofpointsController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }

        // GET: Admins/Sumaryofpoints
        public async Task<IActionResult> Index()
        {
            var danhGiaRenLuyenContext = _context.Sumaryofpoints.Include(s => s.Semester).Include(s => s.Student);
            return View(await danhGiaRenLuyenContext.ToListAsync());
        }

        // GET: Admins/Sumaryofpoints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sumaryofpoints == null)
            {
                return NotFound();
            }

            var sumaryofpoint = await _context.Sumaryofpoints
                .Include(s => s.Semester)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sumaryofpoint == null)
            {
                return NotFound();
            }

            return View(sumaryofpoint);
        }

        // GET: Admins/Sumaryofpoints/Create
        public IActionResult Create()
        {
            ViewData["Semesterid"] = new SelectList(_context.Semesters, "Id", "Id");
            ViewData["Studentid"] = new SelectList(_context.Students, "Id", "Id");
            return View();
        }

        // POST: Admins/Sumaryofpoints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Studentid,Semesterid,Selfpoint,Classpoint,Lecturerpoint,Classify,Createby,Updateby,Updatedate")] Sumaryofpoint sumaryofpoint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sumaryofpoint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Semesterid"] = new SelectList(_context.Semesters, "Id", "Id", sumaryofpoint.Semesterid);
            ViewData["Studentid"] = new SelectList(_context.Students, "Id", "Id", sumaryofpoint.Studentid);
            return View(sumaryofpoint);
        }

        // GET: Admins/Sumaryofpoints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sumaryofpoints == null)
            {
                return NotFound();
            }

            var sumaryofpoint = await _context.Sumaryofpoints.FindAsync(id);
            if (sumaryofpoint == null)
            {
                return NotFound();
            }
            ViewData["Semesterid"] = new SelectList(_context.Semesters, "Id", "Id", sumaryofpoint.Semesterid);
            ViewData["Studentid"] = new SelectList(_context.Students, "Id", "Id", sumaryofpoint.Studentid);
            return View(sumaryofpoint);
        }

        // POST: Admins/Sumaryofpoints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Studentid,Semesterid,Selfpoint,Classpoint,Lecturerpoint,Classify,Createby,Updateby,Updatedate")] Sumaryofpoint sumaryofpoint)
        {
            if (id != sumaryofpoint.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sumaryofpoint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SumaryofpointExists(sumaryofpoint.Id))
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
            ViewData["Semesterid"] = new SelectList(_context.Semesters, "Id", "Id", sumaryofpoint.Semesterid);
            ViewData["Studentid"] = new SelectList(_context.Students, "Id", "Id", sumaryofpoint.Studentid);
            return View(sumaryofpoint);
        }

        // GET: Admins/Sumaryofpoints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sumaryofpoints == null)
            {
                return NotFound();
            }

            var sumaryofpoint = await _context.Sumaryofpoints
                .Include(s => s.Semester)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sumaryofpoint == null)
            {
                return NotFound();
            }

            return View(sumaryofpoint);
        }

        // POST: Admins/Sumaryofpoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sumaryofpoints == null)
            {
                return Problem("Entity set 'DanhGiaRenLuyenContext.Sumaryofpoints'  is null.");
            }
            var sumaryofpoint = await _context.Sumaryofpoints.FindAsync(id);
            if (sumaryofpoint != null)
            {
                _context.Sumaryofpoints.Remove(sumaryofpoint);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SumaryofpointExists(int id)
        {
          return (_context.Sumaryofpoints?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
