using Microsoft.AspNetCore.Mvc;
using DanhGiaRenLuyen_V5.Models.DBModel;

namespace DanhGiaRenLuyen_V5.Areas.Student.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
