using MediatR;

namespace BuildingBlocks.CQRS;

/// <summary>
/// Defines a handler for a command that does not return any data.
/// </summary>
/// <typeparam name="TCommand">
/// The type of the command to handle. The command must implement <see cref="ICommand{Unit}"/>.
/// </typeparam>
public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit>
    where TCommand : ICommand<Unit>
{
}

/// <summary>
/// Defines a handler for a command that returns a result of type <typeparamref name="TResponse"/>.
/// </summary>
/// <typeparam name="TCommand">
/// The type of the command to handle. The command must implement <see cref="ICommand{TResponse}"/>.
/// </typeparam>
/// <typeparam name="TResponse">
/// The type of the response returned after handling the command.
/// Must be a non-nullable type.
/// </typeparam>
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse : notnull
{
}

