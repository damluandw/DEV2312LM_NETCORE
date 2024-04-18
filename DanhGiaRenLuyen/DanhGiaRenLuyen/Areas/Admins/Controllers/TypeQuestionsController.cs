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
    public class TypeQuestionsController : Controller
    {
        private readonly DanhGiaRenLuyenContext _context;

        public TypeQuestionsController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }

        // GET: Admins/TypeQuestions
        public async Task<IActionResult> Index()
        {
              return _context.TypeQuestions != null ? 
                          View(await _context.TypeQuestions.ToListAsync()) :
                          Problem("Entity set 'DanhGiaRenLuyenContext.TypeQuestions'  is null.");
        }

        // GET: Admins/TypeQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeQuestions == null)
            {
                return NotFound();
            }

            var typeQuestion = await _context.TypeQuestions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeQuestion == null)
            {
                return NotFound();
            }

            return View(typeQuestion);
        }

        // GET: Admins/TypeQuestions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/TypeQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TypeQuestion typeQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeQuestion);
        }

        // GET: Admins/TypeQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeQuestions == null)
            {
                return NotFound();
            }

            var typeQuestion = await _context.TypeQuestions.FindAsync(id);
            if (typeQuestion == null)
            {
                return NotFound();
            }
            return View(typeQuestion);
        }

        // POST: Admins/TypeQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TypeQuestion typeQuestion)
        {
            if (id != typeQuestion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeQuestionExists(typeQuestion.Id))
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
            return View(typeQuestion);
        }

        // GET: Admins/TypeQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeQuestions == null)
            {
                return NotFound();
            }

            var typeQuestion = await _context.TypeQuestions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeQuestion == null)
            {
                return NotFound();
            }

            return View(typeQuestion);
        }

        // POST: Admins/TypeQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeQuestions == null)
            {
                return Problem("Entity set 'DanhGiaRenLuyenContext.TypeQuestions'  is null.");
            }
            var typeQuestion = await _context.TypeQuestions.FindAsync(id);
            if (typeQuestion != null)
            {
                _context.TypeQuestions.Remove(typeQuestion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeQuestionExists(int id)
        {
          return (_context.TypeQuestions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
