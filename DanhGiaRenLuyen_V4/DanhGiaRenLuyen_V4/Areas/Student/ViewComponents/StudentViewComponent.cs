using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using DanhGiaRenLuyen_V4.Models.DBModel;

namespace DanhGiaRenLuyen_V4.Areas.Student.ViewComponents
{
    public class StudentViewComponent : ViewComponent
    {
        private readonly DanhGiaRenLuyenContext _context;
        public StudentViewComponent(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string? name)
        {
            var student = HttpContext.Session.GetString("LTLogin");
            var LTLogin = _context.Students.FirstOrDefault(x => x.Id == student);
            int semesterId = _context.Semesters.FirstOrDefault(x => x.DateEndLecturer >= DateTime.Now)?.Id ?? 0;

            var students = _context.Students.Include(x => x.SumaryOfPoints.Where(x => x.SemesterId == semesterId)).Where(u => u.ClassId == LTLogin.ClassId).ToList();

            if (!name.IsNullOrEmpty())
            {
                students = _context.Students.Where(u => u.ClassId == LTLogin.ClassId && u.FullName.Contains(name)).ToList();
            }
            return View(students);
        }
    }
}
