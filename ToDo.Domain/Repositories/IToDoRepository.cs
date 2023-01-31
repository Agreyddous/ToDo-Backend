using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories;

public interface IToDoRepository
{
	void Create(ToDoItem toDoItem);
	void Update(ToDoItem toDoItem);
}