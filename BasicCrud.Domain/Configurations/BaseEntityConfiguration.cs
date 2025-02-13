using BasicCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasicCrud.Domain.Configurations
{
    public abstract class BaseEntityConfiguration<TBaseEntity> : IEntityTypeConfiguration<TBaseEntity> where TBaseEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TBaseEntity> builder)
        {
            builder.Property(e => e.CreatedByUserId).HasMaxLength(maxLength: 254);

            builder.Property(e => e.UpdatedByUserId).HasMaxLength(maxLength: 254);

            builder.Property(e => e.DeletedByUserId).HasMaxLength(maxLength: 254);

            EntityConfiguration(builder);
        }

        public abstract void EntityConfiguration(EntityTypeBuilder<TBaseEntity> builder);
    }
}
