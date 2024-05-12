using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using DanhGiaRenLuyen_V5.Models.DBModel;

namespace DanhGiaRenLuyen_V5.Areas.Lecturer.Controllers
{
	public class StudentController : BaseController
	{
		private readonly DanhGiaRenLuyenContext _context;
		public StudentController(DanhGiaRenLuyenContext context)
		{
			_context = context;
		}

		public IActionResult Index(string? name, int? classId)
		{
			var data = JsonConvert.DeserializeObject<AccountLecturer>(HttpContext.Session.GetString("LecturerLogin"));
			var departmentId = _context.Lecturers.FirstOrDefault(x => x.Id == data.LecturerId).DepartmentId.Value;
			var Class = _context.Classes.FirstOrDefault();
			var students = _context.Students.Where(u => u.Class.DepartmentId == departmentId && u.IsActive == 1).ToList();
            if (classId != null)
            {
                students = _context.Students.Where(u => u.ClassId == classId).Include(x => x.SumaryOfPoints).ToList();
                if (!name.IsNullOrEmpty())
                {
                    students = _context.Students.Where(u => u.ClassId == classId && u.FullName.Contains(name)).Include(x => x.SumaryOfPoints).ToList();
                }
            }
            else if (!name.IsNullOrEmpty())
            {
                students = _context.Students.Where(u => u.Class.DepartmentId == departmentId && u.FullName.Contains(name)).Include(x => x.SumaryOfPoints).ToList();
            }
            ViewBag.Name = name;
            ViewBag.ClassId = new SelectList(_context.Classes.Where(x => x.DepartmentId == departmentId), "Id", "Name");
            int semesterId = _context.Semesters.FirstOrDefault(x => x.IsActive >= 1)?.Id ?? 0;
            ViewBag.Check = _context.SumaryOfPoints.Where(x => x.SemesterId == semesterId).ToList();
			return View(students);
		}
	}
}
