using BuildingBlocks.CQRS;
using MediatR;

namespace Catalog.API.Products.CreateProduct;

// Records are an excellent choice for CQRS Command, Query, and Result objects
// because they are primarily data carriers and often immutable
public record CreateProductCommand(string Name, List<string> Category, string Description,
                                   string ImageFile, decimal Price) : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
