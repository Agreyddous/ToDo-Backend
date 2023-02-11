using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Tests.Domain.Entities;

[TestClass]
public class ToDoItemTests
{
	[TestMethod("A newly created to-do item should have it's 'IsComplete' property set as false")]
	[TestCategory("Constructor")]
	public void NewToDoItemShouldBeIncomplete() => Assert.IsFalse(ToDoItem.IsComplete);

	internal static ToDoItem ToDoItem => NewToDoItem(string.Empty, string.Empty, string.Empty, DateTime.UtcNow);
	internal static ToDoItem NewToDoItem(string user, string title, string description, DateTime dueDate) => new ToDoItem(user, title, description, dueDate);
}