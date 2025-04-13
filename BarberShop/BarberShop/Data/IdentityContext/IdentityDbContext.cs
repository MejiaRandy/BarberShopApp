using System;
using BarberShop.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Data.IdentityContext;

public class IdentityDbContext : IdentityDbContext<AppUser>
{
  public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.HasDefaultSchema("Identity");

    modelBuilder.Entity<AppUser>(entity => entity.ToTable(name: "Users"));
    modelBuilder.Entity<IdentityRole>(entity => entity.ToTable(name: "Roles"));
    modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.ToTable(name: "UserRoles"));
    modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.ToTable(name: "UserLogins"));
  }
}