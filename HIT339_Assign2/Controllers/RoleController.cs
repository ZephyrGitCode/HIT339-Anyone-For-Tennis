using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIT339_Assign2.Areas.Identity.Data;
using HIT339_Assign2.Data;
using HIT339_Assign2.Models;
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

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult ListUsers()
        {
            var members = userManager.GetUsersInRoleAsync("Member").Result;
            var coaches = userManager.GetUsersInRoleAsync("Coach").Result;
            var admins = userManager.GetUsersInRoleAsync("Admin").Result;

            var users = new UserViewModel
            {
                Members = members.ToList(),
                coaches = coaches.ToList(),
                Admins = admins.ToList()
            };

            return View(users);
        }
    }
} 
