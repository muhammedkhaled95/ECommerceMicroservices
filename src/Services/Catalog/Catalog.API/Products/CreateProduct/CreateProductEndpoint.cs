namespace Catalog.API.Products.CreateProduct;

/// <summary>
/// Represents the request data needed to create a product.
/// </summary>
/// <param name="Name">The name of the product.</param>
/// <param name="Category">The list of categories the product belongs to.</param>
/// <param name="Description">A description of the product.</param>
/// <param name="ImageFile">The image file name or URL of the product.</param>
/// <param name="Price">The price of the product.</param>
public record CreateProductRequest(string Name, List<string> Category, string Description,
                                   string ImageFile, decimal Price);

/// <summary>
/// Represents the response returned after successfully creating a product.
/// </summary>
/// <param name="Id">The unique identifier of the newly created product.</param>
public record CreateProductResponse(Guid Id);

/// <summary>
/// Defines the API endpoint for creating a new product using Carter.
/// </summary>
public class CreateProductEndpoint : ICarterModule
{
    /// <summary>
    /// Adds the route for creating a new product to the endpoint route builder.
    /// </summary>
    /// <param name="app">The endpoint route builder used to map routes.</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
        {
            // Convert the request DTO to a CreateProductCommand using Mapster
            var command = request.Adapt<CreateProductCommand>();

            // Send the command to the MediatR pipeline for processing
            var result = await sender.Send(command);

            // Convert the result to a response DTO
            var response = result.Adapt<CreateProductResponse>();

            // Return a 201 Created response with the new product's location and data
            return Results.Created($"/products/{response.Id}", response);
        })
        .WithName("Create Product") // Sets a human-readable name for the endpoint
        .Produces<CreateProductResponse>(StatusCodes.Status201Created) // Defines a successful response
        .ProducesProblem(StatusCodes.Status400BadRequest) // Defines a possible error response
        .WithSummary("Create Product") // Adds a short summary for documentation
        .WithDescription("Create Product"); // Adds a detailed description for documentation
    }
}
