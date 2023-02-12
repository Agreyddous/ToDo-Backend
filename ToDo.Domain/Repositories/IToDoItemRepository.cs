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
	/// <param name="user">User reference</param>
	/// <param name="id">Unique Identifier corresponding to an existing To-Do Item</param>
	/// <returns>To-Do Item</returns>
	ToDoItem? Get(string user, Guid id);

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

	/// <summary>
	/// Returns all To-Do Items of a certain user
	/// </summary>
	/// <param name="user">User reference</param>
	IEnumerable<ToDoItem> GetAll(string user);

	/// <summary>
	/// Returns all To-Do Items of a certain user that are due between the provided Start and End dates
	/// </summary>
	/// <param name="user">User reference</param>
	/// <param name="startDate">Start of the searching period</param>
	/// <param name="endDate">End of the searching period</param>
	/// <param name="isComplete">Optional flag to filter</param>
	/// <param name="isHidden">Optional flag to filter</param>
	IEnumerable<ToDoItem> GetAllDueBetween(string user, DateTime startDate, DateTime endDate, bool? isComplete = null, bool? isHidden = null);

	/// <summary>
	/// Returns all completed To-Do Items of a certain user
	/// </summary>
	/// <param name="user">User reference</param>
	IEnumerable<ToDoItem> GetAllComplete(string user);

	/// <summary>
	/// Returns all incomplete To-Do Items of a certain user
	/// </summary>
	/// <param name="user">User reference</param>
	IEnumerable<ToDoItem> GetAllIncomplete(string user);

	/// <summary>
	/// Returns all To-Do Items of a certain user created between the provided Start and End dates
	/// </summary>
	/// <param name="user">User reference</param>
	/// <param name="startDate">Start of the searching period</param>
	/// <param name="endDate">End of the searching period</param>
	IEnumerable<ToDoItem> GetCreatedBetween(string user, DateTime startDate, DateTime endDate);

	/// <summary>
	/// Returns all To-Do Items of a certain user last updated between the provided Start and End dates
	/// </summary>
	/// <param name="user">User reference</param>
	/// <param name="startDate">Start of the searching period</param>
	/// <param name="endDate">End of the searching period</param>
	/// <param name="isComplete">Optional flag to filter</param>
	/// <param name="isHidden">Optional flag to filter</param>
	IEnumerable<ToDoItem> GetLastUpdatedBetween(string user, DateTime startDate, DateTime endDate, bool? isComplete = null, bool? isHidden = null);
}