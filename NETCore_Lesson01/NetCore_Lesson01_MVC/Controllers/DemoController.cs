using Microsoft.AspNetCore.Mvc;

namespace NetCore_Lesson01_MVC.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
