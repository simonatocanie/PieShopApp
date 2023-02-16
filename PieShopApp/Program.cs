using Microsoft.EntityFrameworkCore;
using PieShopApp.Models.Context;
using PieShopApp.Models.Repositories.Repositories;
using PieShopApp.Models.SeedData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>(sp => ShoppingCartRepository.GetShoopingCart(sp));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PieShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:PieShopConnectionString"]);
});


var app = builder.Build();
app.UseStaticFiles();
app.UseSession();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute(); //{controller=Home}/{action=Index}/{id?}}

DbInitializer.Seed(app);
app.Run();
