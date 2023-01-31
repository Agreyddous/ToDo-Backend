using ToDo.Domain.Commands.Contracts;

namespace ToDo.Domain.Commands;

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
	public string? Message { get; private set; }
	public object? Data { get; private set; }
}