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
            var userId = _userManager.GetUserId(HttpContext.User);
            ViewBag.userId = userId;
            
            var user = _context.Users.Where(c => c.Id == userId).FirstOrDefault();
            var role = await _userManager.GetRolesAsync(user);
            string userrole = role[0];
            ViewBag.Role = userrole;

            var schedules = _context.Schedule.ToList();

            if (userrole == "Coach")
            {
                schedules = _context.Schedule.Where(c => c.Coach == userId).ToList();
            }

            var SchedulesVM = new ScheduleViewModel
            {
                Schedules = schedules,
                coaches = (List<ApplicationUser>)_userManager.GetUsersInRoleAsync("Coach").Result,
                Enrolments = _context.Enrolment.ToList()
            };

            List<int> numbers = new List<int> { };

            var enroled = _context.Enrolment.ToList();
            foreach(var enrolcheck in enroled)  
            {
                if (userId == enrolcheck.UserId)
                {
                    numbers = numbers.Append(enrolcheck.ScheduleId).ToList();
                }
            }

            ViewBag.Enroled = numbers;

            return View(SchedulesVM);
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule.FirstOrDefaultAsync(m => m.Id == id);

            if (schedule == null)
            {
                return NotFound();
            }

            var enrolments = _context.Enrolment.Where(m => m.ScheduleId == id).ToList();

            var members = _userManager.GetUsersInRoleAsync("Member").Result;

            var userId = _userManager.GetUserId(HttpContext.User);

            var SchedulesVM = new ScheduleViewModel
            {
                SingleSchedule = schedule,
                Enrolments = enrolments,
                Members = members.ToList()
            };

            return View(SchedulesVM);
        }

        // GET: Schedules/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["coaches"] = _userManager.GetUsersInRoleAsync("Coach").Result;
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

        // GET: Schedules/Enrol/5
        [Authorize(Roles = "Member, Admin")]
        public async Task<IActionResult> Enrol(int? id)
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

            var userId = _userManager.GetUserId(HttpContext.User);

            ViewBag.userId = userId;
 
            var enrolModel = new EnrolViewModel
            {
                Schedules = schedule
            };

            return View(enrolModel);
        }

        // POST: Schedules/Enrol/5
        [Authorize(Roles = "Member, Admin")]
        [HttpPost, ActionName("Enrol")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnrolConfirm(int id)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(HttpContext.User);

                var enrolment = new Enrolment
                {
                    ScheduleId = id,
                    UserId = userId
                };
                _context.Add(enrolment);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
            
        }

        // GET: Schedules/UnEnrol/5
        [Authorize(Roles = "Member, Admin")]
        public async Task<IActionResult> UnEnrol(int? id)
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

            var enrolModel = new EnrolViewModel
            {
                Schedules = schedule
            };

            return View(enrolModel);
        }

        // POST: Schedules/Delete/5
        [Authorize(Roles = "Member, Admin")]
        [HttpPost, ActionName("UnEnrol")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnEnrolConfirm(int id)
        {
            var enrolment = await _context.Enrolment
                .FirstOrDefaultAsync(m => m.ScheduleId == id);
            _context.Enrolment.Remove(enrolment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedule.Any(e => e.Id == id);
        }
    }
}
