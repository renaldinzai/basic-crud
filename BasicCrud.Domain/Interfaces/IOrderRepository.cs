using BasicCrud.Domain.Entities;

namespace BasicCrud.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task AddOrder(Order order, CancellationToken cancellationToken);

        Task<IEnumerable<Order>> GetAllOrdersWithItemsAsync(CancellationToken cancellationToken);

        Task SaveAsync(CancellationToken cancellationToken);
    }
}
