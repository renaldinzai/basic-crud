namespace BasicCrud.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtOrder { get; set; }
        public decimal TotalPrice => CalculateTotalPrice();

        public OrderItem(Guid orderId, Guid productId, string createdByUserId, int quantity, decimal priceAtOrder)
        {
            OrderId = orderId;
            ProductId = productId;
            CreatedByUserId = createdByUserId;
            CreatedDate = DateTime.UtcNow;
            SetQuantity(quantity);
            SetPriceAtOrder(priceAtOrder);
        }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

        private decimal CalculateTotalPrice() => Quantity * PriceAtOrder;

        public void SetQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new InvalidOperationException("Quantity must be greater than 0.");
            Quantity = quantity;
        }

        public void SetPriceAtOrder(decimal price)
        {
            if (price <= 0)
                throw new InvalidOperationException("Price must be greater than 0.");
            PriceAtOrder = price;
        }
    }
}
