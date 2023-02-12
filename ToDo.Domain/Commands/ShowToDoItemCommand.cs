using Flunt.Notifications;
using Flunt.Validations;
using ToDo.Domain.Commands.Contracts;

namespace ToDo.Domain.Commands;

/// <summary>
/// Command for marking an hidden To-Do Item as not hidden
/// </summary>
public class ShowToDoItemCommand : Notifiable, ICommand
{
	public ShowToDoItemCommand(Guid id, string user)
	{
		Id = id;
		User = user;
	}

	/// <summary>
	/// Unique Idenfitier corresponding to an existing To-Do Item
	/// </summary>
	internal Guid Id { get; private set; }

	/// <summary>
	/// Owning user
	/// </summary>
	internal string? User { get; private set; }

	public void Validate() => AddNotifications(new Contract().Requires()
														  .HasMinLen(User, 6, nameof(User), "is invalid"));
}