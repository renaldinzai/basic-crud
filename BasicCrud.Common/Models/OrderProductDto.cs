namespace BasicCrud.Common.Models
{
    public class OrderProductDto
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
