using Carter;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// STEP 1: Add services to the Dependency Injection (DI) container.
// ---------------------------------------------------------------

// Register Carter - a lightweight framework for defining API endpoints in a modular way.
builder.Services.AddCarter();

// Register MediatR - a library that helps implement the Mediator design pattern.
builder.Services.AddMediatR(config =>
{
    // The following line registers all MediatR handlers from the current assembly (where Program.cs is located).
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

// STEP 2: Build the application
var app = builder.Build();

// STEP 3: Configure the HTTP request pipeline.
// --------------------------------------------

// Map Carter endpoints automatically.
app.MapCarter();

// Start the application.
app.Run();
