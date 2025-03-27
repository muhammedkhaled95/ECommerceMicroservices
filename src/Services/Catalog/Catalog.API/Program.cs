var builder = WebApplication.CreateBuilder(args);

// Add all the services to the DI container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.Run();
