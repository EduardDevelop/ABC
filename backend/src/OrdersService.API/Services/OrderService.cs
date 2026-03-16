using OrdersService.Api.Models;

namespace OrdersService.Api.Services;

public class OrderService : IOrderService
{
    public IEnumerable<OrderDto> GetOrders()
    {
        return new List<OrderDto>
        {
            new OrderDto
            {
                Id = 1,
                OrderNumber = "ORD-1001",
                CustomerName = "John Doe",
                TotalAmount = 250.50m,
                Status = "Completed"
            },
            new OrderDto
            {
                Id = 2,
                OrderNumber = "ORD-1002",
                CustomerName = "Jane Smith",
                TotalAmount = 99.99m,
                Status = "Pending"
            }
        };
    }
}