using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore_Lesson04_Lab01.Models;

namespace NETCore_Lesson04_Lab01.Controllers
{
    public class PeopleController : Controller
    {
        // GET: PeopleController
        public ActionResult Index()
        {
            var _people = DataLocal.GetPeoples();
            return View(_people);
        }

        // GET: PeopleController/Details/5
        public ActionResult Details(int id)
        {
            var _people = DataLocal.GetPeopleById(id);
            return View(_people);
        }

        // GET: PeopleController/Create
        public ActionResult Create()
        {
            People _people = new People();
            return View(_people);
        }

        // POST: PeopleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(People model)
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count() > 0 && files[0].Length >0)
                {
                    var file = files[0];
                    var FileName = file.FileName;
                    //Nhớ tạo thư mục avatar trong thư mục wwwroot/images
                    //using System.IO;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\avatar", FileName);
                    using(var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        model.Avatar = "images/avatar/" +FileName; //gán tên ảnh cho thuộc tính avatar
                    }
                }
                // thêm peoples vào danh sách DataLocal
                DataLocal._people.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: PeopleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PeopleController/Edit/5
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

        // GET: PeopleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PeopleController/Delete/5
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
