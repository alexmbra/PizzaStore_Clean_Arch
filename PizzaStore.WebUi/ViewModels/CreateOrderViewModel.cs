using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaStore.Domain.Entities;

namespace PizzaStore.WebUi.ViewModels;

public class CreateOrderViewModel
{
    [Required(ErrorMessage = "Order date is required.")]
    [Display(Name = "Order Date")]
    public DateTime OrderDate { get; set; }

    [Required(ErrorMessage = "Please select a pizza.")]
    [Display(Name = "Pizza")]
    public int SelectedPizzaId { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
    public int NewPizzaQuantity { get; set; }

    public List<SelectListItem> PizzaList { get; set; } // List of pizzas for the dropdown

    public List<OrderItemViewModel> OrderItems { get; set; } // List to hold selected pizzas and quantities
}
