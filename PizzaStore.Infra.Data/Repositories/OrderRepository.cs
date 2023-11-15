using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Entities;
using PizzaStore.Domain.Interfaces;
using PizzaStore.Persistence.Context;

namespace PizzaStore.Persistence.Repositories;
public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(int? id)
    {
        var order = await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(p => p.Pizza)
                .FirstOrDefaultAsync(m => m.Id == id);

        return order ?? null;
    }

    public async Task<Order> AddAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<Order> UpdateAsync(Order order)
    {
        // Include OrderItems and Pizzas in the order object
        var updatedOrder = await _context.Orders
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Pizza)
            .FirstOrDefaultAsync(m => m.Id == order.Id);

        if (updatedOrder == null)
        {
            // Handle the case where the order doesn't exist
            return null;
        }

        // Update the parent entity (Order)
        _context.Entry(updatedOrder).CurrentValues.SetValues(order);

        // Update quantities for pizzas in OrderItems
        foreach (var updatedOrderItem in updatedOrder.OrderItems)
        {
            var newOrderItem = order.OrderItems.FirstOrDefault(oi => oi.Id == updatedOrderItem.Id);
            if (newOrderItem != null)
            {
                _context.Entry(updatedOrderItem).CurrentValues.SetValues(newOrderItem);
                // You can add other properties here as needed.
            }
        }

        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<Order> DeleteAsync(Order order)
    {
        _context.Remove(order);
        await _context.SaveChangesAsync();
        return order;
    }
}
