namespace BasicCrud.Application.Products.Requests
{
    public class UpdateProductRequest
    {
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
