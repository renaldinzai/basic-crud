namespace BasicCrud.Application.Orders.Request
{
    public class AddOrderRequest
    {
        public List<ProductOrder> Products { get; set; } = [];
    }

    public class ProductOrder
    {
        public Guid Uuid { get; set; } = Guid.Empty;
        public int Total { get; set; }
    }
}
