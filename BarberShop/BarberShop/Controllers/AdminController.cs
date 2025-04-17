using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Controllers
{
        
        public class AdminController : Controller
        {
                public IActionResult Index() {
                        return View();
                }
        }
}
