namespace Mission08_Team0414.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public required string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        public int Quadrant { get; set; }
        public int CategoryId { get; set; }
        public bool Completed { get; set; }
    }

}
