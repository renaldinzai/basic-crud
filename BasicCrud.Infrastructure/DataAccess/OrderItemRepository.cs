using BasicCrud.Application.Interfaces;
using BasicCrud.Domain.Entities;
using BasicCrud.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Infrastructure.DataAccess
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly IDataContext _dbContext;

        public OrderItemRepository(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderItem?> GetByProductId(Guid productId, CancellationToken cancellationToken)
        {
            var result = await _dbContext.OrderItem.FirstOrDefaultAsync(x => x.ProductId == productId && x.DeletedDate == null, cancellationToken);
            return result;
        }
    }
}
