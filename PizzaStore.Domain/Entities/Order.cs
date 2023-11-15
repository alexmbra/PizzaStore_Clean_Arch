using PizzaStore.Domain.Validation;

namespace PizzaStore.Domain.Entities;
public class Order
{
    public int Id { get; protected set; }
    public DateTime OrderDate { get; private set; }
    public List<OrderItem>? OrderItems { get; set; }

    public Order()
    {

    }

    public Order(DateTime orderDate, List<OrderItem> orderItems)
    {
        ValidateDomain(orderDate, orderItems);
    }

    public Order(int id, DateTime orderDate, List<OrderItem> orderItems)
    {
        Id = id;
        ValidateDomain(orderDate, orderItems);
    }

    private void ValidateDomain(DateTime orderDate, List<OrderItem> orderItems)
    {
        DomainExceptionValidation.When(orderItems.Count <= 0, "No order items added");

        OrderItems = new List<OrderItem>();
        OrderDate = orderDate;
    }

    public static Order Create(List<OrderItem> orderItems)
    {
        return new Order(DateTime.UtcNow, orderItems);
    }

    public void AddOrderItem(OrderItem orderItem)
    {
        OrderItems.Add(orderItem);
    }

    public void RemoveOrderItem(OrderItem orderItem)
    {
        OrderItems.Remove(orderItem);
    }
}
