using BasicCrud.Application.Interfaces;
using BasicCrud.Application.Orders.Request;
using BasicCrud.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicCrud.Controllers
{
    [ApiController]
    public class OrderController : BaseController
    {
        //we may need consider to use MediatR if more features/use cases to be introduced
        private readonly IOrderQuery _orderQuery;
        private readonly IOrderCommand _orderCommand;

        public OrderController(IOrderQuery orderQuery, IOrderCommand orderCommand)
        {
            _orderQuery = orderQuery;
            _orderCommand = orderCommand;
        }

        [HttpGet("orders")]
        [Authorize]
        public async Task<ApiResponse> GetOrders(CancellationToken cancellationToken)
        {
            var result = await _orderQuery.GetOrders(cancellationToken);
            return result;
        }

        [HttpPost("orders")]
        [Authorize]
        public async Task<ApiResponse> CreateOrders([FromBody] AddOrderRequest request, CancellationToken cancellationToken)
        {
            var userId = GetCurrentUserId();
            var result = await _orderCommand.AddOrders(request, userId, cancellationToken);
            return result;
        }
    }
}
