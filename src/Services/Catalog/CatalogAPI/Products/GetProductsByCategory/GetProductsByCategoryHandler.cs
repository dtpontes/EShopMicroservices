using BuildingBlocks.CQRS;
using CatalogAPI.Models;
using Marten;

namespace CatalogAPI.Products.GetProductsByCategory;

public record GetProductsByCategoryQuery(string Category): IQuery<GetProductsByCategoryResult>;

public record GetProductsByCategoryResult(IEnumerable<Product> Products);


internal class GetProductsByCategoryQueryHandler(IDocumentSession session, ILogger<GetProductsByCategoryQueryHandler> logger) : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
{
    public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting product by Category called with {@Query}", query);

        var products = await session.Query<Product>()
                        .Where(x => x.Category.Any(c => c.Equals(query.Category, StringComparison.OrdinalIgnoreCase)))
                        .ToListAsync();

        return new GetProductsByCategoryResult(products);
        

        
    }
}
