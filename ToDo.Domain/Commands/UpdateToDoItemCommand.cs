using Flunt.Notifications;
using Flunt.Validations;
using ToDo.Domain.Commands.Contracts;

namespace ToDo.Domain.Commands;

/// <summary>
/// Command for updating the tittle and/or description of an existing To-Do Item
/// </summary>
public class UpdateToDoItemCommand : Notifiable, ICommand
{
	public UpdateToDoItemCommand() { }
	public UpdateToDoItemCommand(Guid id,
							  string? user,
							  string? title,
							  string? description)
	{
		Id = id;
		User = user;
		Title = title;
		Description = description;
	}

	/// <summary>
	/// Unique Idenfitier corresponding to an existing To-Do Item
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Owning user
	/// </summary>
	public string? User { get; set; }

	/// <summary>
	/// New title of the To-Do Item
	/// </summary>
	public string? Title { get; set; }

	/// <summary>
	/// New description for the To-Do Item
	/// </summary>
	public string? Description { get; set; }

	public void Validate() => AddNotifications(new Contract().Requires()
														  .HasMinLen(User, 6, nameof(User), "is invalid")
														  .HasMinLen(Title, 3, nameof(Title), "is too short")
														  .HasMinLen(Description, 3, nameof(Description), "is too short"));
}