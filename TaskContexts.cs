using Microsoft.EntityFrameworkCore;
using minimalapientityFramework.Models;

namespace minimalapientityFramework;

public class TasksContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Taskk> Tasks { get; set; }

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

}