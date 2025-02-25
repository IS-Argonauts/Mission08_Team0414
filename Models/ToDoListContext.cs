using System;
using Microsoft.EntityFrameworkCore;


namespace Mission08_Team0414.Models
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        { }
            public DbSet<Task> Tasks { get; set; }
    
    }
}

