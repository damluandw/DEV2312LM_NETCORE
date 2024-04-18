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
    public class QuestionsController : BaseController
    {
        private readonly DanhGiaRenLuyenContext _context;

        public QuestionsController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }

        // GET: Admins/Questions
        public async Task<IActionResult> Index()
        {
            var danhGiaRenLuyenContext = _context.Questions.Include(q => q.Semester).Include(q => q.TypeQuestion);
            return View(await danhGiaRenLuyenContext.ToListAsync());
        }

        // GET: Admins/Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.Semester)
                .Include(q => q.TypeQuestion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Admins/Questions/Create
        public IActionResult Create()
        {
            ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Id");
            ViewData["TypeQuestionId"] = new SelectList(_context.TypeQuestions, "Id", "Id");
            return View();
        }

        // POST: Admins/Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question1,TypeQuestionId,SemesterId")] Question question)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Id", question.SemesterId);
            ViewData["TypeQuestionId"] = new SelectList(_context.TypeQuestions, "Id", "Id", question.TypeQuestionId);
            return View(question);
        }

        // GET: Admins/Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Id", question.SemesterId);
            ViewData["TypeQuestionId"] = new SelectList(_context.TypeQuestions, "Id", "Id", question.TypeQuestionId);
            return View(question);
        }

        // POST: Admins/Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question1,TypeQuestionId,SemesterId")] Question question)
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
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
            ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Id", question.SemesterId);
            ViewData["TypeQuestionId"] = new SelectList(_context.TypeQuestions, "Id", "Id", question.TypeQuestionId);
            return View(question);
        }

        // GET: Admins/Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.Semester)
                .Include(q => q.TypeQuestion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Admins/Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Questions == null)
            {
                return Problem("Entity set 'DanhGiaRenLuyenContext.Questions'  is null.");
            }
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
          return (_context.Questions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
