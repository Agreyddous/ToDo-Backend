using System.Linq.Expressions;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Queries;

public static class ToDoItemQueries
{
	/// <summary>
	/// Returns all To-Do Items of a certain user
	/// </summary>
	/// <param name="user">User reference</param>
	/// <returns></returns>
	public static Expression<Func<ToDoItem, bool>> GetAll(string user) => toDoItems => toDoItems.User == user;

	/// <summary>
	/// Returns all completed To-Do Items of a certain user
	/// </summary>
	/// <param name="user">User reference</param>
	/// <returns></returns>
	public static Expression<Func<ToDoItem, bool>> GetAllComplete(string user) => toDoItems => toDoItems.User == user && toDoItems.IsComplete;

	/// <summary>
	/// Returns all incomplete To-Do Items of a certain user
	/// </summary>
	/// <param name="user">User reference</param>
	/// <returns></returns>
	public static Expression<Func<ToDoItem, bool>> GetAllIncomplete(string user) => toDoItems => toDoItems.User == user && !toDoItems.IsComplete;

	/// <summary>
	/// Returns all To-Do Items of a certain user created between the provided Start and End dates
	/// </summary>
	/// <param name="user">User reference</param>
	/// <param name="startDate">Start of the searching period</param>
	/// <param name="endDate">End of the searching period</param>
	/// <returns></returns>
	public static Expression<Func<ToDoItem, bool>> GetCreatedBetween(string user, DateTime startDate, DateTime endDate) => todoItems => todoItems.User == user && todoItems.CreatedAt >= startDate && todoItems.CreatedAt <= endDate;
}