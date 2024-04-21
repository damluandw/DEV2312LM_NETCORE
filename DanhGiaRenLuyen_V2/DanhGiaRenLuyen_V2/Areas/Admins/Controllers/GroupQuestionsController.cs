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
    public class GroupQuestionsController : Controller
    {
        private readonly DanhGiaRenLuyenContext _context;

        public GroupQuestionsController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }

        // GET: Admins/GroupQuestions
        public async Task<IActionResult> Index()
        {
            return View(await _context.GroupQuestions.ToListAsync());
        }

        // GET: Admins/GroupQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupQuestion = await _context.GroupQuestions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupQuestion == null)
            {
                return NotFound();
            }

            return View(groupQuestion);
        }

        // GET: Admins/GroupQuestions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/GroupQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] GroupQuestion groupQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groupQuestion);
        }

        // GET: Admins/GroupQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupQuestion = await _context.GroupQuestions.FindAsync(id);
            if (groupQuestion == null)
            {
                return NotFound();
            }
            return View(groupQuestion);
        }

        // POST: Admins/GroupQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] GroupQuestion groupQuestion)
        {
            if (id != groupQuestion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupQuestionExists(groupQuestion.Id))
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
            return View(groupQuestion);
        }

        // GET: Admins/GroupQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupQuestion = await _context.GroupQuestions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupQuestion == null)
            {
                return NotFound();
            }

            return View(groupQuestion);
        }

        // POST: Admins/GroupQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupQuestion = await _context.GroupQuestions.FindAsync(id);
            if (groupQuestion != null)
            {
                _context.GroupQuestions.Remove(groupQuestion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupQuestionExists(int id)
        {
            return _context.GroupQuestions.Any(e => e.Id == id);
        }
    }
}
