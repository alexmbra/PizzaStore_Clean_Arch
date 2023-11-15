using PizzaStore.Application.DTOs;
using PizzaStore.Domain.Entities;

namespace PizzaStore.Application.Interfaces;
public interface IOrderService
{
    Task<Order> CreateOrderAsync(List<OrderItem> orderItems);
    Task<Order> DeleteOrderAsync(Order order);
    Task<IEnumerable<Order>> GetAvailableOrdersAsync();

    Task<OrderDTO?> GetOrderByIdAsync(int? id);
    Task UpdateOrderAsync(OrderDTO order);
}