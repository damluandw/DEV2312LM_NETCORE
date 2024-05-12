using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using DanhGiaRenLuyen_V5.Models.DBModel;

namespace DanhGiaRenLuyen_V5.Areas.Student.ViewComponents
{
    public class STViewComponent : ViewComponent
    {
        private readonly DanhGiaRenLuyenContext _context;
        public STViewComponent(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string? name,int? classId)
        {
            var data = JsonConvert.DeserializeObject<AccountLecturer>(HttpContext.Session.GetString("LecturerLogin"));
            var departmentId = _context.Lecturers.FirstOrDefault(x => x.Id == data.LecturerId).DepartmentId.Value;
            var Class = _context.Classes.FirstOrDefault();
            var students = _context.Students.Where(u => u.Class.DepartmentId == departmentId).Include(x => x.SumaryOfPoints).ToList();
            if(classId != null)
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
            return View(students);
        }
    }
}
