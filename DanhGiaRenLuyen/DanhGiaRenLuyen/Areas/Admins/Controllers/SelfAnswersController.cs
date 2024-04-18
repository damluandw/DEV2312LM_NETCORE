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
    public class SelfAnswersController : Controller
    {
        private readonly DanhGiaRenLuyenContext _context;

        public SelfAnswersController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }

        // GET: Admins/SelfAnswers
        public async Task<IActionResult> Index()
        {
            var danhGiaRenLuyenContext = _context.SelfAnswers.Include(s => s.Answer).Include(s => s.Student);
            return View(await danhGiaRenLuyenContext.ToListAsync());
        }

        // GET: Admins/SelfAnswers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SelfAnswers == null)
            {
                return NotFound();
            }

            var selfAnswer = await _context.SelfAnswers
                .Include(s => s.Answer)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (selfAnswer == null)
            {
                return NotFound();
            }

            return View(selfAnswer);
        }

        // GET: Admins/SelfAnswers/Create
        public IActionResult Create()
        {
            ViewData["AnswerId"] = new SelectList(_context.Answers, "Id", "Id");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
            return View();
        }

        // POST: Admins/SelfAnswers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,AnswerId")] SelfAnswer selfAnswer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(selfAnswer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnswerId"] = new SelectList(_context.Answers, "Id", "Id", selfAnswer.AnswerId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", selfAnswer.StudentId);
            return View(selfAnswer);
        }

        // GET: Admins/SelfAnswers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SelfAnswers == null)
            {
                return NotFound();
            }

            var selfAnswer = await _context.SelfAnswers.FindAsync(id);
            if (selfAnswer == null)
            {
                return NotFound();
            }
            ViewData["AnswerId"] = new SelectList(_context.Answers, "Id", "Id", selfAnswer.AnswerId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", selfAnswer.StudentId);
            return View(selfAnswer);
        }

        // POST: Admins/SelfAnswers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,AnswerId")] SelfAnswer selfAnswer)
        {
            if (id != selfAnswer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(selfAnswer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SelfAnswerExists(selfAnswer.Id))
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
            ViewData["AnswerId"] = new SelectList(_context.Answers, "Id", "Id", selfAnswer.AnswerId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", selfAnswer.StudentId);
            return View(selfAnswer);
        }

        // GET: Admins/SelfAnswers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SelfAnswers == null)
            {
                return NotFound();
            }

            var selfAnswer = await _context.SelfAnswers
                .Include(s => s.Answer)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (selfAnswer == null)
            {
                return NotFound();
            }

            return View(selfAnswer);
        }

        // POST: Admins/SelfAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SelfAnswers == null)
            {
                return Problem("Entity set 'DanhGiaRenLuyenContext.SelfAnswers'  is null.");
            }
            var selfAnswer = await _context.SelfAnswers.FindAsync(id);
            if (selfAnswer != null)
            {
                _context.SelfAnswers.Remove(selfAnswer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SelfAnswerExists(int id)
        {
          return (_context.SelfAnswers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
