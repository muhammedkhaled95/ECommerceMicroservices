using MediatR;

namespace BuildingBlocks.CQRS;


/// <summary>
/// Represents a command in the CQRS pattern that performs an action and does not return a value.
/// </summary>
public interface ICommand : ICommand<Unit>
{
}

/// <summary>
/// Represents a command in the CQRS pattern that performs an action and returns a result.
/// </summary>
/// <typeparam name="TResponse">
/// The type of the response returned by the command.
/// </typeparam>
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}


