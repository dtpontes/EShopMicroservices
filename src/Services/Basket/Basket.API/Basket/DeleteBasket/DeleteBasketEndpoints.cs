using Basket.API.Basket.StoreBasket;
using Basket.API.Models;
using Carter;
using Mapster;
using MediatR;

namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketRequest(string UserName);

public record DeleteBasketResponse(bool IsSuccess);

public class DeleteBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{use}", async (string userName, ISender sender) =>
        {            
            var result = await sender.Send(new DeleteBasketCommand(userName));

            var response = result.Adapt<DeleteBasketResponse>();

            return Results.Ok(response);
        })
            .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
            .WithSummary("Delete a Cart")
            .WithDescription("Delete a Cart")
            .WithName("Delete a Cart")
            .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
