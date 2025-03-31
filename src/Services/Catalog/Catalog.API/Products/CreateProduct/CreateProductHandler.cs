using MediatR;

namespace Catalog.API.Products.CreateProduct;

// Records are an excellent choice for CQRS Command, Query, and Result objects
// because they are primarily data carriers and often immutable
public record CreateProductCommand(string Name, List<string> Category, string Description,
                                   string ImageFile, decimal Price) : IRequest<CreateProductResult>;
public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
