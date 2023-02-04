using System.Linq.Expressions;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Orderings;

public static class ToDoItemOrdering
{
	/// <summary>
	/// Ordering to-do items by creation date
	/// </summary>
	public static Expression<Func<ToDoItem, DateTime>> CreateDate => toDoItems => toDoItems.CreatedAt;

	/// <summary>
	/// Ordering to-do items by last update's date
	/// </summary>
	public static Expression<Func<ToDoItem, DateTime>> LastUpdate => toDoItems => toDoItems.LastUpdatedAt;
}