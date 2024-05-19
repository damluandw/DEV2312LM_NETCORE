using Microsoft.AspNetCore.Mvc;
using DanhGiaRenLuyen_V6.Areas.Admin.Controllers;

namespace DanhGiaRenLuyen_V6.Areas.Admins.Controllers
{

    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
