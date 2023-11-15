using PizzaStore.Domain.Entities;

namespace PizzaStore.Application.Interfaces;
public interface IPizzaService
{
    Task<IEnumerable<Pizza>> GetAvailablePizzasAsync();
    Task<Pizza> CreatePizzaAsync(string name, decimal price);

    Task<Pizza?> GetPizzaByIdAsync(int id);
}
