using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineShop.Db;
using Serilog;
using System.Globalization;
using WebApplicationOnlineStore;
using WebApplicationOnlineStore.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration)
                                                                 .Enrich.FromLogContext()
                                                                 .Enrich.WithProperty("ApplicationName", "OnlineShop#1"));
// Add services to the container.

// Получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("online_shop");

// Добавляем контекст DatabaseContext в качестве сервиса в приложение
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));

builder.Services.AddSingleton<IUsers, Constants>();

builder.Services.AddSingleton<ICarts, CartsRepository>();

builder.Services.AddSingleton<IRoles, RolesRepository>();

builder.Services.AddSingleton<IOrders, OrdersRepository>();

builder.Services.AddSingleton<IUserManager, UserManager>();

builder.Services.AddTransient<IProducts, ProductsDbRepository>();

builder.Services.AddControllersWithViews();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US")
    };
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseRequestLocalization();

app.MapControllerRoute(
    name: "Admin_area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
