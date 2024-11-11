using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShop.Db.Storage;
using OnlineShopWebApp.BackgroundServices;
using OnlineShopWebApp.ReviewsApi;
using Serilog;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .Enrich.FromLogContext()
    .Enrich.WithProperty("ApplicationName", "OnlineShop"));
var connection = builder.Configuration.GetConnectionString("online_shop");

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connection));
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>();
// настройка cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
    options.LoginPath = "/Authorization/Login";
    options.LogoutPath = "/Authorization/Logout";
    options.Cookie = new CookieBuilder()
    {
        IsEssential = true
    };
});
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("ReviewsApi", httpClient => httpClient.BaseAddress = new Uri("https://localhost:7274/"));
builder.Services.AddTransient<IProductsStorage, ProductsDbStorage>();
builder.Services.AddTransient<ICartsStorage, CartsDbStorage>();
builder.Services.AddTransient<IOrdersStorage, OrdersDbStorage>();
builder.Services.AddTransient<IFavoritesStorage, FavoritesDbStorage>();
builder.Services.AddTransient<ReviewApiClient>();
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
builder.Services.AddHostedService<OrderStatusTracking>();


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

app.UseAuthentication();
app.UseAuthorization();

app.UseRequestLocalization();

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<User>>();
    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await IdentityInitialiser.InitialiserAsync(userManager, rolesManager);
    var reviewApiClient = services.GetRequiredService<ReviewApiClient>();
    await reviewApiClient.InitializerAsync();
}

app.Run();
