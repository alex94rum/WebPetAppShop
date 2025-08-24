using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Globalization;
using WebPetAppShop.Data;
using WebPetAppShop.Models;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("online_shop");

// добавляем контекст DatabaseContext в качестве сервиса в приложение
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));

// добавляем контекст IndentityContext в качестве сервиса в приложение
builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connection));

// указываем тип пользователя и роли
builder.Services.AddIdentity<User, IdentityRole>()
                // устанавливаем тип хранилища - наш контекст
                .AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddTransient<IProductRepos, ProductDbRepos>();
builder.Services.AddTransient<ICartRepos, CartDbRepos>();
builder.Services.AddTransient<IFavoriteRepos, FavoriteDbRepos>();
builder.Services.AddTransient<IOrderRepos, OrderDbRepos>();
builder.Services.AddSingleton<IRolesRepos, RolesInMamoryRepos>();
builder.Services.AddSingleton<IUsersManager, UsersManagerInMamory>();

// сервис локализации
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

// создание логгера
builder.Host.UseSerilog((context, configuration) => configuration
            .ReadFrom.Configuration(context.Configuration)
            .Enrich.WithProperty("ApplicationName", "WebPetAppShop"));

var app = builder.Build();

app.UseRequestLocalization(); // подключение локализации
app.UseSerilogRequestLogging(); // подключение логгера
app.UseAuthentication(); // подключение аутентификации
app.UseAuthorization(); // подключение авторизации

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{guid?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{guid?}");

app.Run();
