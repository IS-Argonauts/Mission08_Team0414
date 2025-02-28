using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test.Models;

namespace Test.Controllers;

public class HomeController : Controller
{
    private ToDoListContext _context;

    public HomeController(ToDoListContext temp)
    {
        _context = temp;
    }

    public IActionResult Index()
    {

        return Redirect("/Home/ToDoList");
    }

    public IActionResult ToDoList()
    {
        var toDos = _context.ToDos.ToList();
        return View(toDos);
    }

    public IActionResult AddEdit()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult AddEdit(int? id)
    {
        // Check if an id is passed
        ToDo task = id.HasValue 
            ? _context.ToDos.FirstOrDefault(t => t.TaskId == id) 
            : new ToDo 
            {
                DueDate = DateTime.Now.AddDays(7).ToString(),
                Quadrant = 2,
                Category = "Home",
                Completed = false
            };

        // If no task found, return NotFound (or handle as needed)
        if (task == null)
        {
            return NotFound();
        }

        // Pass data to view
        ViewBag.Categories = new List<SelectListItem>
        {
            new SelectListItem { Value = "Home", Text = "Home" },
            new SelectListItem { Value = "School", Text = "School" },
            new SelectListItem { Value = "Work", Text = "Work" },
            new SelectListItem { Value = "Church", Text = "Church" }
        };

        return View(task);
    }

    [HttpPost]
    public IActionResult SaveTask(ToDo task)
    {
        if (ModelState.IsValid)
        {
            if (task.TaskId == 0) // New Task
            {
                _context.ToDos.Add(task);
            }
            else // Editing Existing Task
            {
                var existingTask = _context.ToDos.FirstOrDefault(t => t.TaskId == task.TaskId);
                if (existingTask != null)
                {
                    existingTask.TaskName = task.TaskName;
                    existingTask.DueDate = task.DueDate;
                    existingTask.Quadrant = task.Quadrant;
                    existingTask.Category = task.Category;
                    existingTask.Completed = task.Completed;
                }
            }

            _context.SaveChanges(); // Save changes to the database
            return RedirectToAction("ToDoList"); // Redirect after saving
        }

        // If validation fails, return to form with the same task
        return View("AddEdit", task);
    }
    
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var task = _context.ToDos.FirstOrDefault(t => t.TaskId == id);
        if (task != null)
        {
            _context.ToDos.Remove(task);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");  // Or any action to go back to the task list
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}