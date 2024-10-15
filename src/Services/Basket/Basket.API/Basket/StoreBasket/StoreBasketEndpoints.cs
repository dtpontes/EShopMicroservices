using Basket.API.Models;
using Carter;
using Mapster;
using MediatR;

namespace Basket.API.Basket.StoreBasket;

public record StoreBasketRequest(ShoppingCart cart);

public record StoreBasketResponse(string UserName);


public class StoreBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async (StoreBasketRequest request, ISender sender) =>
        {
            var commnad  = request.Adapt<StoreBasketCommand>();
            var result = await sender.Send(commnad);
            var response = result.Adapt<StoreBasketResponse>();

            return Results.Created($"/basket/{response.UserName}", response);
        })
            .Produces<StoreBasketResponse>(StatusCodes.Status200OK)
            .WithSummary("Create a Cart")
            .WithDescription("Create a Cart")
            .WithName("Create a Cart")
            .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}

