using BuildingBlocks.CQRS;
using CatalogAPI.Exceptions;
using CatalogAPI.Models;
using Marten;

namespace CatalogAPI.Products.GetProductById;  

public record GetProductByIdQuery(Guid Id): IQuery<GetProductByIdResult>;

public record GetProductByIdResult(Product Product);


internal class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting product by ID called with {@Query}", query);

        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

        if(product == null)
        {
            throw new ProductNotFoundException(query.Id);
        }
        else
        {
            return new GetProductByIdResult(product);
        }

        
    }
}
