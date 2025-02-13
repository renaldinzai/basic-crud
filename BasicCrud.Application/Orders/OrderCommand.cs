using BasicCrud.Application.Interfaces;
using BasicCrud.Application.Orders.Request;
using BasicCrud.Common.Constants;
using BasicCrud.Common.Exceptions;
using BasicCrud.Common.Extensions;
using BasicCrud.Common.Models;
using BasicCrud.Domain.Entities;
using BasicCrud.Domain.Interfaces;

namespace BasicCrud.Application.Orders
{
    public class OrderCommand : IOrderCommand
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderCommand(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task<ApiResponse> AddOrders(AddOrderRequest request, Guid loginUserId, CancellationToken cancellationToken)
        {
            try
            {
                var order = new Order { CreatedByUserId = loginUserId.ToString() };

                var productIds = request.Products.Select(x => x.Uuid).ToArray();
                var products = await _productRepository.GetByIdsAsync(productIds, cancellationToken);

                //early return if one of the product is not found
                var foundProductIds = products.Select(x => x.Id);
                var productIdNotFound = productIds.Except(foundProductIds);
                if (productIdNotFound.Any())
                {
                    throw new ProductValidationException($"Some products are not found. List of UUID: {productIdNotFound.SerializeContentObject()}.");
                }

                foreach (var product in request.Products)
                {
                    var productEntity = products.FirstOrDefault(x => x.Id == product.Uuid);

                    //already being checked which will throw if found any product not in the table
                    order.AddOrderItem(productEntity, product.Total, loginUserId.ToString());
                }

                await _orderRepository.AddOrder(order, cancellationToken);

                await _orderRepository.SaveAsync(cancellationToken);

                return new ApiResponse() { Code = StatusCode.Ok, Message = "Order created successfully." };
            }
            catch (ProductValidationException ex)
            {
                return new ApiResponse()
                {
                    Status = Status.Failed,
                    Code = StatusCode.Conflict,
                    Message = ex.Message
                };
            }
            catch (InvalidOperationException ex)
            {
                return new ApiResponse()
                {
                    Status = Status.Failed,
                    Code = StatusCode.Conflict,
                    Message = ex.Message
                };
            }
            catch(Exception ex)
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
