using Microsoft.AspNetCore.Mvc;

namespace NetCore_Lesson01_MVC_LAB1.Controllers
{
    public class IntroduceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
