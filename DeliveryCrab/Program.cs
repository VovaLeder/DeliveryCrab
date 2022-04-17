//Чтобы пояивлась бд нужно прописать в консоли диспетчера пакетов команды 
//для миграции
//Add-migration initial
//Update-database
// начальные данные
using Microsoft.EntityFrameworkCore;
using DeliveryCrab.Models;

var builder = WebApplication.CreateBuilder();
ConfigurationManager configuration = builder.Configuration;

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

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



