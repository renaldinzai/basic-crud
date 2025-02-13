using BasicCrud.Application.Interfaces;
using BasicCrud.AuditTrail;
using BasicCrud.Common.Interfaces;
using BasicCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Persistence.Postgres
{
    public class DataContext : AuditableContext, IDataContext
    {
        private readonly ICurrentUserService _currentUserService;

        public DataContext(DbContextOptions<DataContext> options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedByUserId = _currentUserService?.UserId;
                    if (!entry.Entity.CreatedDate.HasValue)
                    {
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                    }
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedByUserId = _currentUserService?.UserId;
                    entry.Entity.UpdatedDate = DateTime.UtcNow;
                }
            }

            return SaveChangesAsync(cancellationToken, _currentUserService?.UserId);
        }
    }
}
