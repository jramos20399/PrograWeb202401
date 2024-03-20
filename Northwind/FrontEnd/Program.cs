using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x => x.LoginPath="/account/login");

builder.Services.AddHttpClient<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<ICategoryHelper, CategoryHelper>();
builder.Services.AddScoped<ISupplierHelper, SupplierHelper>();
builder.Services.AddScoped<IProductHelper, ProductHelper>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
