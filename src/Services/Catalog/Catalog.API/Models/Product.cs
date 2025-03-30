namespace Catalog.API.Models;

public class Product
{
    public Guid Id { get; set; }

    // Initialized with default (null) but marked as non-null using the null forgiving symbol "!" to suppress compiler warnings.
    // string is a reference type so it's default is null.
    public string Name { get; set; } = default!;

    // Initializes with an empty list to prevent null reference issues as List<T> is a reference type.
    public List<string> Category { get; set; } = new();

    public string Description { get; set; } = default!;
    public string ImageFile { get; set; } = default!;
    public decimal Price { get; set; } // Automatically initialized to 0 as decimal is a value type.
    // public decimal? Price { get; set; } --> Allows null in the database; without '?', it defaults to 0 and cannot be null. 
    // The same goes for all value types.


}
