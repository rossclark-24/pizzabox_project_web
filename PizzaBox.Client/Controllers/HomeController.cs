using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Storage;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Client.Controllers
{
  [Route("[controller]")]
  public class HomeController : Controller
  {
    private readonly UnitOfWork _unitOfWork;

    public HomeController(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult Index()
    {
      //return View("index");
      var order = new OrderViewModel();

      order.Load(_unitOfWork);

      return View("order", order);
    }
  }
}