using Microsoft.AspNetCore.Mvc;
using DanhGiaRenLuyen_V5.Areas.Admin.Controllers;

namespace DanhGiaRenLuyen_V5.Areas.Admins.Controllers
{

    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
