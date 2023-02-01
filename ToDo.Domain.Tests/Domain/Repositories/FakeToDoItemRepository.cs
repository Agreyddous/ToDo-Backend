using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Domain.Tests.Domain.Entities;

namespace ToDo.Domain.Tests.Domain.Repositories;

public class FakeToDoItemRepository : IToDoItemRepository
{
	public void Create(ToDoItem toDoItem) { }

	public ToDoItem Get(Guid id) => ToDoItemTests.ToDoItem;

	public void Update(ToDoItem toDoItem) { }
}