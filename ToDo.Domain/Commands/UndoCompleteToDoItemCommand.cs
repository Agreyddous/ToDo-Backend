using Flunt.Notifications;
using Flunt.Validations;
using ToDo.Domain.Commands.Contracts;

namespace ToDo.Domain.Commands;

/// <summary>
/// Command for marking an already complete To-Do Item as incomplete
/// </summary>
public class UndoCompleteToDoItemCommand : Notifiable, ICommand
{
	public UndoCompleteToDoItemCommand() { }
	public UndoCompleteToDoItemCommand(Guid id, string user)
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