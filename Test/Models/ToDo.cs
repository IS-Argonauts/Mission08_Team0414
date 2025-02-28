using System.ComponentModel.DataAnnotations;

namespace Test.Models;

public class ToDo
{
    [Key]
    [Required]
    public int TaskId { get; set; }
    public string TaskName { get; set; }
    public string DueDate { get; set; }
    public int Quadrant { get; set; }
    public string Category { get; set; }
    public bool Completed { get; set; }
}