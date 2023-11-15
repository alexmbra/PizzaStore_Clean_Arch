using PizzaStore.Domain.Entities;

namespace PizzaStore.Application.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderItem>? OrderItems { get; set; } 
}
