using Microsoft.EntityFrameworkCore;

namespace Test.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private readonly ToDoListContext _context;

        public EFTaskRepository(ToDoListContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Ensure context is not null
        }

        public List<ToDo> GetAllToDos()
        {
            return _context.ToDos.ToList(); // ✅ Fixed
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public ToDo GetToDoById(int? id)
        {
            return _context.ToDos
                .AsNoTracking() // 🔥 Prevents EF from tracking this entity
                .FirstOrDefault(t => t.TaskId == id);
        }

        public Category GetCategoryById(int? id)
        {
            return _context.Categories.FirstOrDefault(c => c.id == id);
        }

        public void AddToDo(ToDo toDo)
        {
            _context.ToDos.Add(toDo);
            _context.SaveChanges();
        }

        public void UpdateTodo(ToDo toDo)
        {
            var existingToDo = _context.ToDos.Find(toDo.TaskId);

            if (existingToDo != null)
            {
                _context.Entry(existingToDo).CurrentValues.SetValues(toDo);
            }
            else
            {
                _context.ToDos.Attach(toDo);
                _context.Entry(toDo).State = EntityState.Modified;
            }

            _context.SaveChanges();
        }

        public void DeleteTodo(int id)
        {
            var toDo = _context.ToDos.Find(id);
            if (toDo != null)
            {
                _context.ToDos.Remove(toDo);
                _context.SaveChanges();
            }
        }
    }
}