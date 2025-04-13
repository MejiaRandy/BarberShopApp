using BarberShop.Enums;
using Microsoft.AspNetCore.Identity;

namespace BarberShop.Seeds;

public class DefaultRolesSeed
{
  public static async Task SeedsAsync(RoleManager<IdentityRole> roleManager)
  {
    if (!await roleManager.RoleExistsAsync(UserRoles.Admin.ToString()))
      await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin.ToString()));

    if (!await roleManager.RoleExistsAsync(UserRoles.Barber.ToString()))
      await roleManager.CreateAsync(new IdentityRole(UserRoles.Barber.ToString()));

    if (!await roleManager.RoleExistsAsync(UserRoles.Customer.ToString()))
      await roleManager.CreateAsync(new IdentityRole(UserRoles.Customer.ToString()));
  }
}
