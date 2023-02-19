using Flunt.Notifications;
using Flunt.Validations;
using ToDo.Domain.Commands.Contracts;

namespace ToDo.Domain.Commands;

/// <summary>
/// Command used for creating new To-Do Items
/// </summary>
public class CreateToDoItemCommand : Notifiable, ICommand
{
	public CreateToDoItemCommand() { }
	public CreateToDoItemCommand(string? title,
							  string? description,
							  DateTime? dueDate)
	{
		Title = title;
		Description = description;
		DueDate = dueDate;
	}

	/// <summary>
	/// Owning user
	/// </summary>
	internal string? User { get; private set; }

	/// <summary>
	/// Title of the To-Do Item
	/// </summary>
	public string? Title { get; set; }

	/// <summary>
	/// Description of the To-Do Item
	/// </summary>
	public string? Description { get; set; }

	/// <summary>
	/// When the To-Do Item is due
	/// </summary>
	public DateTime? DueDate { get; set; }

	public void SetUser(string? user) => User = user;

	public void Validate() => AddNotifications(new Contract().Requires()
														  .HasMinLen(User, 6, nameof(User), "is invalid")
														  .HasMinLen(Title, 3, nameof(Title), "is too short")
														  .HasMinLen(Description, 3, nameof(Description), "is too short")
														  .IsNotNull(DueDate, nameof(DueDate), "can't be null"));
}