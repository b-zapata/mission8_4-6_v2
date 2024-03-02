using Microsoft.AspNetCore.Mvc;
using mission8_4_6_v2.Models;
using System.Diagnostics;

namespace mission8_4_6_v2.Controllers
{
    public class HomeController : Controller
    {

        private ITodoRepository _repo;

        public HomeController(ITodoRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateTask()
        {
            Todo newTask = new Todo();
            ViewBag.Categories = _repo.Categories;

            return View("Add_Edit", newTask);
        }

        [HttpPost]
        public IActionResult CreateTask(Todo response)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTodo(response);
            }
            // Need to add a task added confirmation view
            return View("Task_Added_Confirmation", response);
        }

        [HttpGet]
        public IActionResult EditTask(int id)
        {
            Todo taskToEdit = _repo.GetTodo(id);

            // var taskToEdit = _context.Todos
            //    .Single(x => x.TodoId == TodoId);

            ViewBag.Categories = _repo.Categories;

            return View("Add_Edit", taskToEdit);
        }

        [HttpPost]
        public IActionResult EditTask(Todo updatedInfo)
        {
            _repo.UpdateTodo(updatedInfo);

            //_context.Update(updatedInfo);
            //_context.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult DeleteTask(int id)
        {
            Todo taskToDelete = _repo.GetTodo(id);
            //var taskToDelete = _context.Todos
            //    .Single(x => x.TodoId == TodoId);
            // Need to set up the ConfirmDelete view
            return View("Delete_Confirmation", taskToDelete);
        }

        [HttpPost]
        public IActionResult DeleteTask(Todo taskToDelete)
        {
            _repo.DeleteTodo(taskToDelete);
            //_context.Todos.Remove(taskToDelete);
            //_context.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult Quadrants()
        {
            var tasks = _repo.Todos
                .OrderBy(x => x.TodoId)
                .ToList();
            return View(tasks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
