using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.Commands;
using ToDo.Domain.Commands.Contracts;
using ToDo.Domain.Entities;
using ToDo.Domain.Handlers;
using ToDo.Domain.Repositories;

namespace ToDo.Api.Controllers;

[ApiController]
[Route("v1/ToDoItems")]
public class ToDoItemController : ControllerBase
{
	[HttpPost("")]
	public ICommandResult Create([FromServices] ToDoItemHandler toDoItemHandler, CreateToDoItemCommand command) => toDoItemHandler.Handle(command);

	[HttpPut("")]
	public ICommandResult Update([FromServices] ToDoItemHandler toDoItemHandler, UpdateToDoItemCommand command) => toDoItemHandler.Handle(command);

	[HttpPost("{id}/Complete")]
	public ICommandResult Completed([FromServices] ToDoItemHandler toDoItemHandler, Guid id, CompleteToDoItemCommand command) => toDoItemHandler.Handle(command);

	[HttpPost("{id}/Undo")]
	public ICommandResult Uncompleted([FromServices] ToDoItemHandler toDoItemHandler, Guid id, UndoCompleteToDoItemCommand command) => toDoItemHandler.Handle(command);

	[HttpGet("")]
	public IEnumerable<ToDoItem> GetAll([FromServices] IToDoItemRepository toDoItemRepository, string user) => toDoItemRepository.GetAll(user);

	[HttpGet("Complete")]
	public IEnumerable<ToDoItem> GetAllComplete([FromServices] IToDoItemRepository toDoItemRepository, string user) => toDoItemRepository.GetAllComplete(user);

	[HttpGet("Complete/Today")]
	public IEnumerable<ToDoItem> GetAllCompleteToday([FromServices] IToDoItemRepository toDoItemRepository, string user) => toDoItemRepository.GetLastUpdatedBetween(user, DateTime.Today.ToUniversalTime(), DateTime.UtcNow, true);

	[HttpGet("Incomplete")]
	public IEnumerable<ToDoItem> GetAllIncomplete([FromServices] IToDoItemRepository toDoItemRepository, string user) => toDoItemRepository.GetAllIncomplete(user);
}