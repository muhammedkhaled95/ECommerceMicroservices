using MediatR;

namespace BuildingBlocks.CQRS;

/// <summary>
/// Represents a query in the CQRS pattern that retrieves data without modifying state.
/// </summary>
/// <typeparam name="TResponse">
/// The type of the response returned by the query. Must be a non-nullable type.
/// </typeparam>
public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
{
}
