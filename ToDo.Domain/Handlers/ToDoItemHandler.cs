using Flunt.Notifications;
using ToDo.Domain.Commands;
using ToDo.Domain.Commands.Contracts;
using ToDo.Domain.Entities;
using ToDo.Domain.Handlers.Contracts;
using ToDo.Domain.Repositories;

namespace ToDo.Domain.Handlers;

/// <summary>
/// Handler for To-Do Item related commands
/// </summary>
public class ToDoItemHandler :
	Notifiable,
	IHandler<CreateToDoItemCommand>,
	IHandler<UpdateToDoItemCommand>,
	IHandler<CompleteToDoItemCommand>,
	IHandler<UndoCompleteToDoItemCommand>
{
	private readonly IToDoItemRepository _toDoItemRepository;

	public ToDoItemHandler(IToDoItemRepository toDoItemRepository) => _toDoItemRepository = toDoItemRepository;

	/// <summary>
	/// Handle creation of new To-Do Items
	/// </summary>
	/// <param name="command">Command with required data for creating new To-Do Item</param>
	/// <returns>Generic Command Result</returns>
	public ICommandResult Handle(CreateToDoItemCommand command)
	{
		command.Validate();
		AddNotifications(command);

		ICommandResult result = new GenericCommandResult(success: Valid, data: Notifications);

		if (Valid)
		{
			ToDoItem toDoItem = new ToDoItem(command.User!, command.Title!, command.Description!, command.DueDate!.Value);
			_toDoItemRepository.Create(toDoItem);

			result = new GenericCommandResult(success: true, data: toDoItem);
		}

		return result;
	}

	/// <summary>
	/// Handle updating an existing To-Do Item
	/// </summary>
	/// <param name="command">Command with required data for updating existing To-Do Item</param>
	/// <returns>Generic Command Result</returns>
	public ICommandResult Handle(UpdateToDoItemCommand command)
	{
		command.Validate();
		AddNotifications(command);

		ICommandResult result = new GenericCommandResult(success: Valid, data: Notifications);

		if (Valid)
		{
			ToDoItem? toDoItem = _toDoItemRepository.Get(command.User!, command.Id);

			if (toDoItem != null)
			{
				toDoItem.Update(command.Title, command.Description, command.DueDate);

				_toDoItemRepository.Update(toDoItem);

				result = new GenericCommandResult(success: true, data: toDoItem);
			}

			else
				result = new GenericCommandResult(success: false, message: "To-Do Item not found");
		}

		return result;
	}

	/// <summary>
	/// Handle setting a To-Do Item as complete
	/// </summary>
	/// <param name="command">Command with required data for identifying the To-Do Item to be completed</param>
	/// <returns>Generic Command Result</returns>
	public ICommandResult Handle(CompleteToDoItemCommand command)
	{
		command.Validate();
		AddNotifications(command);

		ICommandResult result = new GenericCommandResult(success: Valid, data: Notifications);

		if (Valid)
		{
			ToDoItem? toDoItem = _toDoItemRepository.Get(command.User!, command.Id);

			if (toDoItem != null)
			{
				toDoItem.Complete();

				_toDoItemRepository.Update(toDoItem);

				result = new GenericCommandResult(success: true, data: toDoItem);
			}

			else
				result = new GenericCommandResult(success: false, message: "To-Do Item not found");
		}

		return result;
	}

	/// <summary>
	/// Handle setting a completed To-Do Item as incomplete
	/// </summary>
	/// <param name="command">Command with required data for identifying the To-Do Item to be set as incomplete</param>
	/// <returns>Generic Command Result</returns>
	public ICommandResult Handle(UndoCompleteToDoItemCommand command)
	{
		command.Validate();
		AddNotifications(command);

		ICommandResult result = new GenericCommandResult(success: Valid, data: Notifications);

		if (Valid)
		{
			ToDoItem? toDoItem = _toDoItemRepository.Get(command.User!, command.Id);

			if (toDoItem != null)
			{
				toDoItem.Undo();

				_toDoItemRepository.Update(toDoItem);

				result = new GenericCommandResult(success: true, data: toDoItem);
			}

			else
				result = new GenericCommandResult(success: false, message: "To-Do Item not found");
		}

		return result;
	}
}