using PizzaStore.Domain.Entities;

namespace PizzaStore.Domain.Interfaces;
public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int? id);
    Task<Order> AddAsync(Order order);
    Task<Order> DeleteAsync(Order order);
    Task<Order> UpdateAsync(Order order);
}
