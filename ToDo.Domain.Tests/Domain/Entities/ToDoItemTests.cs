using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Tests.Domain.Entities;

[TestClass]
public class ToDoItemTests
{
	[TestMethod("A newly created to-do item should have it's 'IsComplete' property set as false")]
	[TestCategory("Constructor")]
	public void NewToDoItemShouldBeIncomplete() => Assert.IsFalse(ToDoItem.IsComplete);

	internal static ToDoItem ToDoItem => new ToDoItem(string.Empty, string.Empty, string.Empty);
}