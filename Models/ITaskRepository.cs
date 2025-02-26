namespace Mission08_Team0414.Models
{

        public interface ITaskRepository
        {
            List<Task> GetAllTasks();
            Task GetTaskById(int id);
            void AddTask(Task task);
            void UpdateTask(Task task);
            void DeleteTask(int id);
        }
}
