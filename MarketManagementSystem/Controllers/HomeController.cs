using Microsoft.AspNetCore.Mvc;

namespace MarketManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}