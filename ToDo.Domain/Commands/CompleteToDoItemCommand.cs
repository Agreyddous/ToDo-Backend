using Flunt.Notifications;
using Flunt.Validations;
using ToDo.Domain.Commands.Contracts;

namespace ToDo.Domain.Commands;

public class CompleteToDoItemCommand : Notifiable, ICommand
{
	public CompleteToDoItemCommand() { }
	public CompleteToDoItemCommand(Guid id, string user)
	{
		Id = id;
		User = user;
	}

	public Guid Id { get; set; }
	public string? User { get; set; }

	public void Validate() => AddNotifications(new Contract().Requires()
														  .HasMinLen(User, 6, nameof(User), "is invalid"));
}