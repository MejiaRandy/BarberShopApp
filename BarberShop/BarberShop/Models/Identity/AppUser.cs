using System;
using Microsoft.AspNetCore.Identity;

namespace BarberShop.Models.Identity;

public class AppUser : IdentityUser
{
  public required string FirstName { get; set; }
  public required string LastName { get; set; }
  public string FullName => $"{FirstName} {LastName}";
}