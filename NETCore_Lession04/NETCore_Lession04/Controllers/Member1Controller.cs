using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore_Lession04.Models.DataModels;
using System.Diagnostics.Metrics;

namespace NETCore_Lession04.Controllers
{
    public class Member1Controller : Controller
    {
        private static List<Member> members = new List<Member>()
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

        // GET: Member1Controller
        public ActionResult Index()
        {
            return View(members);
        }

        // GET: Member1Controller/Details/5
        public ActionResult Details(string id)
        {
            Member member = members.FirstOrDefault(m => m.MemberId == id);
            return View(member);
        }

        // GET: Member1Controller/Create
        public ActionResult Create()
        {
           Member member = new Member();
            return View(member);
        }

        // POST: Member1Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            try
            {
                member.MemberId = Guid.NewGuid().ToString();
                members.Add(member);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Member1Controller/Edit/5
        public ActionResult Edit(string id)
        {
            Member member = members.FirstOrDefault(m => m.MemberId == id);
            return View(member);
        }

        // POST: Member1Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Member member)
        {
            try
            {
                for(int i = 0;i<=members.Count; i++)
                {
                    if (members[i].MemberId == member.MemberId)
                    {
                        members[i] = member;
                        break;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Member1Controller/Delete/5
        public ActionResult Delete(string id)
        {
            Member member = members.FirstOrDefault(m => m.MemberId == id);
            return View(member);
        }

        // POST: Member1Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Member member)
        {
            try
            {
                //members.Remove(member);
                for (int i = 0; i <= members.Count; i++)
                {
                    if (members[i].MemberId == id)
                    {
                        members.RemoveAt(i);
                        break;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
