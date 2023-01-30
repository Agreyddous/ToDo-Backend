namespace ToDo.Domain.Entities;

public class ToDoItem : Entity
{
	public ToDoItem(string user,
			 string title,
			 string description)
	{
		User = user;
		Title = title;
		Description = description;

		IsComplete = false;
		CreatedAt = DateTime.UtcNow;
		LastUpdatedAt = CreatedAt;
	}

	public string User { get; private set; }
	public string Title { get; private set; }
	public string Description { get; private set; }
	public bool IsComplete { get; private set; }
	public DateTime CreatedAt { get; private set; }
	public DateTime LastUpdatedAt { get; private set; }
	public DateTime? CompletedAt { get; private set; }

	public void Complete()
	{
		IsComplete = true;
		CompletedAt = DateTime.UtcNow;

		_updated();
	}

	public void Undo()
	{
		IsComplete = false;
		CompletedAt = default;

		_updated();
	}

	public void Update(string? title, string? description)
	{
		Title = title ?? Title;
		Description = description ?? Description;

		_updated();
	}

	public void _updated() => LastUpdatedAt = DateTime.UtcNow;
}