using Microsoft.AspNetCore.Mvc;

namespace NETCore_Lesson12_Authentication2.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
