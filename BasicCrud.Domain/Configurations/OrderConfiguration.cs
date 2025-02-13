using BasicCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasicCrud.Domain.Configurations
{
    public class OrderConfiguration : BaseEntityConfiguration<Order>
    {
        public override void EntityConfiguration(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();
        }
    }
}
