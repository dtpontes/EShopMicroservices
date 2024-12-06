using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Extensions;

public static class InitialData
{
    public static IEnumerable<Customer> Customers => new List<Customer>
    {
        Customer.Create(CustomerId.Of(new Guid("39DF5EC3-5E8F-4490-8226-4EB14738E85D")), "Customer 1", "customer1@localhost"),
        Customer.Create(CustomerId.Of(new Guid("113CF0B0-2C05-446C-85C6-52A6DD716D36")), "Customer 2", "customer2 @localhost")
    };

    public static IEnumerable<Product> Products => new List<Product>
    {
        Product.Create(ProductId.Of(new Guid("A1166365-2371-44E2-B60D-B3691BA1F8A5")), "Product 1", 50),
        Product.Create(ProductId.Of(new Guid("F8D4B686-634A-46FA-A486-D4D4DF1A477A")), "Product 2", 30),
        Product.Create(ProductId.Of(new Guid("3BD24C18-A3FC-4A35-8F4C-4D6A3A23999D")), "Product 3", 20),
        Product.Create(ProductId.Of(new Guid("447488D3-4D62-4B75-AB97-02E750688C44")), "Product 4", 10)
    };

    public static IEnumerable<Order> OrderWithItems 
    {
        get
        {
            var address1 = Address.Of("John", "Doe", "customer1@localhost", "A Street", "Brazil","São Paulo", "04303001");
            var address2 = Address.Of("Mary", "Zoe", "customer2@localhost", "A Street", "Brazil", "São Paulo", "04303001");

            var payment1 = Payment.Of("Visa","1234123412341234", DateTime.Now, "123",1);
            var payment2 = Payment.Of("Master", "1234123412341234", DateTime.Now, "123", 1);

            var order1 = Order.Create(
                                    OrderId.Of(new Guid("D3A3D3A3-3A3A-3A3A-3A3A-3A3A3A3A3A3A")), 
                                    CustomerId.Of(new Guid("39DF5EC3-5E8F-4490-8226-4EB14738E85D")), 
                                    OrderName.Of("Orde1"),
                                    shippingAddress: address1,
                                    billingAddress: address1,
                                    payment1);

            order1.Add(ProductId.Of(new Guid("A1166365-2371-44E2-B60D-B3691BA1F8A5")), 2, 50);
            order1.Add(ProductId.Of(new Guid("F8D4B686-634A-46FA-A486-D4D4DF1A477A")), 2, 30);

            var order2 = Order.Create(
                                    OrderId.Of(new Guid("{2B9A9390-B09F-4183-9003-83023D031496}")),
                                    CustomerId.Of(new Guid("113CF0B0-2C05-446C-85C6-52A6DD716D36")),
                                    OrderName.Of("Orde2"),
                                    shippingAddress: address2,
                                    billingAddress: address2,
                                    payment2);

            order2.Add(ProductId.Of(new Guid("3BD24C18-A3FC-4A35-8F4C-4D6A3A23999D")), 3, 20);
            order2.Add(ProductId.Of(new Guid("447488D3-4D62-4B75-AB97-02E750688C44")), 3, 10);

            return new List<Order> { order1, order2 };

        }
    }


}
