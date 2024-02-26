using Microsoft.AspNetCore.Mvc;
using NETCore_Lesson02_Lab1.Models;

namespace NETCore_Lesson02_Lab1.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>()
            {
                new Account()
                {
                      Id = 1,
                      Name = "Name Test 1",
                      Email = "EmailTest1@gmail.com",
                      Phone = "0564651223",
                      Avatar = Url.Content("~/avatar/avatar1.jpg"),
                      Address    = "Address Test 1",
                      Bio = "Bio Test 1",
                      Gender = 1,
                     Birthday =  Convert.ToDateTime("2000-01-06")
                },
                 new Account()
                {
                      Id = 2,
                      Name = "Name Test 2",
                      Email = "EmailTest2@gmail.com",
                      Phone = "0564652223",
                      Avatar = Url.Content("~/avatar/avatar2.jpg"),
                      Address    = "Address Test 2",
                      Bio = "Bio Test 2",
                      Gender = 2,
                     Birthday =  Convert.ToDateTime("2000-02-06")
                },
                new Account()
                {
                      Id = 3,
                      Name = "Name Test 3",
                      Email = "EmailTest3@gmail.com",
                      Phone = "0564653333",
                      Avatar = Url.Content("~/avatar/avatar3.jpg"),
                      Address    = "Address Test 3",
                      Bio = "Bio Test 3",
                      Gender = 1,
                     Birthday =  Convert.ToDateTime("2001-03-06")
                }, new Account()
                {
                      Id = 4,
                      Name = "Name Test 4",
                      Email = "EmailTest4@gmail.com",
                      Phone = "0564654444",
                      Avatar = Url.Content("~/avatar/avatar4.jpg"),
                      Address    = "Address Test 4",
                      Bio = "Bio Test 4",
                      Gender = 1,
                     Birthday =  Convert.ToDateTime("1998-04-06")
                }

            };
            ViewBag.Accounts = accounts;
            return View();
        }

        [Route("ho-so-cua-toi", Name ="profile")]
        public IActionResult Profile()
        {
            Account account =  new Account()
            {
                Id = 1,
                Name = "Name Test 1",
                Email = "EmailTest1@gmail.com",
                Phone = "0564651223",
                Avatar = Url.Content("~/avatar/avatar1.jpg"),
                Address = "Address Test 1",
                Bio = "Bio Test 1",
                Gender = 1,
                Birthday = Convert.ToDateTime("2000-01-06")
            };
            ViewBag.account = account;
            return View();
        }
    }
}
