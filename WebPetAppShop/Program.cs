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

// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("online_shop");

// ��������� �������� DatabaseContext � �������� ������� � ����������
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));

// ��������� �������� IndentityContext � �������� ������� � ����������
builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connection));

// ��������� ��� ������������ � ����
builder.Services.AddIdentity<User, IdentityRole>()
                // ������������� ��� ��������� - ��� ��������
                .AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddTransient<IProductRepos, ProductDbRepos>();
builder.Services.AddTransient<ICartRepos, CartDbRepos>();
builder.Services.AddTransient<IFavoriteRepos, FavoriteDbRepos>();
builder.Services.AddTransient<IOrderRepos, OrderDbRepos>();
builder.Services.AddSingleton<IRolesRepos, RolesInMamoryRepos>();
builder.Services.AddSingleton<IUsersManager, UsersManagerInMamory>();

// ������ �����������
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

// �������� �������
builder.Host.UseSerilog((context, configuration) => configuration
            .ReadFrom.Configuration(context.Configuration)
            .Enrich.WithProperty("ApplicationName", "WebPetAppShop"));

var app = builder.Build();

app.UseRequestLocalization(); // ����������� �����������
app.UseSerilogRequestLogging(); // ����������� �������
app.UseAuthentication(); // ����������� ��������������
app.UseAuthorization(); // ����������� �����������

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
