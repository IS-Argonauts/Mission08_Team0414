using Microsoft.EntityFrameworkCore;

namespace Test.Models;

public class ToDoListContext : DbContext
{
    public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
    {
    }
    
    public DbSet<ToDo> ToDos { get; set; }
    public DbSet<Category> Categories { get; set; }
}