using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Domain.Tests.Domain.Entities;

namespace ToDo.Domain.Tests.Domain.Repositories;

public class FakeToDoItemRepository : IToDoItemRepository
{
	public void Create(ToDoItem toDoItem) { }

	public ToDoItem Get(string user, Guid id) => ToDoItemTests.ToDoItem;

	public IEnumerable<ToDoItem> GetAll(string user)
	{
		throw new NotImplementedException();
	}

	public IEnumerable<ToDoItem> GetAllComplete(string user)
	{
		throw new NotImplementedException();
	}

	public IEnumerable<ToDoItem> GetAllDueBetween(string user, DateTime startDate, DateTime endDate, bool? isComplete = null)
	{
		throw new NotImplementedException();
	}

	public IEnumerable<ToDoItem> GetAllIncomplete(string user)
	{
		throw new NotImplementedException();
	}

	public IEnumerable<ToDoItem> GetCreatedBetween(string user, DateTime startDate, DateTime endDate)
	{
		throw new NotImplementedException();
	}

	public IEnumerable<ToDoItem> GetLastUpdatedBetween(string user, DateTime startDate, DateTime endDate, bool? isComplete = null)
	{
		throw new NotImplementedException();
	}

	public void Update(ToDoItem toDoItem) { }
}