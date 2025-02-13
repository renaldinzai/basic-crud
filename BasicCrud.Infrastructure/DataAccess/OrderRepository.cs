using BasicCrud.Application.Interfaces;
using BasicCrud.Domain.Entities;
using BasicCrud.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Infrastructure.DataAccess
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDataContext _dbContext;

        public OrderRepository(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddOrder(Order order, CancellationToken cancellationToken)
        {
            await _dbContext.Order.AddAsync(order, cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersWithItemsAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Order.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).ToListAsync(cancellationToken);
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
