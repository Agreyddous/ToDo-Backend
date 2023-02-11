using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDo.Domain.Commands;

namespace ToDo.Domain.Tests.Domain.Command;

[TestClass]
public class CreateToDoItemCommandTests
{
	internal const string ValidUser = "Valid User";
	internal const string ValidTitle = "Valid Title";
	internal const string ValidDescription = "Valid Description";

	internal readonly DateTime InvalidDueDate = DateTime.MinValue;
	internal readonly DateTime ValidDueDate = DateTime.MaxValue;

	[TestMethod("Test command's fail fast validation")]
	[TestCategory("Fail Fast")]

	[DataRow("", "", "", false)]
	[DataRow(ValidUser, "", "", false)]
	[DataRow("", ValidTitle, "", false)]
	[DataRow("", "", ValidDescription, false)]
	[DataRow(ValidUser, ValidTitle, "", false)]
	[DataRow(ValidUser, "", ValidDescription, false)]
	[DataRow("", ValidTitle, ValidDescription, false)]
	[DataRow(ValidUser, ValidTitle, ValidDescription, false)]
	[DataRow(ValidUser, ValidTitle, ValidDescription, true)]
	public void CommandFailFastValidation(string user,
									   string title,
									   string description,
									   bool isValid) => Assert.AreEqual(isValid, _newCommand(user, title, description, isValid ? ValidDueDate : InvalidDueDate).Valid);

	internal static CreateToDoItemCommand ValidCommand => _newCommand(ValidUser, ValidTitle, ValidDescription, DateTime.MaxValue);
	internal static CreateToDoItemCommand InvalidCommand => _newCommand();

	private static CreateToDoItemCommand _newCommand(string? user = null,
												  string? title = null,
												  string? description = null,
												  DateTime? dueDate = null)
	{
		CreateToDoItemCommand command = new CreateToDoItemCommand(title, description, dueDate);
		command.SetUser(user);
		command.Validate();

		return command;
	}
}