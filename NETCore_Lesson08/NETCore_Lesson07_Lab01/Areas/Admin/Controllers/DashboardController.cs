using Microsoft.AspNetCore.Mvc;

namespace NETCore_Lesson07_Lab01.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
