//для миграции
//Add-migration initial
//Update-database
using Microsoft.EntityFrameworkCore;
using DeliveryCrab.Models;
using DeliveryCrab.DB;

var builder = WebApplication.CreateBuilder();
ConfigurationManager configuration = builder.Configuration;

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<UserContext>(options => options.UseNpgsql(Connection.GetConnectionString()));
builder.Services.AddDbContext<ProductContext>(options => options.UseNpgsql(Connection.GetConnectionString()));
builder.Services.AddDbContext<RestaurantContext>(options => options.UseNpgsql(Connection.GetConnectionString()));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    
}
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
app.Run();



