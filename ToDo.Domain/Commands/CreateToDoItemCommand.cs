using Flunt.Notifications;
using Flunt.Validations;
using ToDo.Domain.Commands.Contracts;

namespace ToDo.Domain.Commands;

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

	public string? User { get; set; }
	public string? Title { get; set; }
	public string? Description { get; set; }

	public void Validate() => AddNotifications(new Contract().Requires()
														  .HasMinLen(User, 6, nameof(User), "is invalid")
														  .HasMinLen(Title, 3, nameof(Title), "is too short")
														  .HasMinLen(Description, 3, nameof(Description), "is too short"));
}