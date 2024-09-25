using CatalogAPI.Models;
using Marten;
using Marten.Schema;

namespace CatalogAPI.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if(await session.Query<Product>().AnyAsync())
            {
                return;
            }

            var products = new List<Product>
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 1",
                    Category = new List<string> { "Category 1" },
                    Description = "Description 1",
                    ImageFile = "ImageFile 1",
                    Price = 10
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 2",
                    Category = new List<string> { "Category 2" },
                    Description = "Description 2",
                    ImageFile = "ImageFile 2",
                    Price = 20
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 3",
                    Category = new List<string> { "Category 3" },
                    Description = "Description 3",
                    ImageFile = "ImageFile 3",
                    Price = 30
                }
            };

            session.Store<Product>(products);
            await session.SaveChangesAsync();
        }
    }
}
