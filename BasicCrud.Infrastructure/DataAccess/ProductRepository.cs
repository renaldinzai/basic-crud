using BasicCrud.Application.Interfaces;
using BasicCrud.Domain.Entities;
using BasicCrud.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Infrastructure.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataContext _dbContext;

        public ProductRepository(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _dbContext.Product
                    .Where(x => x.DeletedDate == null)
                    .OrderByDescending(x => x.UpdatedDate ?? x.CreatedDate)
                    .ToListAsync(cancellationToken);
            return result;
        }

        public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Product.FirstOrDefaultAsync(x => x.Id == id && x.DeletedDate == null, cancellationToken);
            return result;
        }

        public async Task<IEnumerable<Product>> GetByIdsAsync(Guid[] ids, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Product.Where(x => ids.Contains(x.Id) && x.DeletedDate == null).ToListAsync(cancellationToken);
            return result;
        }

        public async Task<Product?> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Product.FirstOrDefaultAsync(x => x.Name == name && x.DeletedDate == null, cancellationToken);
            return result;
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
