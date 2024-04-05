using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NETCore_Lesson11.Models;
using Newtonsoft.Json;

namespace NETCore_Lesson11.Controllers
{
    public class CartController : Controller, IActionFilter
    {
        private readonly DevXuongMocContext _context;
        private List<Cart> carts = new List<Cart>();
        public CartController(DevXuongMocContext context)
        {
            _context = context;
        }
        
        
        // GET: Products
        public override void OnActionExecuting(ActionExecutingContext  context)
        {
            string? cartInSession = HttpContext.Session.GetString("My-Cart");
            if (cartInSession != null)
            {
                //nếu CartInSession không null thì gán dữ liệu cho biến carts
                //Chuyển san dữ liệu json
                carts = JsonConvert.DeserializeObject<List<Cart>>(cartInSession);
            }
            base.OnActionExecuting(context);
        }

        public IActionResult Index()
        {
            float total = 0;
            foreach (var cart in carts)
            {
                total += cart.Quantity * cart.Price;
            }
            ViewBag.total = total;
            return View(carts);
        }

        public IActionResult Add(int id)
        {
            if (carts.Any(c => c.Id == id))
            {
                carts.Where(c => c.Id == id).First().Quantity += 1;
            }
            else
            {
                var p = _context.Products.Find(id);
                var item = new Cart()
                {
                    Id = p.Id,
                    Name = p.Title,
                    Price = (float)p.PriceNew.Value,
                    Quantity = 1,
                    Image = p.Image,
                    Total = (float)p.PriceNew.Value * 1
                };
                carts.Add(item);
            }
            HttpContext.Session.SetString("My-Cart", JsonConvert.SerializeObject(carts));
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            if (carts.Any(c => c.Id == id))
            {
                var item = carts.Where(c => c.Id == id).First();
                carts.Remove(item);
                HttpContext.Session.SetString("My-Cart", JsonConvert.SerializeObject(carts));
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id, int quatity)
        {

            if (carts.Any(c => c.Id == id))
            {
                var item = carts.Where(c => c.Id == id).First().Quantity = quatity;
                HttpContext.Session.SetString("My-Cart", JsonConvert.SerializeObject(carts));
            }
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove("My-Cart");
            return RedirectToAction("Index");
        }
    }
}
