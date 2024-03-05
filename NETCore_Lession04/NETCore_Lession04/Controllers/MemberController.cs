using Microsoft.AspNetCore.Mvc;
using NETCore_Lession04.Models.DataModels;

namespace NETCore_Lession04.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            //tạo đối tượng dữ liệu member
            var member = new Member();
            member.MemberId = Guid.NewGuid().ToString();
            member.UserName = "damluan";
            member.FullName = "Dam Van Luan";
            member.Password = "12345";
            member.Email = "damluan7@gmail.com";
            //truyền dữ liệu ra view
            ViewBag.member = member;
            return View();
        }

        public IActionResult GetListMember()
        {
            var members = new List<Member>()
            {
                new Member(){
                    MemberId = Guid.NewGuid().ToString(),UserName = "damluan",FullName = "Name 1",Password = "12345",Email = "user1@gmail.com"
                },
                 new Member(){
                    MemberId = Guid.NewGuid().ToString(),UserName = "user2",FullName = "Name 2",Password = "12345",Email = "user871@gmail.com"
                },
                  new Member(){
                    MemberId = Guid.NewGuid().ToString(),UserName = "user3",FullName = "Name 3",Password = "12345",Email = "user17@gmail.com"
                },
                   new Member(){
                    MemberId = Guid.NewGuid().ToString(),UserName = "user4",FullName = "Name 4",Password = "12345",Email = "user147@gmail.com"
                },
                    new Member(){
                    MemberId = Guid.NewGuid().ToString(),UserName = "user5",FullName = "Name 5",Password = "12345",Email = "user1787@gmail.com"
                },
            };

            ViewBag.members = members;
            return View();

        }

        public IActionResult IndexModel()
        {
            //tạo đối tượng dữ liệu member
            var member = new Member();
            member.MemberId = Guid.NewGuid().ToString();
            member.UserName = "damluan";
            member.FullName = "Dam Van Luan";
            member.Password = "12345";
            member.Email = "damluan7@gmail.com";
            //truyền dữ liệu ra view
            //ViewBag.member = member;
            return View(member);
        }
        public IActionResult ListModel()
        {
            var members = new List<Member>()
            {
                new Member(){
                    MemberId = Guid.NewGuid().ToString(),UserName = "damluan",FullName = "Name 1",Password = "12345",Email = "user1@gmail.com"
                },
                 new Member(){
                    MemberId = Guid.NewGuid().ToString(),UserName = "user2",FullName = "Name 2",Password = "12345",Email = "user871@gmail.com"
                },
                  new Member(){
                    MemberId = Guid.NewGuid().ToString(),UserName = "user3",FullName = "Name 3",Password = "12345",Email = "user17@gmail.com"
                },
                   new Member(){
                    MemberId = Guid.NewGuid().ToString(),UserName = "user4",FullName = "Name 4",Password = "12345",Email = "user147@gmail.com"
                },
                    new Member(){
                    MemberId = Guid.NewGuid().ToString(),UserName = "user5",FullName = "Name 5",Password = "12345",Email = "user1787@gmail.com"
                },
            };
            return View(members);

        }

        public IActionResult Create()
        {
            var member = new Member();
            return View(member);
        }
    }
}
