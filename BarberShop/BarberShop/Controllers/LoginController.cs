using BarberShop.Dtos.LoginUser;
using BarberShop.Enums;
using BarberShop.ViewModels.UserLogin;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Umbraco.Core.Services;

namespace BarberShop.Controllers
{
        public class LoginController : Controller
        {
               

                public IActionResult Index() {
                        return View(new LoginViewModel());
                }
                [HttpPost]
                public async Task<IActionResult> Index( LoginViewModel vm ) {
                        var controller = "Home";
                        return RedirectToAction("Index", controller);
                }
        }
}
