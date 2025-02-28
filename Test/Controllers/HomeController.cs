using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test.Models;

namespace Test.Controllers;

public class HomeController : Controller
{
    private ITaskRepository _repo;

    public HomeController(ITaskRepository temp)
    {
        _repo = temp;
    }

    public IActionResult Index()
    {

        return Redirect("/Home/ToDoList");
    }

    public IActionResult ToDoList()
    {
        var toDos = _repo.GetAllToDos();
        return View(toDos);
    }

    public IActionResult AddEdit()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult AddEdit(int? id)
    {
        // Fetch the task from the database if id is provided, else create a new one
        ToDo task = id.HasValue
            ? _repo.GetToDoById(id)//_context.ToDos.FirstOrDefault(t => t.TaskId == id)
            : new ToDo
            {
                DueDate = DateTime.Now.AddDays(7).ToString(),
                Quadrant = 1,
                CategoryId = _repo.GetCategoryById(1)?.id ?? 0,
                Completed = false
            };

        // If no task is found and id was provided, return NotFound
        if (task == null)
        {
            return NotFound();
        }

        // Fetch categories dynamically from the database
        ViewBag.Categories = _repo.GetAllCategories()//_context.Categories
            .Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.name
            })
            .ToList();

        return View(task);
    }

    [HttpPost]
    public IActionResult SaveTask(ToDo task)
    {
        if (ModelState.IsValid)
        {
            if (task.TaskId == 0) // New Task
            {
                _repo.AddToDo(task);
            }
            else // Updating Existing Task
            {
                var existingTask = _repo.GetToDoById(task.TaskId); 

                if (existingTask != null)
                {
                    _repo.UpdateTodo(task); // Make sure UpdateTodo() is fixed
                }
            }

            return RedirectToAction("ToDoList");
        }

        return View("AddEdit", task);
    }
    
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var task = _repo.GetToDoById(id);
        if (task != null)
        {
            _repo.DeleteTodo(id);
        }

        return RedirectToAction("Index");  // Or any action to go back to the task list
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}