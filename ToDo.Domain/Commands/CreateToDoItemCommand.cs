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
	public CreateToDoItemCommand(string? user,
							  string? title,
							  string? description)
	{
		User = user;
		Title = title;
		Description = description;
	}

	/// <summary>
	/// Owning user
	/// </summary>
	public string? User { get; set; }

	/// <summary>
	/// Title of the To-Do Item
	/// </summary>
	public string? Title { get; set; }

	/// <summary>
	/// Description of the To-Do Item
	/// </summary>
	public string? Description { get; set; }

	public void Validate() => AddNotifications(new Contract().Requires()
														  .HasMinLen(User, 6, nameof(User), "is invalid")
														  .HasMinLen(Title, 3, nameof(Title), "is too short")
														  .HasMinLen(Description, 3, nameof(Description), "is too short"));
}