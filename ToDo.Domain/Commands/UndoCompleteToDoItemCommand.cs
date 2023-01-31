using Flunt.Notifications;
using Flunt.Validations;
using ToDo.Domain.Commands.Contracts;

namespace ToDo.Domain.Commands;

public class UndoCompleteToDoItemCommand : Notifiable, ICommand
{
	public UndoCompleteToDoItemCommand() { }
	public UndoCompleteToDoItemCommand(Guid id, string user)
	{
		Id = id;
		User = user;
	}

	public Guid Id { get; set; }
	public string? User { get; set; }

	public void Validate() => AddNotifications(new Contract().Requires()
														  .HasMinLen(User, 6, nameof(User), "is invalid"));
}