using BasicCrud.Domain.Entities;

namespace BasicCrud.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken);

        Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<IEnumerable<Product>> GetByIdsAsync(Guid[] ids, CancellationToken cancellationToken);

        Task<Product?> GetByNameAsync(string name, CancellationToken cancellationToken);

        Task SaveAsync(CancellationToken cancellationToken);
    }
}
