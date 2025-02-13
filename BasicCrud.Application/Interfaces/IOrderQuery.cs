using BasicCrud.Common.Models;

namespace BasicCrud.Application.Interfaces
{
    public interface IOrderQuery
    {
        Task<ApiResponse> GetOrders(CancellationToken cancellationToken);
    }
}
