using AutoMapper;
using PizzaStore.Application.DTOs;
using PizzaStore.Application.Interfaces;
using PizzaStore.Domain.Entities;
using PizzaStore.Domain.Interfaces;

namespace PizzaStore.Application.Services;
public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Order>> GetAvailableOrdersAsync()
    {
        return await _orderRepository.GetAllAsync();
    }

    public async Task<OrderDTO?> GetOrderByIdAsync(int? id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        return _mapper.Map<OrderDTO?>(order);
    }

    public async Task<Order> CreateOrderAsync(List<OrderItem> orderItems)
    {
        // Create a new Order
        var newOrder = new Order(DateTime.UtcNow, orderItems);

        // Add the order to the repository
        var result = await _orderRepository.AddAsync(newOrder);

        return result;
    }

    public async Task UpdateOrderAsync(OrderDTO orderDTO)
    {
        var order = _mapper.Map<Order>(orderDTO);
        order.OrderItems = orderDTO.OrderItems;
        await _orderRepository.UpdateAsync(order);
    }

    public async Task<Order> DeleteOrderAsync(Order order)
    {
        return await _orderRepository.DeleteAsync(order);
    }
}

