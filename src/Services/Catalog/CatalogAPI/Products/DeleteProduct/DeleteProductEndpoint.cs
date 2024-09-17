using Carter;
using CatalogAPI.Products.CreateProduct;
using Mapster;
using MediatR;

namespace CatalogAPI.Products.DeleteProduct;

public record DeleteProductRequest(Guid Id);

public record DeleteProductResponse(bool IsSuccess);

public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
        {
            //Adapt faz parte do pacote Mapster para mapear objetos

            var request = new DeleteProductRequest(id);

            var command = request.Adapt<DeleteProductCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<DeleteProductResponse>();
            return Results.Ok(response);

        })
        .WithName("DeleteProduct")
        .Produces<DeleteProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete a product")
        .WithDescription("Delete a product in the catalog");
    }
}
