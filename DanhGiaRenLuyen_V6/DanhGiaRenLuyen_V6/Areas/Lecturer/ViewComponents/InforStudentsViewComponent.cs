using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using DanhGiaRenLuyen_V6.Models.DBModel;

namespace DanhGiaRenLuyen_V6.Areas.Lecturer.ViewComponents
{
    public class InforStudentsViewComponent : ViewComponent
    {
        private readonly DanhGiaRenLuyenContext _context;
        public InforStudentsViewComponent(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string? id)
        {
            var student = _context.Students.Include(x => x.SumaryOfPoints).FirstOrDefault();
            if (!id.IsNullOrEmpty())
            {
                student = _context.Students.Include(x => x.SumaryOfPoints).FirstOrDefault(x => x.Id == id);
            }
            return View(student);
        }

    }
}
