using Microsoft.AspNetCore.Mvc;
using NETCORE_Lesson10.Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace NETCORE_Lesson10.Controllers
{
    public class LoginController : Controller
    {
        private readonly Lesson10DbContext _context;

        public LoginController(Lesson10DbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //Lấy dữ liệu session -> chuyển lên giao diện hiển thị
            var jsonCustomer = HttpContext.Session.GetString("AdminLogin");
            if (!string.IsNullOrEmpty(jsonCustomer)){
                //Chuyển dữ liệu từ dạng json sang dạng customer
                var CustomerModel = JsonConvert.DeserializeObject<Customer>(jsonCustomer);
                return View(CustomerModel);
            }
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Login( )
        {
            var modelLogin = new ModelLogin();
           
            return View(modelLogin);
        }
        [HttpPost]
        public IActionResult Login(ModelLogin modelLogin)
        {

            // kiểm tra trong db xem có tài khoản trong db hay không
            // nếu có thì lưu vào trong session
            var dataLogin = _context.Customers.FirstOrDefault(x => x.Username.Equals(modelLogin.Username) && x.Password.Equals(modelLogin.Password));

            if(dataLogin != null)
            {
                ViewBag.Login = "Đăng nhập thành công";
                string customerLogin;
                //customerLogin = JsonSerializer.Serialize(dataLogin);
                customerLogin = JsonConvert.SerializeObject(dataLogin);
                HttpContext.Session.SetString("AdminLogin", customerLogin);
                return RedirectToAction("Index");
            }
            // lưu session đăng nhập

            ViewBag.Login = "Sai thông tin đăng nhập";
            return View(modelLogin);
        }
   
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdminLogin");
            return RedirectToAction("Login");
        }
    }
}
