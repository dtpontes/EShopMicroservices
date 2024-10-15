using BuildingBlocks.Behaviors;
using Carter;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;

// Add services to the container.
builder.Services.AddCarter();

builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssemblies(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();

app.Run();
