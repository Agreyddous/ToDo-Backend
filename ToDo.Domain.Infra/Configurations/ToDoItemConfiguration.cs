using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Infra.Configurations;

/// <summary>
/// Configuration for entity ToDoItem
/// </summary>
public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
{
	public void Configure(EntityTypeBuilder<ToDoItem> builder)
	{
		builder.ToTable("ToDoItems");
		builder.HasKey(toDoItem => toDoItem.Id);

		builder.Property(toDoItem => toDoItem.User).HasMaxLength(120);
		builder.Property(toDoItem => toDoItem.Title);
		builder.Property(toDoItem => toDoItem.Description);
		builder.Property(toDoItem => toDoItem.IsComplete);
		builder.Property(toDoItem => toDoItem.CreatedAt);
		builder.Property(toDoItem => toDoItem.LastUpdatedAt);
		builder.Property(toDoItem => toDoItem.CompletedAt);

		builder.HasIndex(toDoItem => toDoItem.IsComplete);
		builder.HasIndex(toDoItem => toDoItem.LastUpdatedAt);
	}
}