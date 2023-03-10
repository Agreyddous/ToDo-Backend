namespace ToDo.Domain.Entities;

public class ToDoItem : Entity
{
	public ToDoItem(string user,
			 string title,
			 string description,
			 DateTime dueDate)
	{
		User = user;
		Title = title;
		Description = description;
		DueDate = dueDate;

		IsComplete = false;
		IsHidden = false;
		CreatedAt = DateTime.UtcNow;
		LastUpdatedAt = CreatedAt;
	}

	public string User { get; private set; }
	public string Title { get; private set; }
	public string Description { get; private set; }
	public DateTime DueDate { get; private set; }
	public bool IsComplete { get; private set; }
	public bool IsHidden { get; private set; }
	public DateTime CreatedAt { get; private set; }
	public DateTime LastUpdatedAt { get; private set; }
	public DateTime? CompletedAt { get; private set; }

	/// <summary>
	/// Update To-Do Item to be completed
	/// </summary>
	public void Complete()
	{
		IsComplete = true;
		CompletedAt = DateTime.UtcNow;

		_updated();
	}

	/// <summary>
	/// Update To-Do Item to be uncompleted
	/// </summary>
	public void Undo()
	{
		IsComplete = false;
		CompletedAt = default;

		_updated();
	}

	/// <summary>
	/// If item is complete, updates it to be hidden
	/// </summary>
	public void Hide()
	{
		if (IsComplete)
		{
			IsHidden = true;
			_updated();
		}
	}

	/// <summary>
	/// Updates a hidden to be shown
	/// </summary>
	public void Show()
	{
		IsHidden = false;
		_updated();
	}

	/// <summary>
	/// Update title and/or description of the To-Do Item
	/// </summary>
	/// <param name="title">New title - Value won't be changed if null is provided</param>
	/// <param name="description">New description - Value won't be changed if null is provided</param>
	public void Update(string? title, string? description, DateTime? dueDate)
	{
		Title = title ?? Title;
		Description = description ?? Description;
		DueDate = dueDate ?? DueDate;

		_updated();
	}

	public void _updated() => LastUpdatedAt = DateTime.UtcNow;
}