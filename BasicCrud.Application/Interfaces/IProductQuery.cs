using BasicCrud.Common.Models;

namespace BasicCrud.Application.Interfaces
{
    public interface IProductQuery
    {
        Task<ApiResponse> GetProducts(CancellationToken cancellationToken);
    }
}
