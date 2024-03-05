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
        public ActionResult Create(IFormCollection collection)
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
