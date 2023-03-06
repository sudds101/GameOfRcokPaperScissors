using Microsoft.AspNetCore.Mvc;

namespace GameOfRcokPaperScissors.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
