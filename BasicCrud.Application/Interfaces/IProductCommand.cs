using BasicCrud.Application.Products.Requests;
using BasicCrud.Common.Models;

namespace BasicCrud.Application.Interfaces
{
    public interface IProductCommand
    {
        Task<ApiResponse> UpdateProduct(Guid id, UpdateProductRequest request, Guid loginUserId, CancellationToken cancellationToken);

        Task<ApiResponse> DeleteProduct(DeleteProductRequest request, Guid loginUserId, CancellationToken cancellationToken);
    }
}
