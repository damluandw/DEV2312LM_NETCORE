using Microsoft.AspNetCore.Mvc;
using NETCore_Lesson07.Models;

namespace NETCore_Lesson07.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        //lấy dữ liệu
        private BookStoreDbContext dbContext = new BookStoreDbContext();

        private BookStoreDbContext bookStoreDbContext = new BookStoreDbContext();
        public CategoryViewComponent(BookStoreDbContext context) {
            dbContext = context;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = dbContext.Categories.ToList();
            return View(list);  
        }
    }
}
