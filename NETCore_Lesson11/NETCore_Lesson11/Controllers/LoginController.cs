using Microsoft.AspNetCore.Mvc;
using NETCore_Lesson11.Models;
using NuGet.Protocol.Plugins;
using System.Text;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace NETCore_Lesson11.Controllers
{
    public class LoginController : Controller
    {
        private readonly DevXuongMocContext _context;

        public LoginController(DevXuongMocContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var modelLogin = new Customer();
            return View(modelLogin);
        }

        [HttpPost]
        public IActionResult Index(Customer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // xử lý phần logic đăng nhaapjh tại đây
            var pass = getHashSha256(model.Password);
            //var pass = model.Password;
            var dataLogin = _context.AdminUsers.Where(x => x.Email.Equals(model.Email) && x.Password.Equals(pass)).FirstOrDefault();
            if (dataLogin != null)
            {
                ViewBag.Login = "Đăng nhập thành công";
                HttpContext.Session.SetString("AdminLogin", model.Email);
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
                var hashdBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                hash = BitConverter.ToString(hashdBytes).Replace("-", "").ToLower();
            }
            return hash;
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdminLogin");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            var modelLogin = new Customer();
            return View(modelLogin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("ID, NAME, USERNAME, PASSWORD, ADDRESS, EMAIL, PHONE, AVATAR, CREATE_DATE, UPDATE_DATE, CREATE_BY, UPDATE_BY, ISDELETE, ISACTIVE")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
    }
}
