using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Entities;
using PizzaStore.Domain.Interfaces;
using PizzaStore.Persistence.Context;

namespace PizzaStore.Persistence.Repositories;
public class PizzaRepository : IPizzaRepository
{
    private readonly ApplicationDbContext _context;

    public PizzaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pizza>> GetAllAsync()
    {
        return await _context.Pizzas.ToListAsync();
    }

    public async Task<Pizza?> GetByIdAsync(int? id)
    {
        return await _context.Pizzas.FindAsync(id) ?? null;
    }

    public async Task<Pizza> AddPizza(Pizza pizza)
    {
        _context.Pizzas.Add(pizza);
        await _context.SaveChangesAsync();
        return pizza;
    }

    public async Task<Pizza> UpdatePizza(Pizza pizza)
    {
        _context.Pizzas.Update(pizza);
        await _context.SaveChangesAsync();
        return pizza;
    }

    public async Task<Pizza> DeletePizza(Pizza pizza)
    {
        _context.Pizzas.Remove(pizza);
        await _context.SaveChangesAsync();
        return pizza;
    }
}
