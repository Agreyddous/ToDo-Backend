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

	[HttpPost("{id}/Hide")]
	public ICommandResult Hide([FromServices] ToDoItemHandler toDoItemHandler, Guid id) => toDoItemHandler.Handle(new HideToDoItemCommand(id, _retrieveUserId()));

	[HttpPost("{id}/Show")]
	public ICommandResult Show([FromServices] ToDoItemHandler toDoItemHandler, Guid id) => toDoItemHandler.Handle(new ShowToDoItemCommand(id, _retrieveUserId()));

	[HttpGet("")]
	public IEnumerable<ToDoItem> GetAll([FromServices] IToDoItemRepository toDoItemRepository) => toDoItemRepository.GetAll(_retrieveUserId());

	[HttpGet("Hidden")]
	public IEnumerable<ToDoItem> GetAllHidden([FromServices] IToDoItemRepository toDoItemRepository) => toDoItemRepository.GetAllHidden(_retrieveUserId());

	[HttpGet("Available")]
	public IEnumerable<ToDoItem> GetAllAvailable([FromServices] IToDoItemRepository toDoItemRepository) => toDoItemRepository.GetAllAvailable(_retrieveUserId());

	[HttpGet("Today")]
	public IEnumerable<ToDoItem> GetAllDueToday([FromServices] IToDoItemRepository toDoItemRepository, DateTime currentDate, bool? isComplete, bool? isHidden) => toDoItemRepository.GetAllDueBetween(_retrieveUserId(), currentDate.Date, currentDate.Date.Add(new TimeSpan(23, 59, 59)), isComplete, isHidden);

	[HttpGet("Tomorrow")]
	public IEnumerable<ToDoItem> GetAllDueTomorrow([FromServices] IToDoItemRepository toDoItemRepository, DateTime currentDate, bool? isComplete, bool? isHidden) => toDoItemRepository.GetAllDueBetween(_retrieveUserId(), currentDate.Date.AddDays(1), currentDate.Date.AddDays(1).Add(new TimeSpan(23, 59, 59)), isComplete, isHidden);

	[HttpGet("Complete")]
	public IEnumerable<ToDoItem> GetAllComplete([FromServices] IToDoItemRepository toDoItemRepository) => toDoItemRepository.GetAllComplete(_retrieveUserId());

	[HttpGet("Complete/Today")]
	public IEnumerable<ToDoItem> GetAllCompleteToday([FromServices] IToDoItemRepository toDoItemRepository, DateTime currentDate) => toDoItemRepository.GetLastUpdatedBetween(_retrieveUserId(), currentDate.Date, currentDate.Date.Add(new TimeSpan(23, 59, 59)), true);

	[HttpGet("Incomplete")]
	public IEnumerable<ToDoItem> GetAllIncomplete([FromServices] IToDoItemRepository toDoItemRepository) => toDoItemRepository.GetAllIncomplete(_retrieveUserId());

	private string _retrieveUserId() => User.Claims.FirstOrDefault(claim => claim.Type == "user_id")?.Value ?? string.Empty;
}