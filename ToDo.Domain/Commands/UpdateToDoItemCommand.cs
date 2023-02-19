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
	public UpdateToDoItemCommand(string? title,
							  string? description)
	{
		Title = title;
		Description = description;
	}

	/// <summary>
	/// Unique Idenfitier corresponding to an existing To-Do Item
	/// </summary>
	internal Guid Id { get; private set; }

	/// <summary>
	/// Owning user
	/// </summary>
	internal string? User { get; private set; }

	/// <summary>
	/// New title of the To-Do Item
	/// </summary>
	public string? Title { get; set; }

	/// <summary>
	/// New description for the To-Do Item
	/// </summary>
	public string? Description { get; set; }

	/// <summary>
	/// When the To-Do Item is due
	/// </summary>
	public DateTime? DueDate { get; set; }

	public void SetUser(string? user) => User = user;
	public void SetId(Guid id) => Id = id;

	public void Validate() => AddNotifications(new Contract().Requires()
														  .HasMinLen(User, 6, nameof(User), "is invalid")
														  .HasMinLen(Title, 3, nameof(Title), "is too short")
														  .HasMinLen(Description, 3, nameof(Description), "is too short"));
}