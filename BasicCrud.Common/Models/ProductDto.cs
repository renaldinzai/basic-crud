namespace BasicCrud.Common.Models
{
    public class ListProductDto
    {
        public ListProductDto()
        {
            Products = [];
        }

        public List<ProductDto>? Products { get; set; }
    }

    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
