using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories;

/// <summary>
/// Contract for To-Do Item Repository
/// </summary>
public interface IToDoItemRepository
{
	/// <summary>
	/// Retrieve a To-Do Item by it's Id
	/// </summary>
	/// <param name="id">Unique Identifier corresponding to an existing To-Do Item</param>
	/// <returns>To-Do Item</returns>
	ToDoItem Get(Guid id);

	/// <summary>
	/// Creates a new To-Do Item in the repository
	/// </summary>
	/// <param name="toDoItem">To-Do Item to be created</param>
	void Create(ToDoItem toDoItem);

	/// <summary>
	/// Update an existing To-Do Item in the repository
	/// </summary>
	/// <param name="toDoItem">To-Do Item to be updated</param>
	void Update(ToDoItem toDoItem);
}