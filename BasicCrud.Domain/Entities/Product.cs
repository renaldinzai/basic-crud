namespace BasicCrud.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public virtual ICollection<OrderItem>? OrderItems { get; private set; }

        public void Update(string name, decimal price, int stock, string userId)
        {
            SetName(name);
            SetPrice(price);
            SetStock(stock);
            SetUpdatedByUserId(userId);
            SetUpdatedDate();
        }

        public void SoftDelete(string userId)
        {
            DeletedDate = DateTime.UtcNow;
            DeletedByUserId = userId;
        }

        public bool IsStockAvailable(int quantity)
        {
            return Stock >= quantity;
        }

        public void DecreaseStock(int quantity)
        {
            if (Stock < quantity)
                throw new InvalidOperationException("Not enough stock.");

            Stock -= quantity;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new InvalidOperationException("Product name cannot be empty.");

            Name = name;
        }

        private void SetPrice(decimal price)
        {
            if (price <= 0)
                throw new InvalidOperationException("Price must be positive.");

            Price = price;
        }

        private void SetStock(int stock)
        {
            if (stock <= 0)
                throw new InvalidOperationException("Price must be positive.");

            Stock = stock;
        }

        private void SetUpdatedByUserId(string userId)
        {
            UpdatedByUserId = userId;
        }

        private void SetUpdatedDate()
        {
            UpdatedDate = DateTime.UtcNow;
        }
    }
}
