using BasicCrud.Application.Interfaces;
using BasicCrud.Common.Constants;
using BasicCrud.Common.Exceptions;
using BasicCrud.Common.Models;
using BasicCrud.Domain.Interfaces;

namespace BasicCrud.Application.Products
{
    public class ProductQuery : IProductQuery
    {
        private readonly IProductRepository _productRepository;

        public ProductQuery(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ApiResponse> GetProducts(CancellationToken cancellationToken)
        {
            try
            {
                var products = await _productRepository.GetAllAsync(cancellationToken);

                if (!products.Any())
                {
                    throw new ProductValidationException("No product found");
                }

                var result = new ListProductDto();

                foreach (var product in products)
                {
                    result.Products?.Add(new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Stock = product.Stock
                    });
                }

                return new ApiResponse() { Results = result };
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
                    Message = ErrorMessage.InternalServerError
                };
            }
        }
    }
}
