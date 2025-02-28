using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models;

public class ToDo
{
    [Key]
    [Required]
    public int TaskId { get; set; }
    public string TaskName { get; set; }
    public string DueDate { get; set; }
    public int Quadrant { get; set; }
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
    public bool Completed { get; set; }
}