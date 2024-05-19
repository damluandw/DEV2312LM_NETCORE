using Microsoft.AspNetCore.Mvc;
using DanhGiaRenLuyen_V6.Models.DBModel;

namespace DanhGiaRenLuyen_V6.Areas.Student.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
