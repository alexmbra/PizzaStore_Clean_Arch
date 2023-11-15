using PizzaStore.Domain.Entities;

namespace PizzaStore.Domain.Interfaces;
public interface IPizzaRepository
{
    Task<Pizza?> GetByIdAsync(int? id);
    Task<IEnumerable<Pizza>> GetAllAsync();

    Task<Pizza> AddPizza(Pizza pizza);

    Task<Pizza> UpdatePizza(Pizza pizza);

    Task<Pizza> DeletePizza(Pizza pizza);
}
