using BarberShop.Data;
using BarberShop.Data.IdentityContext;
using BarberShop.Models;
using BarberShop.Models.Identity;
using BarberShop.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stripe;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;

var builder = WebApplication.CreateBuilder(args);




// Configuro la cadena de conexion
builder.Services.AddDbContext<IdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

// Agrego identity
builder.Services.AddIdentity<AppUser, IdentityRole>()
        .AddEntityFrameworkStores<IdentityDbContext>()
        .AddDefaultTokenProviders();

//Redirige al loging si no estan autenticados
builder.Services.ConfigureApplicationCookie(options => {
        options.LoginPath = "/Login/Index";
});



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Ruta por defecto
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();

    // Aca ejecuto los seeds
    await DefaultRolesSeed.SeedsAsync(roleManager);
    await DefaultUsersSeed.SeedAsync(userManager);
}


app.Run();
