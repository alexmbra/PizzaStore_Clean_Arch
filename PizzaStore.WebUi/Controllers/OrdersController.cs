using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Application.DTOs;
using PizzaStore.Application.Interfaces;
using PizzaStore.Domain.Entities;
using PizzaStore.Persistence.Context;
using PizzaStore.WebUi.ViewModels;

namespace PizzaStore.WebUi.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPizzaService _pizzaService;
        private readonly IOrderService _orderService;

        public OrdersController(ApplicationDbContext context, IPizzaService pizzaService, IOrderService orderService)
        {
            _context = context;
            _pizzaService = pizzaService;
            _orderService = orderService;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return _context.Orders != null ?
                        View(await _context.Orders.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Orders'  is null.");
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(p => p.Pizza)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public async Task<IActionResult> CreateAsync()
        {
            var pizzaList = await _pizzaService.GetAvailablePizzasAsync();

            var viewModel = new CreateOrderViewModel
            {
                OrderItems = new List<OrderItemViewModel>(),
                PizzaList = pizzaList.Select(pizza => new SelectListItem
                {
                    Text = pizza.Name,
                    Value = pizza.Id.ToString()
                }).ToList()
            };

            return View(viewModel);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOrderViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Create an Order entity from the view model
                var order = new Order();
                foreach (var item in viewModel.OrderItems)
                {
                    var pizza = await _pizzaService.GetPizzaByIdAsync(item.PizzaId);
                    if (pizza != null)
                    {
                        var orderItem = new OrderItem(pizza, item.Quantity);
                        order.AddOrderItem(orderItem);
                    }
                }

                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }


        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OrderDTO orderDTO)
        {
            if (ModelState.IsValid)
            {
                await _orderService.UpdateOrderAsync(orderDTO);

                return RedirectToAction(nameof(Index));
            }

            return View(orderDTO);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Orders'  is null.");
            }
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
