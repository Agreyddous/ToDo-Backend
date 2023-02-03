using ToDo.Domain.Commands.Contracts;

namespace ToDo.Domain.Commands;

/// <summary>
/// Generic Command Result
/// </summary>
public class GenericCommandResult : ICommandResult
{
	public GenericCommandResult() : this(false) { }
	public GenericCommandResult(bool success,
							 string? message = null,
							 object? data = null)
	{
		Success = success;
		Message = message;
		Data = data;
	}

	public bool Success { get; private set; }

	/// <summary>
	/// Result's message
	/// </summary>
	public string? Message { get; private set; }

	/// <summary>
	/// Result's Data
	/// </summary>
	public object? Data { get; private set; }
}