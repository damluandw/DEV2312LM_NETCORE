﻿using Microsoft.AspNetCore.Mvc;
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

            List<Category> categories = new List<Category>() {
                new Category() { Id = 1, Name ="Quần áo"},
                new Category() { Id = 2, Name ="Túi xách"},
                new Category() { Id = 3, Name ="Đồng hồ"},
                new Category() { Id = 4, Name ="Ti vi"},
                new Category() { Id = 5, Name ="Tủ lạnh"},
                new Category() { Id = 6, Name ="Máy bơm"},
                new Category() { Id = 7, Name ="Quạt điện"},
                new Category() { Id = 8, Name ="Lò sưởi"},
            };
            ViewBag.Categories = categories;
            return View();
        }

        //[Route("san-pham", Name = "Product")]
        public IActionResult Product()
        {
            Product product = new Product()
            {
                Id = 1,
                Name = "Product Test 1",
                Image = Url.Content("~/avatar/product1.jpg"),
                Price = 600000,
                SalePrice = 500000,
                CategoryId = 1,
                Description = "Description 1",
                Status = 1,
                CreateAt = Convert.ToDateTime("2024-12-06")
            };
            ViewBag.Product = product;
            return View();
        }
    }
}
