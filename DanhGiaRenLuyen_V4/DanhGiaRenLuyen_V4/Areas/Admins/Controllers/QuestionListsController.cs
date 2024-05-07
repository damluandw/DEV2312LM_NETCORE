using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DanhGiaRenLuyen_V4.Models.DBModel;

namespace DanhGiaRenLuyen_V4.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class QuestionListsController : Controller
    {
        private readonly DanhGiaRenLuyenContext _context;

        public QuestionListsController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }

        // GET: Admins/QuestionLists
        public async Task<IActionResult> Index()
        {
            var danhGiaRenLuyenContext = _context.QuestionLists.Include(q => q.GroupQuestion).Include(q => q.TypeQuestion);
            return View(await danhGiaRenLuyenContext.ToListAsync());
        }

        // GET: Admins/QuestionLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionList = await _context.QuestionLists
                .Include(q => q.GroupQuestion)
                .Include(q => q.TypeQuestion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionList == null)
            {
                return NotFound();
            }

            return View(questionList);
        }

        // GET: Admins/QuestionLists/Create
        public IActionResult Create()
        {
            ViewData["GroupQuestionId"] = new SelectList(_context.GroupQuestions, "Id", "Name");
            ViewData["TypeQuestionId"] = new SelectList(_context.TypeQuestions, "Id", "Name");
            return View();
        }

        // POST: Admins/QuestionLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContentQuestion,TypeQuestionId,GroupQuestionId,OrderBy,Status,IsEdit,CreateDate,UpdateDate,UpdateBy")] QuestionList questionList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupQuestionId"] = new SelectList(_context.GroupQuestions, "Id", "Name", questionList.GroupQuestionId);
            ViewData["TypeQuestionId"] = new SelectList(_context.TypeQuestions, "Id", "Name", questionList.TypeQuestionId);
            return View(questionList);
        }

        // GET: Admins/QuestionLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionList = await _context.QuestionLists.FindAsync(id);
            if (questionList == null)
            {
                return NotFound();
            }
            ViewData["GroupQuestionId"] = new SelectList(_context.GroupQuestions, "Id", "Name", questionList.GroupQuestionId);
            ViewData["TypeQuestionId"] = new SelectList(_context.TypeQuestions, "Id", "Name", questionList.TypeQuestionId);
            return View(questionList);
        }

        // POST: Admins/QuestionLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContentQuestion,TypeQuestionId,GroupQuestionId,OrderBy,Status,IsEdit,CreateDate,UpdateDate,UpdateBy")] QuestionList questionList)
        {
            if (id != questionList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionListExists(questionList.Id))
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
            ViewData["GroupQuestionId"] = new SelectList(_context.GroupQuestions, "Id", "Name", questionList.GroupQuestionId);
            ViewData["TypeQuestionId"] = new SelectList(_context.TypeQuestions, "Id", "Name", questionList.TypeQuestionId);
            return View(questionList);
        }

        // GET: Admins/QuestionLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionList = await _context.QuestionLists
                .Include(q => q.GroupQuestion)
                .Include(q => q.TypeQuestion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionList == null)
            {
                return NotFound();
            }

            return View(questionList);
        }

        // POST: Admins/QuestionLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questionList = await _context.QuestionLists.FindAsync(id);
            if (questionList != null)
            {
                _context.QuestionLists.Remove(questionList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionListExists(int id)
        {
            return _context.QuestionLists.Any(e => e.Id == id);
        }
    }
}
