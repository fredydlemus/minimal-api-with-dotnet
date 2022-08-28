using minimalapientityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using minimalapientityFramework.Models;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TasksContext>(p => p.UseInMemoryDatabase("TasksDB"));
builder.Services.AddNpgsql<TasksContext>(builder.Configuration.GetConnectionString("cnTasks"));
//for SQL Server
// builder.Services.AddSqlServer<TasksContext>("Data Source=LAPTOP-2F07TIND\\SQLEXPRESS;Initial Catalog=TareasDb;user id=sa;password=dominic");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbConnection", async ([FromServices] TasksContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database in memory: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tasks", async([FromServices] TasksContext dbContext)=> 
{
    return Results.Ok(dbContext.Tasks.Include(p => p.Category));
});

app.MapPost("/api/tasks", async([FromServices] TasksContext dbContext, [FromBody] Taskk task)=> 
{
    task.TaskkId = Guid.NewGuid();
    task.CreatedDate = DateTime.Now;
    await dbContext.Tasks.AddAsync(task);

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/tasks/{id}", async([FromServices] TasksContext dbContext, [FromBody] Taskk task, [FromRoute] Guid id)=> 
{
    var currentTask = dbContext.Tasks.Find(id);

    if(currentTask != null)
    {
        currentTask.CategoryId = task.CategoryId;
        currentTask.Title = task.Title;
        currentTask.TaskPriority = task.TaskPriority;
        currentTask.Description = task.Description;

        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();

});

app.MapDelete("/api/tasks/{id}", async([FromServices] TasksContext dbContext, [FromRoute] Guid id) => 
{
    var currentTask = dbContext.Tasks.Find(id);

        if(currentTask != null)
        {
            dbContext.Remove(currentTask);
            await dbContext.SaveChangesAsync();

            return Results.Ok();
        }

        return Results.NotFound();
});


app.Run();
