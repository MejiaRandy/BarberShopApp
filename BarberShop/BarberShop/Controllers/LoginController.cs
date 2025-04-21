using BarberShop.Data.IdentityContext;
using BarberShop.Dtos.LoginUser;
using BarberShop.Enums;
using BarberShop.Models.Identity;
using BarberShop.ViewModels.UserLogin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Umbraco.Core.Services;

namespace BarberShop.Controllers
{
        public class LoginController : Controller
        {
                private readonly IdentityDbContext _context;
                private readonly SignInManager<AppUser> _signInManager;
                private readonly UserManager<AppUser> _userManager;

                public LoginController(
                    IdentityDbContext context,
                    SignInManager<AppUser> signInManager,
                    UserManager<AppUser> userManager ) {
                        _context = context;
                        _signInManager = signInManager;
                        _userManager = userManager;
                }


                public IActionResult Index() {
                        return View(new LoginViewModel());
                }

                [HttpPost]
                public async Task<IActionResult> Index( LoginViewModel vm ) {
                        var controller = "Home";
                        try
                        {
                                var query = await _context.Users.Where(x => x.UserName == vm.Username).FirstOrDefaultAsync();

                                if (query == null)
                                {
                                        
                                        return View(vm);
                                }

                                var user = await _userManager.FindByNameAsync(vm.Username);
                                if (user == null)
                                {
                                        // El usuario no existe
                                        return View(vm);
                                }

                                var isPasswordValid = await _userManager.CheckPasswordAsync(user, vm.Password);
                                if (!isPasswordValid)
                                {
                                        // La contraseña es incorrecta
                                        return View(vm);
                                }


                                var findRoleUser = await _context.UserRoles.FirstOrDefaultAsync(x => x.UserId == query.Id);

                                if (findRoleUser == null)
                                {
                                        return View(vm);
                                }

                                switch (findRoleUser.RoleId)
                                {
                                        case "028465e5-9eb1-4f2a-bc63-0a18659fdb6c":
                                                controller = "Customer";
                                                break;
                                        case "17e166a9-f273-4dbd-8c07-c03be1721336":
                                                controller = "Barber";
                                                break;
                                        case "9304c8b1-4587-47d8-bb89-94324f3fdfa0":
                                                controller = "Admin";
                                                break;

                                }
                                return RedirectToAction("Index", controller);


                        } catch (Exception ex)
                        {
                                // Log the exception
                                // Redirect to an error page or show a message
                                return View("Error");
                        }


                }

                public IActionResult Register() {
                        return View(new RegisterUserViewModels());
                }
                [HttpPost]
                public async Task<IActionResult> Register( RegisterUserViewModels vm ) {
                        
                        vm.Role = UserRoles.Customer;
                        
                        if (!ModelState.IsValid)
                                return View(vm);

                        // 1. Verificar que Password y ConfirmPassword coincidan
                        if (vm.Password != vm.ConfirmPassword)
                        {
                                ModelState.AddModelError(nameof(vm.ConfirmPassword), "Las contraseñas no coinciden.");
                                return View(vm);
                        }

                        // 2. Crear la entidad AppUser
                        var user = new AppUser {
                                UserName = vm.UserName!,
                                Email = vm.Email!,
                                PhoneNumber = vm.PhoneNumber!,
                                FirstName = vm.FirstName == "" ? "No name" : vm.FirstName,
                                LastName = vm.LastName
                                
                        };

                        // 3. Crear el usuario con contraseña
                        var createResult = await _userManager.CreateAsync(user, vm.Password!);
                        if (!createResult.Succeeded)
                        {
                                foreach (var err in createResult.Errors)
                                        ModelState.AddModelError(string.Empty, err.Description);
                                return View(vm);
                        }

                        // 4. Asignar el rol seleccionado
                        await _userManager.AddToRoleAsync(user, vm.Role.ToString());

                        // 5. (Opcional) Iniciar sesión automático
                        // await _signInManager.SignInAsync(user, isPersistent: false);

                        // 6. Redirigir al login o al dashboard según prefieras
                        return RedirectToAction("Index", "Login");
                }

        }
}

