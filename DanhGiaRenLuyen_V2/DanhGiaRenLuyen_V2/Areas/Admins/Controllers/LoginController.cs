﻿using Microsoft.AspNetCore.Mvc;
using DanhGiaRenLuyen_V2.Areas.Admins.Models;
using DanhGiaRenLuyen_V2.Models;
using System.Security.Cryptography;
using System.Text;
using DanhGiaRenLuyen_V2.Models.DBModel;

namespace DanhGiaRenLuyen_V2.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class LoginController : Controller
    {
        private readonly DanhGiaRenLuyenContext _context;

        public LoginController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var modelLogin = new Login();
            return View(modelLogin);
        }
        [HttpPost]
        public IActionResult Index(Login model)
        {
            if(!ModelState.IsValid)
            {
                return  View(model);
            }
            // xử lý phần logic đăng nhaapjh tại đây
            //var pass = getHashSha256(model.Password);
            var pass = model.Password;
            var dataLogin = _context.AccountAdmins.Where(x=> x.UserName.Equals(model.UserName) && x.Password.Equals(pass)).FirstOrDefault();
            if(dataLogin != null)
            {
                ViewBag.Login = "Đăng nhập thành công";
                HttpContext.Session.SetString("AdminLogin", model.UserName);
                return RedirectToAction("Index", "Dashboard");
            }
            // Lưu session khi đăng nhập thành công
            ViewBag.Login = "Sai thông tin đăng nhập";
            return View(model);
        }
        public static string getHashSha256(string text)
        {
            string hash = "";
            using (var sha256 = new SHA256Managed())
            {
                var hashdBytes  =sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                hash = BitConverter.ToString(hashdBytes).Replace("-","").ToLower();
            }
            return hash;
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdminLogin");
            return RedirectToAction("Index");
        }
    }
}
