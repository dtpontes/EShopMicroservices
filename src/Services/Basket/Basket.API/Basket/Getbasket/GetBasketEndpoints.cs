using Basket.API.Models;
using Carter;
using Mapster;
using MediatR;

namespace Basket.API.Basket.Getbasket;

public record GetBasketResponse(ShoppingCart cart);

public class GetBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
        {

            var result = await sender.Send(new GetBasketQuery(userName));
            var response = result.Adapt<GetBasketResponse>();

            return Results.Ok(response);
        })
            .Produces<GetBasketResponse>(StatusCodes.Status200OK)
            .WithSummary("Get the basket for a user")
            .WithDescription("Get the basket for a user")
            .WithName("GetProductById")
            .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
