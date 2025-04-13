using System;
using BarberShop.Enums;
using BarberShop.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace BarberShop.Seeds;

public static class DefaultUsersSeed
{
  public static async Task SeedAsync(UserManager<AppUser> userManager)
  {
    var users = new List<(string Role, string UserName, string FirstName, string LastName, string Email, string Phone, string Password)>
    {
      (UserRoles.Admin.ToString(), "adminuser", "admin", "user", "adminuser@gmail.com", "1234310099", "Defaultuser1!"),
      (UserRoles.Barber.ToString(), "barberuser", "barber", "user", "barberuser@gmail.com", "1234310088", "Defaultbarber1!"),
      (UserRoles.Customer.ToString(), "customeruser", "customer", "user", "customeruser@gmail.com", "1234310077", "Defaultcustomer1!")
    };

    foreach (var (role, userName, firstName, lastName, email, phone, password) in users)
    {
      if (await userManager.FindByNameAsync(userName) is null)
      {
        var newUser = new AppUser
        {
          FirstName = firstName,
          LastName = lastName,
          UserName = userName,
          Email = email,
          EmailConfirmed = true,
          PhoneNumber = phone,
          PhoneNumberConfirmed = true
        };

        var result = await userManager.CreateAsync(newUser, password);
        if(result.Succeeded){
            await userManager.AddToRoleAsync(newUser, role);
        }
      }
    }
  }
}
