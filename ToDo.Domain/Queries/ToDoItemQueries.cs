using System.Linq.Expressions;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Queries;

public static class ToDoItemQueries
{
	/// <summary>
	/// Retrieve a To-Do Item by it's Id
	/// </summary>
	/// <param name="user">User reference</param>
	/// <param name="id">Unique Identifier corresponding to an existing To-Do Item</param>
	/// <returns></returns>
	public static Expression<Func<ToDoItem, bool>> Get(string user, Guid id) => toDoItem => toDoItem.Id == id
																						 && toDoItem.User == user;

	/// <summary>
	/// Returns all To-Do Items of a certain user
	/// </summary>
	/// <param name="user">User reference</param>
	/// <returns></returns>
	public static Expression<Func<ToDoItem, bool>> GetAll(string user) => toDoItem => toDoItem.User == user;

	/// <summary>
	/// Returns all To-Do Items of a certain user that are not hidden
	/// </summary>
	/// <param name="user">User reference</param>
	/// <returns></returns>
	public static Expression<Func<ToDoItem, bool>> GetAllAvailable(string user) => toDoItem => toDoItem.User == user
																							&& !toDoItem.IsHidden;

	/// <summary>
	/// Returns all To-Do Items of a certain user that are hidden
	/// </summary>
	/// <param name="user">User reference</param>
	/// <returns></returns>
	public static Expression<Func<ToDoItem, bool>> GetAllHidden(string user) => toDoItem => toDoItem.User == user
																						 && toDoItem.IsHidden;

	/// <summary>
	/// Returns all To-Do Items of a certain user that are due between the provided Start and End dates
	/// </summary>
	/// <param name="user">User reference</param>
	/// <param name="startDate">Start of the searching period</param>
	/// <param name="endDate">End of the searching period</param>
	/// <param name="isComplete">Optional flag to filter</param>
	/// <param name="isHidden">Optional flag to filter</param>
	/// <returns></returns>
	public static Expression<Func<ToDoItem, bool>> GetAllDueBetween(string user, DateTime startDate, DateTime endDate, bool? isComplete = null, bool? isHidden = null) => toDoItem => toDoItem.User == user
																																							&& toDoItem.DueDate >= startDate
																																							&& toDoItem.DueDate <= endDate
																																							&& toDoItem.IsComplete == (isComplete ?? toDoItem.IsComplete)
																																							&& toDoItem.IsHidden == (isHidden ?? toDoItem.IsHidden);

	/// <summary>
	/// Returns all completed To-Do Items of a certain user
	/// </summary>
	/// <param name="user">User reference</param>
	/// <returns></returns>
	public static Expression<Func<ToDoItem, bool>> GetAllComplete(string user) => toDoItem => toDoItem.User == user
																						   && toDoItem.IsComplete;

	/// <summary>
	/// Returns all incomplete To-Do Items of a certain user
	/// </summary>
	/// <param name="user">User reference</param>
	/// <returns></returns>
	public static Expression<Func<ToDoItem, bool>> GetAllIncomplete(string user) => toDoItem => toDoItem.User == user
																							 && !toDoItem.IsComplete;

	/// <summary>
	/// Returns all To-Do Items of a certain user created between the provided Start and End dates
	/// </summary>
	/// <param name="user">User reference</param>
	/// <param name="startDate">Start of the searching period</param>
	/// <param name="endDate">End of the searching period</param>
	/// <returns></returns>
	public static Expression<Func<ToDoItem, bool>> GetCreatedBetween(string user, DateTime startDate, DateTime endDate) => toDoItem => toDoItem.User == user
																																	&& toDoItem.CreatedAt >= startDate
																																	&& toDoItem.CreatedAt <= endDate;

	/// <summary>
	/// Returns all To-Do Items of a certain user last updated between the provided Start and End dates
	/// </summary>
	/// <param name="user">User reference</param>
	/// <param name="startDate">Start of the searching period</param>
	/// <param name="endDate">End of the searching period</param>
	/// <param name="isComplete">Optional flag to filter</param>
	/// <param name="isHidden">Optional flag to filter</param>
	/// <returns></returns>
	public static Expression<Func<ToDoItem, bool>> GetLastUpdatedBetween(string user, DateTime startDate, DateTime endDate, bool? isComplete = null, bool? isHidden = null) => toDoItem => toDoItem.User == user
																																								 && toDoItem.LastUpdatedAt >= startDate
																																								 && toDoItem.LastUpdatedAt <= endDate
																																								 && toDoItem.IsComplete == (isComplete ?? toDoItem.IsComplete)
																																								 && toDoItem.IsHidden == (isHidden ?? toDoItem.IsHidden);
}