using Generic_Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Generic_Ecommerce.Infrastructure.Persistense.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.TotalAmount)
                   .HasPrecision(18, 2);

            builder.Property(o => o.Status)
                   .HasConversion<string>();

            builder.HasMany(o => o.OrderItems)
                   .WithOne()
                   .HasForeignKey("OrderId");
        }
    }

}
