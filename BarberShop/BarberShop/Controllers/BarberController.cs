using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Controllers
{
        public class BarberController : Controller
        {
                public IActionResult Index() {
                        return View();
                }
        }
}
