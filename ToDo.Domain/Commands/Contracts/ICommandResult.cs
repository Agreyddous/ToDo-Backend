namespace ToDo.Domain.Commands.Contracts;

/// <summary>
/// Contract for the result of handling a command
/// </summary>
public interface ICommandResult
{
	/// <summary>
	/// Indicates whether the handling of a command was successful or not
	/// </summary>
	bool Success { get; }
}