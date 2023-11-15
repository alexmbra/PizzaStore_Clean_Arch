using PizzaStore.Application.Interfaces;
using PizzaStore.Domain.Entities;
using PizzaStore.Domain.Interfaces;

namespace PizzaStore.Application.Services;
public class PizzaService : IPizzaService
{
    private readonly IPizzaRepository _repository;

    public PizzaService(IPizzaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Pizza> CreatePizzaAsync(string name, decimal price)
    {
        var newPizza = new Pizza(name, price);

        return await _repository.AddPizza(newPizza);
    }

    public async Task<IEnumerable<Pizza>> GetAvailablePizzasAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Pizza?> GetPizzaByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
}
