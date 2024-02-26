using Microsoft.AspNetCore.Mvc;
using NETCore_Lesson02.Models;

namespace NETCore_Lesson02.Controllers
{
    //[Route("danh-sach-san-pham")]
    public class ProductController : Controller
    {
        //[Route("index")]
        public IActionResult Index()
        {
            //dữ liệu từ controller ra view
            ViewBag.product = "Dữ liệu trong view bag";
            ViewData["ProductVD"] = "Dữ liệu trong View Data -> ProductVD";
            TempData["messageVD"] = "Thông báo dữ liệu từ TempData";
            // trả về view: View/Product/Index.cshtml
            return View();
        }
        //[Route("san-pham")]
        public IActionResult GetProduct()
        {
            //Dữ liệu dạng product
            Product p = new Product()
            {
                Id = 1,
                Name = "Test Product",
            };
            ViewBag.product = p;
            return View();
        }

        //[Route("tat-ca")]
        public IActionResult GetAllProduct()
        {

            List<Product> product = new List<Product>()
            {
              new Product(){Id = 1, Name = "Test Product 1"},

              new Product(){Id = 2, Name = "Test Product 2"},
              new Product(){Id = 3, Name = "Test Product 3"},
              new Product(){Id = 4, Name = "Test Product 4"},
              new Product(){Id = 5, Name = "Test Product 5"}
            };
            ViewData["list"] = product;
            // trả về view: View/Products/Products.cshtml
            return View("Products");
        }
    }
}
