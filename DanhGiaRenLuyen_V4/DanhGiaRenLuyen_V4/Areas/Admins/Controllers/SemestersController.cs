using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DanhGiaRenLuyen_V4.Models.DBModel;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using DanhGiaRenLuyen_V4.Areas.Admins.Models;

namespace DanhGiaRenLuyen_V4.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class SemestersController : Controller
    {
        private readonly DanhGiaRenLuyenContext _context;

        public SemestersController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }

        // GET: Admins/Semesters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Semesters.ToListAsync());
        }

        // GET: Admins/Semesters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var semester = await _context.Semesters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (semester == null)
            {
                return NotFound();
            }

            return View(semester);
        }

        // GET: Admins/Semesters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Semesters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SchoolYear,DateOpenStudent,DateEndStudent,DateEndClass,DateEndLecturer,IsActive")] Semester semester)
        {
            if (ModelState.IsValid)
            {
                _context.Add(semester);
                await _context.SaveChangesAsync();
                int semesterId = _context.Semesters.OrderByDescending(x => x.Id).FirstOrDefault().Id;

                return RedirectToAction(nameof(CreateQuestions), new { id = semesterId });
            }
            return View(semester);
        }

        // GET: Admins/Semesters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var semester = await _context.Semesters.FindAsync(id);
            if (semester == null)
            {
                return NotFound();
            }
            return View(semester);
        }

        // POST: Admins/Semesters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SchoolYear,DateOpenStudent,DateEndStudent,DateEndClass,DateEndLecturer,IsActive")] Semester semester)
        {
            if (id != semester.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(semester);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SemesterExists(semester.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                int semesterId = _context.Semesters.OrderByDescending(x => x.Id).FirstOrDefault().Id;

                return RedirectToAction(nameof(Index), new { id = semesterId });
            }
            return View(semester);
        }

        // GET: Admins/Semesters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var semester = await _context.Semesters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (semester == null)
            {
                return NotFound();
            }

            return View(semester);
        }

        // POST: Admins/Semesters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var semester = await _context.Semesters.FindAsync(id);
            if (semester != null)
            {
                _context.Semesters.Remove(semester);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SemesterExists(int id)
        {
            return _context.Semesters.Any(e => e.Id == id);
        }



        // GET: Admins/Semesters/Create
        public async Task<IActionResult> CreateQuestions(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var groupQuestions = _context.GroupQuestions.Include(u => u.QuestionLists).ThenInclude(u => u.QuestionHisories).Include(x => x.QuestionLists).ThenInclude(x => x.AnswerLists).ToList();
            ViewBag.SemesterId = id;
            return View(groupQuestions);
        }
        [HttpPost]
        public IActionResult CreateQuestions(int semesterId, Dictionary<int, int> QuestionId)
        {
            if (ModelState.IsValid)
            {
                var admin = JsonConvert.DeserializeObject<Login>(HttpContext.Session.GetString("AdminLogin"));
                string questionIds = "";
                foreach (int question in QuestionId.Values)
                {
                    questionIds += question + ",";
                }
                questionIds = questionIds.Substring(0, questionIds.Length - 1);
                string sql = "INSERT INTO QuestionHisory SELECT Id," + semesterId + ", OrderBy,'" + admin.UserName + "',GETDATE() FROM QuestionList where Id in (" + questionIds + ")";
                FormattableString query = FormattableStringFactory.Create(sql);
                var num = _context.Database.ExecuteSqlAsync(query);

                //_context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

