using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission08_Team0414.Models;

namespace Mission08_Team0414.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult AddEdit()
        {
            // Dummy data for categories
            ViewBag.Categories = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Work" },
            new SelectListItem { Value = "2", Text = "Personal" },
            new SelectListItem { Value = "3", Text = "School" }
        };

            // Explicitly specify Task model
            var dummyTask = new Mission08_Team0414.Models.Task
            {
                TaskId = 1,
                TaskName = "Sample Task",
                DueDate = DateTime.Now.AddDays(7),
                Quadrant = 2,
                CategoryId = 1,
                Completed = false
            };

            return View(dummyTask);
        }

            [HttpPost]
            public IActionResult SaveTask(Mission08_Team0414.Models.Task task)
            {
                // Dummy processing, no database actions
                return RedirectToAction("AddEdit"); // Redirects to form after submission
            }
        }


}

