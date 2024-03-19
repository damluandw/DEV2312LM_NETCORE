using Microsoft.AspNetCore.Mvc;

namespace NETCore_Lesson07_LabTuLam.Areas.Admin.ViewComponents
{
    public class NavLeftViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
