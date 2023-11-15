namespace PizzaStore.Domain.Entities;
public class OrderItem
{
    public OrderItem()
    {
        
    }
    public OrderItem(Pizza pizza, int quantity)
    {
        Pizza = pizza;
        Quantity = quantity;
    }

    public OrderItem(int orderId, Pizza pizza, int quantity)
    {
        OrderId = orderId;
        Pizza = pizza;
        Quantity = quantity;
    }

    public int Id { get; set; }
    public int Quantity { get; set; }
    public Pizza? Pizza { get; set; }

    // Define the navigation property
    public int PizzaId { get; set; }

    public int OrderId { get; set; }
    public Order? Order { get; set; }
}
