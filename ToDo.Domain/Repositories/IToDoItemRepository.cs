using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories;

public interface IToDoItemRepository
{
	ToDoItem Get(Guid id);
	void Create(ToDoItem toDoItem);
	void Update(ToDoItem toDoItem);
}