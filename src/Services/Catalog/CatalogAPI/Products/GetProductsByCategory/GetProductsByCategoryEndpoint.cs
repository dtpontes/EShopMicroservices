using Carter;
using CatalogAPI.Models;
using Mapster;
using MediatR;

namespace CatalogAPI.Products.GetProductsByCategory;

public record GetProductsByCategoryRequest(string Category);

public record GetProductsByCategoryResponse(IEnumerable<Product> Products);

public class GetProductsByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
        {
            var result = await sender.Send(new GetProductsByCategoryQuery(category));
            var response = result.Adapt<GetProductsByCategoryResponse>();

            return Results.Ok(response);
        })
         .WithName("GetProductsByCategorie")
        .Produces<GetProductsByCategoryResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products by Categories")
        .WithDescription("Get Products by Categorie");
    }
}