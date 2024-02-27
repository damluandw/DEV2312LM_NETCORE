using Microsoft.AspNetCore.Mvc;
using NETCore_Lesson02_Lab1.Models;

namespace NETCore_Lesson02_Lab1.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = new List<Product>()
            {

             new Product()
             {
                   Id = 1,
                   Name = "Product Test 1",
                   Image =  Url.Content("~/avatar/product1.jpg"),
                   Price = 600000,
                   SalePrice = 500000,
                   CategoryId = 1,
                   Description = "Description 1",
                   Status = 1,
                   CreateAt =  Convert.ToDateTime("2024-12-06")
             },
             new Product()
             {
                  Id = 2,
                   Name = "Product Test 2",
                   Image =  Url.Content("~/avatar/product2.jpg"),
                   Price = 600000,
                   SalePrice = 500000,
                   CategoryId = 2,
                   Description = "Description 2",
                   Status = 2,
                   CreateAt =  Convert.ToDateTime("2024-08-06")
             },
             new Product()
             {
                   Id = 3,
                   Name = "Product Test 3",
                   Image =  Url.Content("~/avatar/product3.jpg"),
                   Price = 600000,
                   SalePrice = 500000,
                   CategoryId = 2,
                   Description = "Description 3",
                   Status = 2,
                   CreateAt =  Convert.ToDateTime("2024-09-06")
             },
             new Product()
             {
                   Id = 4,
                   Name = "Product Test 4",
                   Image =  Url.Content("~/avatar/product4.jpg"),
                   Price = 600000,
                   SalePrice = 500000,
                   CategoryId = 2,
                   Description = "Description 4",
                   Status = 2,
                   CreateAt =  Convert.ToDateTime("2024-03-17")
             },
             new Product()
             {
                   Id = 5,
                   Name = "Product Test 5",
                   Image =  Url.Content("~/avatar/product5.jpg"),
                   Price = 600000,
                   SalePrice = 500000,
                   CategoryId = 2,
                   Description = "Description 5",
                   Status = 2,
                   CreateAt =  Convert.ToDateTime("2024-05-06")
             },
            };
            ViewBag.Products = products;
            return View();
        }
    }
}
