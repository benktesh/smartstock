using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [ResponseCache(CacheProfileName = "Default")]
    public class HomeController : Controller
    {
        private IWebManager _manager;
        public HomeController(IWebManager mgr)
        {
            _manager = mgr;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(CacheProfileName = "Never")]
        public IActionResult GetValue()
        {
            return Content(_manager.GetValue());
        }
    }
}
