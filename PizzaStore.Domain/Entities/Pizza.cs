using PizzaStore.Domain.Validation;

namespace PizzaStore.Domain.Entities;
public class Pizza
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public Pizza(int id, string? name, decimal price)
    {
        Id = id;
        ValidateDomain(name, price);
    }

    public Pizza(string? name, decimal price)
    {
        ValidateDomain(name, price);
    }

    private void ValidateDomain(string? name, decimal price)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
        DomainExceptionValidation.When(name?.Length < 3, "Invalid name. Too short");
        DomainExceptionValidation.When(price < 0, "Invalid price value");

        Name = name ?? string.Empty;
        Price = price;
    }

    // Define the navigation property
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
