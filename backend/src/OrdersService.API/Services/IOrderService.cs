using OrdersService.Api.Models;

namespace OrdersService.Api.Services;

public interface IOrderService
{
    IEnumerable<OrderDto> GetOrders();
}