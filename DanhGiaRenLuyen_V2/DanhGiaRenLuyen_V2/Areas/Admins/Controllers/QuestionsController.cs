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
    public class QuestionsController : Controller
    {
        private readonly DanhGiaRenLuyenContext _context;


        public QuestionsController(DanhGiaRenLuyenContext context)
        {
            _context = context;

        }

        // GET: Admins/Questions
        public async Task<IActionResult> Index(int? semesterId)
        {
            
            
            if (semesterId == null)
            {
                var danhGiaRenLuyenContext = _context.Questions.Include(q => q.GroupQuestion).Include(q => q.Semester).Include(q => q.TypeQuestion);
                return View(await danhGiaRenLuyenContext.ToListAsync());
            }
            else 
            {
                var danhGiaRenLuyenContext = _context.Questions.Where(x => x.SemesterId == semesterId).Include(q => q.GroupQuestion).Include(q => q.Semester).Include(q => q.TypeQuestion);
                return View(await danhGiaRenLuyenContext.ToListAsync());
            }                
        }

        // GET: Admins/Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.GroupQuestion)
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
            var semesters = _context.Semesters.Where(s => s.Id != null)
                                              .Select(s => new {
                                                  Id = s.Id,
                                                  Name = string.Format("Kỳ {0} - Năm {1}", s.Name, s.SchoolYear)
                                              }).ToList();
            ViewData["GroupQuestionId"] = new SelectList(_context.GroupQuestions, "Id", "Name");
            ViewData["SemesterId"] = new SelectList(semesters, "Id", "Name");
            ViewData["TypeQuestionId"] = new SelectList(_context.TypeQuestions, "Id", "Name");
            return View();
        }

        // POST: Admins/Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContentQuestion,TypeQuestionId,SemesterId,GroupQuestionId,OrderBy")] Question question)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var semesters = _context.Semesters.Where(s => s.Id != null)
                                   .Select(s => new {
                                       Id = s.Id,
                                       Name = string.Format("Kỳ {0} - Năm {1}", s.Name, s.SchoolYear)
                                   }).ToList();
            ViewData["GroupQuestionId"] = new SelectList(_context.GroupQuestions, "Id", "Name", question.GroupQuestionId);
            ViewData["SemesterId"] = new SelectList(semesters, "Id", "Name", question.SemesterId);
            ViewData["TypeQuestionId"] = new SelectList(_context.TypeQuestions, "Id", "Name", question.TypeQuestionId);
            return View(question);
        }

        // GET: Admins/Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            var semesters = _context.Semesters.Where(s => s.Id != null)
                                .Select(s => new {
                                    Id = s.Id,
                                    Name = string.Format("Kỳ {0} - Năm {1}", s.Name, s.SchoolYear)
                                }).ToList();
            ViewData["GroupQuestionId"] = new SelectList(_context.GroupQuestions, "Id", "Name", question.GroupQuestionId);
            ViewData["SemesterId"] = new SelectList(semesters, "Id", "Name", question.SemesterId);
            ViewData["TypeQuestionId"] = new SelectList(_context.TypeQuestions, "Id", "Name", question.TypeQuestionId);
            return View(question);
        }

        // POST: Admins/Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContentQuestion,TypeQuestionId,SemesterId,GroupQuestionId,OrderBy")] Question question)
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
            var semesters = _context.Semesters.Where(s => s.Id != null)
                         .Select(s => new {
                             Id = s.Id,
                             Name = string.Format("Kỳ {0} - Năm {1}", s.Name, s.SchoolYear)
                         }).ToList();
            ViewData["GroupQuestionId"] = new SelectList(_context.GroupQuestions, "Id", "Name", question.GroupQuestionId);
            ViewData["SemesterId"] = new SelectList(semesters, "Id", "Name", question.SemesterId);
            ViewData["TypeQuestionId"] = new SelectList(_context.TypeQuestions, "Id", "Name", question.TypeQuestionId);
            return View(question);
        }

        // GET: Admins/Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.GroupQuestion)
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
            return _context.Questions.Any(e => e.Id == id);
        }
        public async Task<IActionResult> IndexAnswer(int? id)
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
            //ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Semester1", question.SemesterId);
            //ViewData["TypeQuestionId"] = new SelectList(_context.TypeQuestions, "Id", "Name", question.TypeQuestionId);

            var answer = await _context.Answers.Where(a => a.QuestionId == id).ToListAsync();
            ViewData["Question"] = question;
            return View(answer);
        }
        // GET: Admins/Questions/Details/5
        public async Task<IActionResult> DetailsAnswer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answers
                .Include(a => a.Question)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // GET: Admins/Questions/CreateAnswer
        public async Task<IActionResult> CreateAnswer(int? id)
        {
     
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);
            ViewData["Question"] = question;
            return View();
        }

        // POST: Admins/Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAnswer(int? id, [Bind("Id,QuestionId,ContentAnswer,AnswerScore")] Answer answer)
        {
            if (id == null)
            {
                return NotFound();
            }
            Answer an = new Answer();
            an.QuestionId = id;
            an.ContentAnswer = answer.ContentAnswer;
            an.AnswerScore = answer.AnswerScore;
            if (ModelState.IsValid)
            {
                _context.Add(an);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexAnswer),new { id });
            }
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "ContentQuestion", answer.QuestionId);
            return View(an);
        }

        // GET: Admins/Questions/Edit/5
        public async Task<IActionResult> EditAnswer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answers.FindAsync(id);
            if (answer == null)
            {
                return NotFound();
            }
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "ContentQuestion", answer.QuestionId);
            return View(answer);
        }

        // POST: Admins/Answers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Admins/Answers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAnswer(int id, [Bind("Id,QuestionId,ContentAnswer,AnswerScore")] Answer answer)
        {
            //if (id != answer.Id)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(answer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnswerExists(answer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(EditAnswer));
            }
            var question = await _context.Questions.FindAsync(answer.QuestionId);
            var answers = await _context.Answers.Where(a => a.QuestionId == id).ToListAsync();
            ViewData["QuestionId"] = question.ContentQuestion;
            return View(answers);
        }

        // GET: Admins/Answers/Delete/5
        public async Task<IActionResult> DeleteAnswer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answers
                .Include(a => a.Question)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // POST: Admins/Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAnswer(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer != null)
            {
                _context.Answers.Remove(answer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        private bool AnswerExists(int id)
        {
            return _context.Answers.Any(e => e.Id == id);
        }

    }
}
