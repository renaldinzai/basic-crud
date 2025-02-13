using BasicCrud.Domain.Entities;

namespace BasicCrud.Domain.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<OrderItem?> GetByProductId(Guid productId, CancellationToken cancellationToken);
    }
}
