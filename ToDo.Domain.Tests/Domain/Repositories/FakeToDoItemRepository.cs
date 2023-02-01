using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;

namespace ToDo.Domain.Tests.Domain.Repositories;

public class FakeToDoItemRepository : IToDoItemRepository
{
	public void Create(ToDoItem toDoItem) { }

	public ToDoItem Get(Guid id)
	{
		throw new NotImplementedException();
	}

	public void Update(ToDoItem toDoItem) { }
}