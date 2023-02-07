using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.Commands;
using ToDo.Domain.Commands.Contracts;
using ToDo.Domain.Entities;
using ToDo.Domain.Handlers;
using ToDo.Domain.Repositories;

namespace ToDo.API.Controllers;

[Authorize]
[ApiController]
[Route("v1/ToDoItems")]
public class ToDoItemController : ControllerBase
{
	[HttpPost("")]
	public ICommandResult Create([FromServices] ToDoItemHandler toDoItemHandler, CreateToDoItemCommand command)
	{
		command.SetUser(_retrieveUserId());

		return toDoItemHandler.Handle(command);
	}

	[HttpPut("{id}")]
	public ICommandResult Update([FromServices] ToDoItemHandler toDoItemHandler, Guid id, UpdateToDoItemCommand command)
	{
		command.SetUser(_retrieveUserId());
		command.SetId(id);

		return toDoItemHandler.Handle(command);
	}

	[HttpPost("{id}/Complete")]
	public ICommandResult Completed([FromServices] ToDoItemHandler toDoItemHandler, Guid id) => toDoItemHandler.Handle(new CompleteToDoItemCommand(id, _retrieveUserId()));

	[HttpPost("{id}/Undo")]
	public ICommandResult Uncompleted([FromServices] ToDoItemHandler toDoItemHandler, Guid id) => toDoItemHandler.Handle(new UndoCompleteToDoItemCommand(id, _retrieveUserId()));

	[HttpGet("")]
	public IEnumerable<ToDoItem> GetAll([FromServices] IToDoItemRepository toDoItemRepository) => toDoItemRepository.GetAll(_retrieveUserId());

	[HttpGet("Complete")]
	public IEnumerable<ToDoItem> GetAllComplete([FromServices] IToDoItemRepository toDoItemRepository) => toDoItemRepository.GetAllComplete(_retrieveUserId());

	[HttpGet("Complete/Today")]
	public IEnumerable<ToDoItem> GetAllCompleteToday([FromServices] IToDoItemRepository toDoItemRepository) => toDoItemRepository.GetLastUpdatedBetween(_retrieveUserId(), DateTime.Today.ToUniversalTime(), DateTime.UtcNow, true);

	[HttpGet("Incomplete")]
	public IEnumerable<ToDoItem> GetAllIncomplete([FromServices] IToDoItemRepository toDoItemRepository) => toDoItemRepository.GetAllIncomplete(_retrieveUserId());

	private string _retrieveUserId() => User.Claims.FirstOrDefault(claim => claim.Type == "user_id")?.Value ?? string.Empty;
}