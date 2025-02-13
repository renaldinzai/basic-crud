namespace BasicCrud.Common.Models
{
    public class OrderResponseDto
    {
        public OrderResponseDto()
        {
            Orders = [];
        }

        public List<OrdersDto> Orders { get; set; } = [];
    }

    public class OrdersDto
    {
        public Guid Uuid { get; set; }
        public List<OrderProductDto>? Products { get; set; } = [];
        public decimal TotalPrice { get; set; }
    }

}
