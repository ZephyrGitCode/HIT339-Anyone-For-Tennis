using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIT339_Assign2.Areas.Identity.Data;
using HIT339_Assign2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HIT339_Assign2.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext _context;

        /// 
        /// Injecting Role Ma
        /// 
        /// 
        public RoleController(ApplicationDbContext context , RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ListCoach()
        {
            ViewBag.UserId = userManager.GetUserId(HttpContext.User);
            var users = userManager.GetUsersInRoleAsync("Coach").Result;
            return View(users);
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Coach")]
        public IActionResult ListUsers()
        {
            var userId = userManager.GetUserId(HttpContext.User);
            ViewBag.UserId = userId;
            var users = new List<ApplicationUser>();
            var UserRoleInfo = _context.UserRoles.Where(c => c.UserId == userId).FirstOrDefault();
            if (UserRoleInfo != null)
            {
                var RoleInfo = _context.Roles.Where(c => c.Id == UserRoleInfo.RoleId).FirstOrDefault();
                if (RoleInfo != null )
                {
                    if (RoleInfo.Name == "Coach")
                    {
                        var schList = _context.Schedule.Where(c => c.Coach == userId).ToList();
                        if (schList != null)
                        {
                            foreach (var item in schList)
                            {
                                var enrList = _context.Enrolment.Where(c => c.ScheduleId == item.Id).ToList();
                                if (enrList != null)
                                {
                                    var tmpUsers = userManager.GetUsersInRoleAsync("Member").Result;
                                    if (tmpUsers != null)
                                    {
                                        foreach (var eItem in enrList)
                                        {
                                            var tmp = tmpUsers.Where(c => c.Id == eItem.UserId).FirstOrDefault();
                                            if (tmp != null)
                                            {
                                                users.Add(tmp);
                                            }
                                        }
                                    }
                                }
                            }
                            if (users != null)
                            {
                                users = users.Distinct().ToList();
                            }
                        }
                    }
                    else
                    {
                        users = userManager.GetUsersInRoleAsync("Member").Result.ToList();
                    }
                }
            }
            return View(users);
        }
    }
} 
