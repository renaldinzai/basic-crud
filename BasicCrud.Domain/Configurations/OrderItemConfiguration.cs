using BasicCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasicCrud.Domain.Configurations
{
    public class OrderItemConfiguration : BaseEntityConfiguration<OrderItem>
    {
        public override void EntityConfiguration(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasIndex(e => e.OrderId);

            builder.HasIndex(e => e.ProductId);
        }
    }
}
