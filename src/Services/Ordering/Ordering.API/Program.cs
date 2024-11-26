using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

// Add services to the container.

var app = builder.Build();

app.UseApiServices();

//configure the HTTP request pipeline

app.Run();
