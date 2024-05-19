using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DanhGiaRenLuyen_V6.Models.DBModel;

namespace DanhGiaRenLuyen_V6.Areas.Admin.ViewComponents
{
    public class ReportViewComponent : ViewComponent
    {
        private readonly DanhGiaRenLuyenContext _context;
        public ReportViewComponent(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(bool isDelete)
        {
            ViewBag.IsDelete = isDelete;
            var department = await _context.Departments.ToListAsync();
            return View(department);
        }
    }
}
