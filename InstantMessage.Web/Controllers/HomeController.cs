using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InstantMessage.Web.Models;
using InstantMessage.Web.Modules;
using InstantMessage.Interface;

namespace InstantMessage.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMembersService _membersService;

        public HomeController(ILogger<HomeController> logger, IMembersService membersService)
        {
            _logger = logger;
            _membersService = membersService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Message()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CommonMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetUserList()
        {
            var list = await _membersService.QueryList(a=>a.Status==1);
            return Json(list);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
