using Microsoft.EntityFrameworkCore;
using minimalapientityFramework.Models;

namespace minimalapientityFramework;

public class TasksContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Taskk> Tasks { get; set; }

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Category> categoriesInit = new List<Category>();
        categoriesInit.Add(new Category(){CategoryId = Guid.Parse("5b2e793a-1027-40a6-83b7-54a2a92f96d7"), Name = "Pending activities", Peso = 20});

        categoriesInit.Add(new Category(){CategoryId = Guid.Parse("5b2e793a-1027-40a6-83b7-54a2a92f9602"), Name = "Personal activities", Peso = 50});



        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Categoria");
            category.HasKey(p => p.CategoryId);

            category.Property(p => p.Name).IsRequired().HasMaxLength(150);
            category.Property(p => p.Description).IsRequired(false);
            category.Property(p => p.Peso);
            category.HasData(categoriesInit);
        });

        List<Taskk> tasksinit = new List<Taskk>();

        tasksinit.Add(new Taskk() {TaskkId = Guid.Parse("5b2e793a-1027-40a6-83b7-54a2a92f9610"), CategoryId = Guid.Parse("5b2e793a-1027-40a6-83b7-54a2a92f96d7"), TaskPriority = Priority.medium, Title = "DO payments", CreatedDate = DateTime.Now}); 

        tasksinit.Add(new Taskk() {TaskkId = Guid.Parse("5b2e793a-1027-40a6-83b7-54a2a92f9611"), CategoryId = Guid.Parse("5b2e793a-1027-40a6-83b7-54a2a92f9602"), TaskPriority = Priority.low, Title = "end movie", CreatedDate = DateTime.Now}); 

        modelBuilder.Entity<Taskk>(task => {
            task.ToTable("Tarea");
            task.HasKey(p => p.TaskkId);

            task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
            task.Property(p => p.Title).IsRequired().HasMaxLength(200);
            task.Property(p => p.Description).IsRequired(false);
            task.Property(p => p.TaskPriority);
            task.Property(p => p.CreatedDate);
            task.Ignore(p => p.Resume);
            task.HasData(tasksinit);
        });
    }

}