using BasicCrud.Application.Orders.Request;
using BasicCrud.Common.Models;

namespace BasicCrud.Application.Interfaces
{
    public interface IOrderCommand
    {
        Task<ApiResponse> AddOrders(AddOrderRequest request, Guid loginUserId, CancellationToken cancellationToken);
    }
}
