namespace Mission08_Team0414.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private ToDoListContext _context;

        public EFTaskRepository(ToDoListContext context)
        {
            _context = context;
        }

        public List<Task> GetAllTasks()
        {
            return _context.Tasks.Where(t => !t.Completed).ToList(); // Only get uncompleted tasks
        }

        public Task GetTaskById(int id)
        {
            return _context.Tasks.FirstOrDefault(t => t.TaskId == id);
        }

        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }
    }
}
