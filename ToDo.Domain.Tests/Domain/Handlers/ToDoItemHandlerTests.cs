using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDo.Domain.Handlers;
using ToDo.Domain.Tests.Domain.Command;
using ToDo.Domain.Tests.Domain.Repositories;

namespace ToDo.Domain.Tests.Domain.Handlers;

[TestClass]
public class ToDoItemHandlerTests
{
	[TestMethod("When an invalid command is provided, the execution should fail")]
	[TestCategory("Create to-do item")]
	public void InvalidCreateToDoItemCommandShouldCauseFailure() => Assert.IsFalse(Handler.Handle(CreateToDoItemCommandTests.InvalidCommand).Success);


	[TestMethod("When a valid command is provided, a new to-do item should be created")]
	[TestCategory("Create to-do item")]
	public void ValidCreateToDoItemCommandShouldCreateNewToDoItem() => Assert.IsTrue(Handler.Handle(CreateToDoItemCommandTests.ValidCommand).Success);

	internal static ToDoItemHandler Handler => new ToDoItemHandler(new FakeToDoItemRepository());
}