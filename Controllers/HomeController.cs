using Microsoft.AspNetCore.Mvc;
using mission8_4_6_v2.Models;
using System.Diagnostics;

namespace mission8_4_6_v2.Controllers
{
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;

        private TodosContext _context;

        public HomeController(TodosContext temp)
        {
            _context = temp;
        }
        /*
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        */
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateTask()
        {
            Todo newTask = new Todo();
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryId)
                .ToList();

            return View("Add_Edit", newTask);
        }

        /*
        [HttpPost]
        public IActionResult CreateTask()
        {
            return View();
        }
        */

        [HttpGet]
        public IActionResult EditTask(int TodoId)
        {
            var taskToEdit = _context.Todos
                .Single(x => x.TodoId == TodoId);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryId)
                .ToList();

            return View("TasksForm", taskToEdit);
        }

        [HttpPost]
        public IActionResult EditTask(Todo updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult DeleteTask(int TodoId)
        {
            var taskToDelete = _context.Todos
                .Single(x => x.TodoId == TodoId);
            // Need to set up the ConfirmDelete view
            return View("ConfirmDelete", taskToDelete);
        }

        [HttpPost]
        public IActionResult DeleteTask(Todo taskToDelete)
        {
            _context.Todos.Remove(taskToDelete);
            _context.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult Quadrants()
        {
            var tasks = _context.Todos
                .OrderBy(x => x.TodoId)
                .ToList();
            return View(tasks);
        }


        /*
        


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
