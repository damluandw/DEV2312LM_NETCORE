using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using DanhGiaRenLuyen_V5.Models.DBModel;

namespace DanhGiaRenLuyen_V5.Areas.Student.ViewComponents
{
    public class InforStudentViewComponent : ViewComponent
    {
        private readonly DanhGiaRenLuyenContext _context;
        public InforStudentViewComponent(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string? id)
        {
            var acc = JsonConvert.DeserializeObject<AccountStudent>(HttpContext.Session.GetString("StudentLogin"));
            var student = _context.Students.Include(x => x.SumaryOfPoints).FirstOrDefault(x => x.Id == acc.StudentId);
            if (!id.IsNullOrEmpty()) {
                student = _context.Students.Include(x => x.SumaryOfPoints).FirstOrDefault(x => x.Id == id);
            }
            return View(student);
        }

    }
}
