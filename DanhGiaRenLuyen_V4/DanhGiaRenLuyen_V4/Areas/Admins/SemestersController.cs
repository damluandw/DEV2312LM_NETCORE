using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DanhGiaRenLuyen_V4.Models.DBModel;
using Newtonsoft.Json;

namespace DanhGiaRenLuyen_V4.Areas.Admins
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

                return RedirectToAction(nameof(CreateQuestions), new { semesterId });
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
                int semesterId =  _context.Semesters.OrderByDescending(x=> x.Id).FirstOrDefault().Id;

                return RedirectToAction(nameof(Index), new { semesterId });
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
        public async Task<IActionResult> CreateQuestions(int semesterId)
        {
            var groupQuestions = _context.GroupQuestions.Include(u => u.QuestionLists).ThenInclude(u => u.QuestionHisories).Include(x => x.QuestionLists).ThenInclude(x => x.AnswerLists).ToList();
            return View(groupQuestions);
        }
        [HttpPost]
        public IActionResult CreateQuestions(Dictionary<int, int> AnswerIds, Dictionary<int, int> AnswerId)
        {
            if (ModelState.IsValid)
            {

                int semesterId = _context.Semesters.FirstOrDefault(x => x.IsActive == 1).Id;
                var student = JsonConvert.DeserializeObject<AccountStudent>(HttpContext.Session.GetString("StudentLogin"));
                // kiểm tra trạng thái acc (0: chưa đánh giá, 1: đã đánh giá, 2:không được đánh giá)
                int Iactive = _context.AccountStudents.Where(u => u.UserName == student.UserName).FirstOrDefault().IsActive.Value;
                //nếu như đã đánh giá
                if (Iactive == 1)
                {
                    // xoá tất cả đánh giá của sinh viên trong kì đang diễn ra
                    var selfAnswers = _context.SelfAnswers.Where(u => u.StudentId == student.UserName && u.SemesterId == semesterId).ToList();
                    _context.SelfAnswers.RemoveRange(selfAnswers);
                    // xoá điểm đánh giá trước đó
                    var sumaryOfPoint = _context.SumaryOfPoints.Where(x => x.StudentId == student.UserName && x.SemesterId == semesterId).ToList();
                    _context.SumaryOfPoints.RemoveRange(sumaryOfPoint);
                }
                //tạo đối tượng selfAnswer để thêm vào bảng Self Answer
                List<SelfAnswer> selfAnswer = new List<SelfAnswer>();
                foreach (var item in AnswerIds)
                {
                    selfAnswer.Add(new SelfAnswer
                    {
                        StudentId = student.UserName,
                        AnswerId = item.Value,
                        SemesterId = semesterId
                    });
                }
                foreach (var item in AnswerId)
                {
                    selfAnswer.Add(new SelfAnswer
                    {
                        StudentId = student.UserName,
                        AnswerId = item.Value,
                        SemesterId = semesterId
                    });

                }

                // thêm lại đánh giá của sinh viên đã chỉnh sửa
                foreach (var item in selfAnswer)
                {
                    _context.SelfAnswers.Add(item);

                }


                // tính tổng điểm sinh viên tự đánh giá
                var question = _context.QuestionLists.Include(u => u.AnswerLists).ThenInclude(u => u.SelfAnswers).ToList();
                var SelfAnswers = _context.SelfAnswers.Where(u => u.StudentId == student.UserName && u.SemesterId == semesterId).ToList();

                int sum = 0;
                foreach (var item in question)
                {
                    foreach (var answer in item.AnswerLists)
                    {
                        foreach (var self in answer.SelfAnswers)
                        {
                            sum += self.Answer.AnswerScore.Value;
                            if (item.TypeQuestionId == 3)
                            {
                                break;
                            }
                        }
                        if (item.TypeQuestionId == 3)
                        {
                            break;
                        }

                    }

                }

                // tạo sumaryOfPoint và thêm vào database
                SumaryOfPoint sumaryOfPoints = new SumaryOfPoint()
                {
                    StudentId = student.UserName,
                    SemesterId = semesterId,
                    SelfPoint = sum,
                    UpdateDate = DateTime.Now,
                };
                _context.SumaryOfPoints.Add(sumaryOfPoints);
                _context.AccountStudents.FirstOrDefault(x => x.StudentId == student.UserName).IsActive = 1;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

