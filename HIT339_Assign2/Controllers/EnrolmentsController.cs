﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HIT339_Assign2.Data;
using Microsoft.AspNetCore.Identity;
using HIT339_Assign2.Areas.Identity.Data;

namespace HIT339_Assign2.Controllers
{
    public class EnrolmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        UserManager<ApplicationUser> _userManager;

        public EnrolmentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Enrolments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Enrolment.Include(e => e.Schedule).Include(e => e.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Enrolments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolment = await _context.Enrolment
                .Include(e => e.Schedule)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrolment == null)
            {
                return NotFound();
            }

            return View(enrolment);
        }

        // GET: Enrolments/Create
        public IActionResult Create()
        {
            ViewData["ScheduleId"] = new SelectList(_context.Schedule, "Id", "Id");
            ViewData["ScheduleName"] = new SelectList(_context.Schedule, "Id", "Eventname");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["UserName"] = new SelectList(_userManager.GetUsersInRoleAsync("Member").Result, "Id", "UserName");
            return View();
        }

        // POST: Enrolments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ScheduleId,UserId")] Enrolment enrolment)
        {
            if (ModelState.IsValid)
            {
                enrolment.Schedule = _context.Schedule.Where(c => c.Id == enrolment.ScheduleId).FirstOrDefault();
                if (enrolment.Schedule == null || enrolment.Schedule.Eventdatetime <= DateTime.Now)
                {
                    return Content(@"<script>alert('The time has expired');window.location.href='/Enrolments/Create';</script>", "text/html");
                }

                _context.Add(enrolment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ScheduleId"] = new SelectList(_context.Schedule, "Id", "Id");
            ViewData["ScheduleName"] = new SelectList(_context.Schedule, "Id", "Eventname");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["UserName"] = new SelectList(_userManager.GetUsersInRoleAsync("Member").Result, "Id", "UserName");
            return View(enrolment);
        }

        // GET: Enrolments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolment = await _context.Enrolment.FindAsync(id);
            if (enrolment == null)
            {
                return NotFound();
            }
            ViewData["ScheduleId"] = new SelectList(_context.Schedule, "Id", "Id");
            ViewData["ScheduleName"] = new SelectList(_context.Schedule, "Id", "Eventname");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["UserName"] = new SelectList(_userManager.GetUsersInRoleAsync("Member").Result, "Id", "UserName");
            return View(enrolment);
        }

        // POST: Enrolments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ScheduleId,UserId")] Enrolment enrolment)
        {
            if (id != enrolment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    enrolment.Schedule = _context.Schedule.Where(c => c.Id == enrolment.ScheduleId).FirstOrDefault();
                    if (enrolment.Schedule == null || enrolment.Schedule.Eventdatetime <= DateTime.Now)
                    {
                        return Content(@"<script>alert('The time has expired');window.location.href='/Enrolments/Edit/"+ enrolment.Id + "';</script>", "text/html");
                    }
                    _context.Update(enrolment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrolmentExists(enrolment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ScheduleId"] = new SelectList(_context.Schedule, "Id", "Id", enrolment.ScheduleId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", enrolment.UserId);
            return View(enrolment);
        }

        // GET: Enrolments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolment = await _context.Enrolment
                .Include(e => e.Schedule)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrolment == null)
            {
                return NotFound();
            }

            return View(enrolment);
        }

        // POST: Enrolments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrolment = await _context.Enrolment.FindAsync(id);
            _context.Enrolment.Remove(enrolment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrolmentExists(int id)
        {
            return _context.Enrolment.Any(e => e.Id == id);
        }
    }
}
