using Microsoft.AspNetCore.Mvc;
using mission8_4_6_v2.Models;
using System.Diagnostics;

namespace mission8_4_6_v2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult CreateTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTask()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditTask()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteTask()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Tasks()
        {
            return View();
        }


        /*
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }
        */

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
