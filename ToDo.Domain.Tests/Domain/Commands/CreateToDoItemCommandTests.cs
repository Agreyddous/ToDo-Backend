using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDo.Domain.Commands;

namespace ToDo.Domain.Tests.Domain.Command;

[TestClass]
public class CreateToDoItemCommandTests
{
	internal const string ValidUser = "Valid User";
	internal const string ValidTitle = "Valid Title";
	internal const string ValidDescription = "Valid Description";

	[TestMethod("Test command's fail fast validation")]
	[TestCategory("Fail Fast")]

	[DataRow("", "", "", false)]
	[DataRow(ValidUser, "", "", false)]
	[DataRow("", ValidTitle, "", false)]
	[DataRow("", "", ValidDescription, false)]
	[DataRow(ValidUser, ValidTitle, "", false)]
	[DataRow(ValidUser, "", ValidDescription, false)]
	[DataRow("", ValidTitle, ValidDescription, false)]
	[DataRow(ValidUser, ValidTitle, ValidDescription, true)]
	public void CommandFailFastValidation(string user,
									   string title,
									   string description,
									   bool isValid) => Assert.AreEqual(isValid, _newCommand(user, title, description).Valid);

	internal static CreateToDoItemCommand ValidCommand => _newCommand(ValidUser, ValidTitle, ValidDescription);
	internal static CreateToDoItemCommand InvalidCommand => _newCommand();

	private static CreateToDoItemCommand _newCommand(string? user = null,
												  string? title = null,
												  string? description = null)
	{
		CreateToDoItemCommand command = new CreateToDoItemCommand(user, title, description);
		command.Validate();

		return command;
	}
}