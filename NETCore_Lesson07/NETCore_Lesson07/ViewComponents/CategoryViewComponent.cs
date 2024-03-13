using Microsoft.AspNetCore.Mvc;
using NETCore_Lesson07.Models;

namespace NETCore_Lesson07.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private BookStoreDbContext dbContext = new BookStoreDbContext();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = dbContext.Categories.ToList();
            return View(list);  
        }
    }
}
