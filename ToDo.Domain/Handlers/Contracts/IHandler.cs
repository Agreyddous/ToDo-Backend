using ToDo.Domain.Commands.Contracts;

namespace ToDo.Domain.Handlers.Contracts;

public interface IHandler<TCommand>
	where TCommand : ICommand
{
	ICommandResult Handle(TCommand command);
}