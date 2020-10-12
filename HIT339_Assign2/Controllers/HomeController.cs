using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HIT339_Assign2.Models;
using HIT339_Assign2.Data;
using Microsoft.AspNetCore.Identity;
using HIT339_Assign2.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace HIT339_Assign2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = "";

            bool isAuthenticated = User.Identity.IsAuthenticated;

            if (isAuthenticated == true)
            {
                userId = _userManager.GetUserId(HttpContext.User);
                var user = _context.Users.Where(c => c.Id == userId).FirstOrDefault();
                var role = await _userManager.GetRolesAsync(user);
                string userrole = role[0];
                ViewBag.Role = userrole;
                if (userrole == "Member")
                {
                    return RedirectToAction("Index", "Schedules");
                    //return Redirect();
                }
                if (userrole == "Coach")
                {
                    return RedirectToAction("Index", "Schedules");
                    //return Redirect();
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
