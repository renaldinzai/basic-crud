using BasicCrud.Domain.Entities;

namespace BasicCrud.Domain.Seeds
{
    public static class ProductSeed
    {
        public static List<Product> GetDefaultProducts()
        {
            return
            [
                new() {
                    Id = Guid.NewGuid(),
                    Name = "baju",
                    Price = 10000,
                    Stock = 5,
                    CreatedDate = DateTime.UtcNow
                },
                new() {
                    Id = Guid.NewGuid(),
                    Name = "celana",
                    Price = 20000,
                    Stock = 10,
                    CreatedDate = DateTime.UtcNow
                }
            ];
        }

    }
}
