using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HIT339_Assign2.Data;
using Microsoft.AspNetCore.Authorization;
using HIT339_Assign2.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using HIT339_Assign2.Models;

namespace HIT339_Assign2.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SchedulesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {

            var SchedulesVM = new ScheduleViewModel
            {
                Schedules = _context.Schedule.ToList(),
                Coachs = (List<ApplicationUser>)_userManager.GetUsersInRoleAsync("Coach").Result
            };

            return View(SchedulesVM);
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }
            var tmpCoach = _context.Users.Where(c => c.Id == schedule.Coach).FirstOrDefault();
            if (tmpCoach != null)
            {
                schedule.Coach = tmpCoach.UserName;
            }

            return View(schedule);
        }

        // GET: Schedules/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["coachs"] = _userManager.GetUsersInRoleAsync("Coach").Result;
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Eventname,Coach,Location,Eventdatetime")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schedule);
        }


        // GET: Schedules/Edit/5
        [Authorize(Roles = "Admin,Coach")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return View(schedule);
        }


        // POST: Schedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Coach")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Eventname,Coach,Location,Eventdatetime")] Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.Id))
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
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedule = await _context.Schedule.FindAsync(id);
            _context.Schedule.Remove(schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedule.Any(e => e.Id == id);
        }
    }
}
