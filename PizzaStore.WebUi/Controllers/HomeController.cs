using Microsoft.AspNetCore.Mvc;

namespace PizzaStore.WebUi.Controllers;
public class HomeController : Controller
{

    public HomeController()
    {
    }

    public IActionResult Index()
    {
        return View();
    }



}
