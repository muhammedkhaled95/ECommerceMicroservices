﻿namespace Catalog.API.Products.CreateProduct;

// Records are an excellent choice for CQRS Command, Query, and Result objects
// because they are primarily data carriers and often immutable
public record CreateProductCommand(string Name, List<string> Category, string Description,
                                   string ImageFile, decimal Price) : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler(IDocumentSession documentSession) 
               : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // Create a product entity object from the command object
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        // Save to the database. (Skip for now)
        documentSession.Store(product);
        await documentSession.SaveChangesAsync(cancellationToken);

        // Return the Result
        return new CreateProductResult(product.Id);
    }
}
