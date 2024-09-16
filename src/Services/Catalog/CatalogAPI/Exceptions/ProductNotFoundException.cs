namespace CatalogAPI.Exceptions;

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(Guid id) : base($"Product with ID {id} not found")
    {
    }
}
