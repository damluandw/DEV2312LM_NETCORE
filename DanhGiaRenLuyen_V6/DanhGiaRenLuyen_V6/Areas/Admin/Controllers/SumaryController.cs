using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DanhGiaRenLuyen_V6.Models.DBModel;

namespace DanhGiaRenLuyen_V6.Areas.Admin.Controllers
{
    public class SumaryController : BaseController
    {
        private readonly DanhGiaRenLuyenContext _context;
        public SumaryController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? semesterId, int? classId)
        {
            if(semesterId == null)
            {
                semesterId = _context.Semesters.OrderByDescending(x => x.Id).FirstOrDefault(x => x.IsActive == 1).Id;
            }
            if(classId == null)
            {
                classId = _context.Classes.FirstOrDefault(x => x.IsDelete == false).Id;
            }

            var sum = _context.SumaryOfPoints.Include(x => x.Student).Include(x => x.Class).ThenInclude(x => x.Department).Where(x => x.ClassId == classId && x.SemesterId == semesterId);
            ViewBag.Class = _context.Classes.Include(x => x.Department).Include(x => x.Students).ThenInclude(x => x.SumaryOfPoints).ToList();
            ViewData["Semester"] = _context.Semesters.OrderByDescending(x => x.Id).Where(x => x.IsActive == 1).ToList();
            ViewBag.SemesterId = semesterId;
            ViewBag.ClassId = classId;
            ViewBag.Student = _context.Students.Include(x => x.SumaryOfPoints).Where(x => !x.SumaryOfPoints.Where(x => x.SemesterId == semesterId).Any()).ToList();
            return View(sum);
        }
    }
}
