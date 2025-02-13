using BasicCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasicCrud.Domain.Configurations
{
    public class ProductConfiguration : BaseEntityConfiguration<Product>
    {
        public override void EntityConfiguration(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Name).HasMaxLength(254);
            builder.HasIndex(e => e.Name);
        }
    }
}
