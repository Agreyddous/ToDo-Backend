using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Domain.Infra.Configurations;

namespace ToDo.Domain.Infra.Contexts;

/// <summary>
/// Entity Framework Data Context definition for To-Do context
/// </summary>
public class ToDoDataContext : DbContext
{
	public ToDoDataContext(DbContextOptions<ToDoDataContext> options) : base(options) { }

	public DbSet<ToDoItem>? ToDoItems { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfiguration(new ToDoItemConfiguration());
}