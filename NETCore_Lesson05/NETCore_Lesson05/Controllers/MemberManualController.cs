using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore_Lesson05.Models.DataModel;
using System.Text.RegularExpressions;

namespace NETCore_Lesson05.Controllers
{
    public class MemberManualController : Controller
    {
        private List<Member> members = new List<Member>()
            {
                new Member()
        {
            MemberId = Guid.NewGuid().ToString(),UserName = "damluan",FullName = "Name 1",Password = "12345",Email = "user1@gmail.com", Phone ="0654123654" , Birthday = Convert.ToDateTime("2013/09/02")
                },
                 new Member()
        {
            MemberId = Guid.NewGuid().ToString(),UserName = "user2",FullName = "Name 2",Password = "12345",Email = "user871@gmail.com", Phone ="0654123654" , Birthday = Convert.ToDateTime("2013/09/02")
                },
                  new Member()
        {
            MemberId = Guid.NewGuid().ToString(),UserName = "user3",FullName = "Name 3",Password = "12345",Email = "user17@gmail.com", Phone ="0654123654" , Birthday = Convert.ToDateTime("2013/09/02")
                },
                   new Member()
        {
            MemberId = Guid.NewGuid().ToString(),UserName = "user4",FullName = "Name 4",Password = "12345",Email = "user147@gmail.com", Phone ="0654123654" , Birthday = Convert.ToDateTime("2013/09/02")
                },
                    new Member()
        {
            MemberId = Guid.NewGuid().ToString(),UserName = "user5",FullName = "Name 5",Password = "12345",Email = "user1787@gmail.com", Phone ="0654123654" , Birthday = Convert.ToDateTime("2013/09/02")
                },
            };
    // GET: MemberManualController
    public ActionResult Index()
        {
            return View(members);
        }

        // GET: MemberManualController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MemberManualController/Create
        public ActionResult Create()
        {
            var member = new Member();
            return View(member);
        }

        // POST: MemberManualController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            string msg = null;
            bool validate = true;
            if(string.IsNullOrEmpty(member.UserName))
            {
                msg = "<li>Chưa nhập UserName </li>";
                validate = false;
            }
            else if(member.UserName.Length < 3 || member.UserName.Length > 20)
            {
                msg = "<li>Tên đăng nhập phải có độ dài từ 3-19 ký tự </li>";
                validate = false;
            }
            string patternemail = @"[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            if (string.IsNullOrEmpty(member.Email))
            {
                msg += "<li>Chưa nhập Email </li>";
                validate = false;
            }
            else if (!Regex.IsMatch(member.Email, patternemail))
            {
                msg += "<li>Email không đúng đinh dạng </li>";
                validate = false;
            }
            if(member.Birthday.AddYears(18) > DateTime.Now)
            {
                msg += "<li>Bạn chưa đủ 18 tuổi</li>";
                validate = false;
            }
            if (validate)
            {
                member.MemberId =Guid.NewGuid().ToString();
                members.Add(member);
                return RedirectToAction("Index");
            }
            msg = "<div class ='alter alter-danger'>" + msg + "</div>";
            ViewBag.msg = msg;
            return View();
           
        }

        // GET: MemberManualController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MemberManualController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MemberManualController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MemberManualController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
