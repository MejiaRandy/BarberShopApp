using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Controllers
{
        public class CustomerController : Controller
        {
                public IActionResult Index() {
                        return View();
                }
        }
}
