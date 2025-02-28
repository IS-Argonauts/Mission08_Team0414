using System.ComponentModel.DataAnnotations;

namespace Test.Models;

public class Category
{
    [Key]
    [Required]
    public int id { get; set; }
    [Required]
    public string name { get; set; }
}
