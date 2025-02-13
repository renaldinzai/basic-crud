using BasicCrud.Application.Interfaces;
using BasicCrud.Application.Products.Requests;
using BasicCrud.Common.Constants;
using BasicCrud.Common.Exceptions;
using BasicCrud.Common.Models;
using BasicCrud.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace BasicCrud.Application.Products
{
    public class ProductCommand : IProductCommand
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderItemRepository _orderItemRepository;

        public ProductCommand(IProductRepository productRepository, IOrderItemRepository orderItemRepository)
        {
            _productRepository = productRepository;
            _orderItemRepository = orderItemRepository;
        }

        public async Task<ApiResponse> UpdateProduct(Guid productId, UpdateProductRequest request, Guid loginUserId, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(productId, cancellationToken) ?? throw new ProductValidationException($"Product with id {productId} not found.");

                var existingProduct = await _productRepository.GetByNameAsync(request.Name, cancellationToken);

                if (existingProduct != null && existingProduct.Id != productId)
                {
                    throw new ProductValidationException($"Product with name {request.Name} already exists.");
                }

                product.Update(request.Name, request.Price, request.Stock, loginUserId.ToString());

                await _productRepository.SaveAsync(cancellationToken);

                return new ApiResponse() { Message = "Product updated successfully." };
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
            catch
            {
                return new ApiResponse()
                {
                    Status = Status.Failed,
                    Code = StatusCode.InternalServerError,
                    Message = ErrorMessage.InternalServerError,
                    Results = null
                };
            }
        }

        public async Task<ApiResponse> DeleteProduct(DeleteProductRequest request, Guid loginUserId, CancellationToken cancellationToken)
        {
            try
            {
                bool uuidValid = Guid.TryParse(request.Uuid, out Guid productId);

                if (!uuidValid)
                {
                    throw new BadRequestException("Invalid uuid.");
                }

                var product = await _productRepository.GetByIdAsync(productId, cancellationToken) ?? throw new ProductValidationException($"Product with id {productId} not found.");

                var orderItem = await _orderItemRepository.GetByProductId(productId, cancellationToken);

                if (orderItem != null)
                {
                    throw new ProductValidationException("Cannot remove the product as it is already listed in the order.");
                }

                product.SoftDelete(loginUserId.ToString());

                await _productRepository.SaveAsync(cancellationToken);

                return new ApiResponse() { Message = "Product deleted successfully." };
            }
            catch (BadRequestException ex)
            {
                return new ApiResponse()
                {
                    Status = Status.Failed,
                    Code = StatusCode.BadRequest,
                    Message = ex.Message
                };
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
            catch
            {
                return new ApiResponse()
                {
                    Status = Status.Failed,
                    Code = StatusCode.InternalServerError,
                    Message = ErrorMessage.InternalServerError,
                    Results = null
                };
            }
        }
    }
}
