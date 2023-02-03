using Flunt.Notifications;
using Flunt.Validations;
using ToDo.Domain.Commands.Contracts;

namespace ToDo.Domain.Commands;

/// <summary>
/// Command for marking an existing To-Do Item as complete
/// </summary>
public class CompleteToDoItemCommand : Notifiable, ICommand
{
	public CompleteToDoItemCommand() { }
	public CompleteToDoItemCommand(Guid id, string user)
	{
		Id = id;
		User = user;
	}

	/// <summary>
	/// Unique Idenfitier corresponding to an existing To-Do Item
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Owning user
	/// </summary>
	public string? User { get; set; }

	public void Validate() => AddNotifications(new Contract().Requires()
														  .HasMinLen(User, 6, nameof(User), "is invalid"));
}