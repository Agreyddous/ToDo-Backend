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

		builder.Property(toDoItem => toDoItem.User).IsRequired().HasMaxLength(120);
		builder.Property(toDoItem => toDoItem.Title).IsRequired();
		builder.Property(toDoItem => toDoItem.Description).IsRequired();
		builder.Property(toDoItem => toDoItem.DueDate).IsRequired();
		builder.Property(toDoItem => toDoItem.IsComplete).IsRequired();
		builder.Property(toDoItem => toDoItem.CreatedAt).IsRequired();
		builder.Property(toDoItem => toDoItem.LastUpdatedAt).IsRequired();
		builder.Property(toDoItem => toDoItem.CompletedAt);

		builder.HasIndex(toDoItem => toDoItem.IsComplete);
		builder.HasIndex(toDoItem => toDoItem.LastUpdatedAt);
	}
}