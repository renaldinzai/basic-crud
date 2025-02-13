using BasicCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Application.Interfaces
{
    public interface IDataContext
    {
        DbSet<User> User { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<Order> Order { get; set; }
        DbSet<OrderItem> OrderItem { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
