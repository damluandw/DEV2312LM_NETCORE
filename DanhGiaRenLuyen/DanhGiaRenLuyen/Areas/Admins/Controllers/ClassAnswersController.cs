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
    public class ClassAnswersController : BaseController
    {
        private readonly DanhGiaRenLuyenContext _context;

        public ClassAnswersController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }

        // GET: Admins/ClassAnswers
        public async Task<IActionResult> Index()
        {
            var danhGiaRenLuyenContext = _context.ClassAnswers.Include(c => c.Answer).Include(c => c.Student);
            return View(await danhGiaRenLuyenContext.ToListAsync());
        }

        // GET: Admins/ClassAnswers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClassAnswers == null)
            {
                return NotFound();
            }

            var classAnswer = await _context.ClassAnswers
                .Include(c => c.Answer)
                .Include(c => c.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classAnswer == null)
            {
                return NotFound();
            }

            return View(classAnswer);
        }

        // GET: Admins/ClassAnswers/Create
        public IActionResult Create()
        {
            ViewData["AnswerId"] = new SelectList(_context.Answers, "Id", "Id");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
            return View();
        }

        // POST: Admins/ClassAnswers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,AnswerId,Createby")] ClassAnswer classAnswer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classAnswer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnswerId"] = new SelectList(_context.Answers, "Id", "Id", classAnswer.AnswerId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", classAnswer.StudentId);
            return View(classAnswer);
        }

        // GET: Admins/ClassAnswers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClassAnswers == null)
            {
                return NotFound();
            }

            var classAnswer = await _context.ClassAnswers.FindAsync(id);
            if (classAnswer == null)
            {
                return NotFound();
            }
            ViewData["AnswerId"] = new SelectList(_context.Answers, "Id", "Id", classAnswer.AnswerId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", classAnswer.StudentId);
            return View(classAnswer);
        }

        // POST: Admins/ClassAnswers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,AnswerId,Createby")] ClassAnswer classAnswer)
        {
            if (id != classAnswer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classAnswer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassAnswerExists(classAnswer.Id))
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
            ViewData["AnswerId"] = new SelectList(_context.Answers, "Id", "Id", classAnswer.AnswerId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", classAnswer.StudentId);
            return View(classAnswer);
        }

        // GET: Admins/ClassAnswers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClassAnswers == null)
            {
                return NotFound();
            }

            var classAnswer = await _context.ClassAnswers
                .Include(c => c.Answer)
                .Include(c => c.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classAnswer == null)
            {
                return NotFound();
            }

            return View(classAnswer);
        }

        // POST: Admins/ClassAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClassAnswers == null)
            {
                return Problem("Entity set 'DanhGiaRenLuyenContext.ClassAnswers'  is null.");
            }
            var classAnswer = await _context.ClassAnswers.FindAsync(id);
            if (classAnswer != null)
            {
                _context.ClassAnswers.Remove(classAnswer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassAnswerExists(int id)
        {
          return (_context.ClassAnswers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
