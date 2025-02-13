using BasicCrud.Application.Interfaces;
using BasicCrud.Common.Constants;
using BasicCrud.Common.Models;
using BasicCrud.Domain.Interfaces;

namespace BasicCrud.Application.Products
{
    public class OrderQuery : IOrderQuery
    {
        private readonly IOrderRepository _orderRepository;

        public OrderQuery(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ApiResponse> GetOrders(CancellationToken cancellationToken)
        {
            try
            {
                var orderWithItems = await _orderRepository.GetAllOrdersWithItemsAsync(cancellationToken);

                var response = orderWithItems.Select(order => new OrdersDto
                {
                    Uuid = order.Id,
                    Products = order.OrderItems?.Select(item => new OrderProductDto
                    {
                        Name = item.Product.Name,
                        Quantity = item.Quantity,
                        Price = item.PriceAtOrder
                    }).ToList(),
                    TotalPrice = order.TotalAmount
                }).ToList();

                var result = new OrderResponseDto();
                result.Orders.AddRange(response);

                return new ApiResponse() { Results = result };
            }
            catch
            {
                return new ApiResponse()
                {
                    Status = Status.Failed,
                    Code = StatusCode.InternalServerError,
                    Message = ErrorMessage.InternalServerError
                };
            }
        }
    }
}
