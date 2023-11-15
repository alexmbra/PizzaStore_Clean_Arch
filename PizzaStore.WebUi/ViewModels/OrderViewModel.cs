using PizzaStore.Domain.Entities;

namespace PizzaStore.WebUi.ViewModels;

public class OrderViewModel
{
    public int Id { get; protected set; }
    public DateTime OrderDate { get; private set; }
    public List<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();
}
