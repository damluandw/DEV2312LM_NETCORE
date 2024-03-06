using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore_Lesson05.Models.ViewModel;

namespace NETCore_Lesson05.Controllers
{
    public class MemberAnnotationController : Controller
    {
        // GET: MemberAnnotationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MemberAnnotationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MemberAnnotationController/Create
        public ActionResult Create()
        {
            var member = new RegisterViewModel();
            return View(member);
        }

        // POST: MemberAnnotationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MemberAnnotationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MemberAnnotationController/Edit/5
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

        // GET: MemberAnnotationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MemberAnnotationController/Delete/5
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
