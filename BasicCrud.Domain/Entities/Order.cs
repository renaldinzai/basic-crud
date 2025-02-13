namespace BasicCrud.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; private set; }
        public decimal TotalAmount => CalculateTotalAmount();

        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
            Date = DateTime.UtcNow;
            CreatedDate = DateTime.UtcNow;
        }

        public virtual ICollection<OrderItem>? OrderItems { get; set; }

        private decimal CalculateTotalAmount()
        {
            return OrderItems.Sum(item => item.TotalPrice);
        }

        public void AddOrderItem(Product product, int quantity, string createdByUserId)
        {
            if (!product.IsStockAvailable(quantity))
            {
                throw new InvalidOperationException($"Not enough stock for product {product.Id}");
            }

            OrderItems?.Add(new OrderItem(orderId: Id, productId: product.Id, createdByUserId, quantity, product.Price));

            product.DecreaseStock(quantity);
        }
    }
}
