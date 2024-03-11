﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore_Lesson05_Lab01.Models;
using System.Text.RegularExpressions;

namespace NETCore_Lesson05_Lab01.Controllers
{
    public class AccountController : Controller
    {
        
        // GET: AccountController
        public ActionResult Index()
        {
            List<Account> accounts = new List<Account>();
            return View(accounts);
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            Account account = new Account();
            return View(account);
        }

        [AcceptVerbs("GET","POST")]
        public IActionResult VerifyPhone( string phone)
        {
            Regex _isPhone = new Regex(@"^\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})$");
            if (_isPhone.IsMatch(phone))
            {
                return Json($"Số điện thoại {phone} Không đúng định dạng, VS: 0984211127 hoặc  098.421.1127");

            }
            return Json(true);
        }

        // POST: AccountController/Create
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

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
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

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
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