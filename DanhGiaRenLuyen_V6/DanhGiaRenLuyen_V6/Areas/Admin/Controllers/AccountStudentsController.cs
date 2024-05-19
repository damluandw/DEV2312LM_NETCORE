using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using DanhGiaRenLuyen_V6.Models.DBModel;

namespace DanhGiaRenLuyen_V6.Areas.Admin.Controllers
{
    public class AccountStudentsController : BaseController
    {
        private readonly DanhGiaRenLuyenContext _context;

        public AccountStudentsController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }

        // GET: Admin/AccountStudents
        public async Task<IActionResult> Index(string? msv, bool? isDelete)
        {
            var DanhGiaRenLuyenContext = _context.AccountStudents.Include(a => a.Student);
            if (!msv.IsNullOrEmpty())
            {
                DanhGiaRenLuyenContext = _context.AccountStudents.Where(x => x.StudentId == msv).Include(a => a.Student);
            }
            ViewBag.IsDelete = isDelete;
            return View(await DanhGiaRenLuyenContext.OrderBy(x => x.IsActive).ToListAsync());
        }
        private bool AccountStudentExists(int id)
        {
            return _context.AccountStudents.Any(e => e.Id == id);
        }
        public IActionResult Active(string? msv,int? accId)
        {
            _context.AccountStudents.FirstOrDefault(x => x.Id == accId).IsActive = 1;
            _context.SaveChanges();
            return RedirectToAction("Index", new {msv = msv});
        }
        public IActionResult Passive(string? msv,int? accId)
        {
            _context.AccountStudents.FirstOrDefault(x => x.Id == accId).IsActive = 0;
            _context.SaveChanges();
            return RedirectToAction("Index", new { msv = msv });
        }
        public IActionResult ResetPassword(string? msv, int? accId)
        {
            _context.AccountStudents.FirstOrDefault(x => x.Id == accId).Password = "12345";
            _context.SaveChanges();
            return RedirectToAction("Index", new { msv = msv });
        }
    }
}
