using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIT339_Assign2.Areas.Identity.Data;
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


        /// 
        /// Injecting Role Ma
        /// 
        /// 
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
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
        public IActionResult ListUsers()
        {
            ViewBag.UserId = userManager.GetUserId(HttpContext.User);
            var users = userManager.GetUsersInRoleAsync("Coach").Result;
            return View(users);
        }
    }
} 
