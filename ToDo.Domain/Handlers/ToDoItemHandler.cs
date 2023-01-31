using Flunt.Notifications;
using ToDo.Domain.Commands;
using ToDo.Domain.Commands.Contracts;
using ToDo.Domain.Entities;
using ToDo.Domain.Handlers.Contracts;
using ToDo.Domain.Repositories;

namespace ToDo.Domain.Handlers;

public class ToDoItemHandler :
	Notifiable,
	IHandler<CreateToDoItemCommand>,
	IHandler<UpdateToDoItemCommand>
{
	private readonly IToDoItemRepository _toDoItemRepository;

	public ToDoItemHandler(IToDoItemRepository toDoItemRepository) => _toDoItemRepository = toDoItemRepository;

	public ICommandResult Handle(CreateToDoItemCommand command)
	{
		command.Validate();
		AddNotifications(command);

		ICommandResult result = new GenericCommandResult(success: Valid, data: Notifications);

		if (Valid)
		{
			ToDoItem toDoItem = new ToDoItem(command.User!, command.Title!, command.Description!);
			_toDoItemRepository.Create(toDoItem);

			result = new GenericCommandResult(success: true, data: toDoItem);
		}

		return result;
	}

	public ICommandResult Handle(UpdateToDoItemCommand command)
	{
		command.Validate();
		AddNotifications(command);

		ICommandResult result = new GenericCommandResult(success: Valid, data: Notifications);

		if (Valid)
		{
			ToDoItem toDoItem = _toDoItemRepository.Get(command.Id);
			toDoItem.Update(command.Title, command.Description);

			_toDoItemRepository.Update(toDoItem);

			result = new GenericCommandResult(success: true, data: toDoItem);
		}

		return result;
	}
}