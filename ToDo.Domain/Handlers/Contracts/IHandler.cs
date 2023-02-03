using ToDo.Domain.Commands.Contracts;

namespace ToDo.Domain.Handlers.Contracts;

/// <summary>
/// Generic contract for Handlers
/// </summary>
/// <typeparam name="TCommand">Command to be provided to the handler</typeparam>
public interface IHandler<TCommand>
	where TCommand : ICommand
{
	/// <summary>
	/// Method to handle a certain type of command
	/// </summary>
	/// <param name="command">Command containing data required to handle an action</param>
	/// <returns>Implementation of ICommandResult</returns>
	ICommandResult Handle(TCommand command);
}