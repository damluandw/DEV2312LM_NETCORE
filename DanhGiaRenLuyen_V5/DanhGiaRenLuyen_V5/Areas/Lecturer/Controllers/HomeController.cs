using Microsoft.AspNetCore.Mvc;

namespace DanhGiaRenLuyen_V5.Areas.Lecturer.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
