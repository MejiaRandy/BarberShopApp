using BarberShop.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Controllers
{
        public class LoginController : Controller
        {
                public IActionResult Index() {
                        return View();
                }
        }
}
