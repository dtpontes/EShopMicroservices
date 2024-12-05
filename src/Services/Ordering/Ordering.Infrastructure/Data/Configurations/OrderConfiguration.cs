using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            orderId => orderId.Value,
            dbId => OrderId.Of(dbId));

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(c => c.CustomerId)
            .IsRequired();

        builder.HasMany(o => o.OrderItems)
            .WithOne()
            .HasForeignKey(oi => oi.OrderId);

        builder.ComplexProperty(
            o => o.OrderName, nameBuilder =>
            {
                nameBuilder.Property(n => n.Value)
                    .HasColumnName(nameof(Order.OrderName))
                    .HasMaxLength(100)
                    .IsRequired();
            });

        builder.ComplexProperty(
            o=>o.ShippingAddress, adressBuilder =>
            {
                adressBuilder.Property(a => a.FirstName)                 
                 .HasMaxLength(50)
                 .IsRequired();

                adressBuilder.Property(a => a.LastName)                    
                    .HasMaxLength(50)
                    .IsRequired();

                adressBuilder.Property(a => a.EmailAddress)                    
                    .HasMaxLength(50);

                adressBuilder.Property(a => a.AddressLine)                    
                    .HasMaxLength(180)
                    .IsRequired();

                adressBuilder.Property(a => a.Country)                    
                    .HasMaxLength(100);

                adressBuilder.Property(a => a.State)
                   .HasMaxLength(100);

                adressBuilder.Property(a => a.ZipCode)
                   .HasMaxLength(8);
            }
            );

        builder.ComplexProperty(
            o => o.BillingAddress, adressBuilder =>
            {
                adressBuilder.Property(a => a.FirstName)
                 .HasMaxLength(50)
                 .IsRequired();

                adressBuilder.Property(a => a.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                adressBuilder.Property(a => a.EmailAddress)
                    .HasMaxLength(50);

                adressBuilder.Property(a => a.AddressLine)
                    .HasMaxLength(180)
                    .IsRequired();

                adressBuilder.Property(a => a.Country)
                    .HasMaxLength(100);

                adressBuilder.Property(a => a.State)
                   .HasMaxLength(100);

                adressBuilder.Property(a => a.ZipCode)
                   .HasMaxLength(8);
            }
        );

        builder.ComplexProperty(
            o => o.Payment, paymentBuilder =>
            {
                paymentBuilder.Property(p => p.CardName)
                 .HasMaxLength(50);

                paymentBuilder.Property(a => a.CardNumber)
                    .HasMaxLength(24)
                    .IsRequired();

                paymentBuilder.Property(a => a.Expiration)
                    .HasMaxLength(10);

                paymentBuilder.Property(a => a.CVV)
                    .HasMaxLength(3)
                    .IsRequired();

                paymentBuilder.Property(a => a.PaymentMethod);                                 
            }
        );


        //builder.Property(c => c.Name).IsRequired().HasMaxLength(100);        
    }
}
