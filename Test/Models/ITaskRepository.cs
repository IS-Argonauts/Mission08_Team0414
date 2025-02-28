namespace Test.Models;

public interface ITaskRepository
{
    List<ToDo> GetAllToDos();
    List<Category> GetAllCategories();
    ToDo GetToDoById(int? id);
    Category GetCategoryById(int? id);
    public void AddToDo(ToDo toDo);
    public void UpdateTodo(ToDo toDo);
    public void DeleteTodo(int id);
}