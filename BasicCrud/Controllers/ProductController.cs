using BasicCrud.Application.Interfaces;
using BasicCrud.Application.Products.Requests;
using BasicCrud.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicCrud.Controllers
{
    [ApiController]
    public class ProductController : BaseController
    {
        //we may need consider to use MediatR if more features/use cases to be introduced
        private readonly IProductQuery _productQuery;
        private readonly IProductCommand _productCommand;

        public ProductController(IProductQuery productQuery, IProductCommand productCommand)
        {
            _productQuery = productQuery;
            _productCommand = productCommand;
        }

        [HttpGet("products")]
        [Authorize]
        public async Task<ApiResponse> GetProducts(CancellationToken cancellationToken)
        {
            var result = await _productQuery.GetProducts(cancellationToken);
            return result;
        }

        [HttpPut("products/{id}")]
        [Authorize]
        public async Task<ApiResponse> UpdateProduct(Guid id, [FromBody] UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var userId = GetCurrentUserId();
            var result = await _productCommand.UpdateProduct(id, request, userId, cancellationToken);
            return result;
        }

        [HttpDelete("products")]
        [Authorize]
        public async Task<ApiResponse> DeleteProducts([FromBody] DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var userId = GetCurrentUserId();
            var result = await _productCommand.DeleteProduct(request, userId, cancellationToken);
            return result;
        }
    }
}
