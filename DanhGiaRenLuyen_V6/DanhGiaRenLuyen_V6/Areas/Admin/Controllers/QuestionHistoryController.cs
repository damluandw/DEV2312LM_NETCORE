﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DanhGiaRenLuyen_V6.Models.DBModel;

namespace DanhGiaRenLuyen_V6.Areas.Admin.Controllers
{
    public class QuestionHistoryController : BaseController
    {
        private readonly DanhGiaRenLuyenContext _context;

        public QuestionHistoryController(DanhGiaRenLuyenContext context)
        {
            _context = context;
        }

        // GET: Admin/QuestionHisories
        public async Task<IActionResult> Index(int? semesterId)
        {
            if(semesterId != null)
            {
                var DanhGiaRenLuyenContext = _context.QuestionHisories.Where(x => x.SemesterId == semesterId).Include(q => q.Question).Include(q => q.Semester);
                ViewBag.SemesterId = semesterId;
                ViewBag.SemesterYear = _context.Semesters.FirstOrDefault(x => x.Id == semesterId)?.SchoolYear;
                return View(await DanhGiaRenLuyenContext.ToListAsync());
            }
            else
            {
                return NotFound();
            }

        }

        // GET: Admin/QuestionHisories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionHisory = await _context.QuestionHisories
                .Include(q => q.Question).ThenInclude(x => x.AnswerLists.Where(x => x.IsEdit == true))
                .Include(q => q.Semester)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionHisory == null)
            {
                return NotFound();
            }

            return View(questionHisory);
        }
    }
}
