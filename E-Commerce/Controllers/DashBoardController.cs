using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult __Layout()
        {
            return View();
        }
    }
}
