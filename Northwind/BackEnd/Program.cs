using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NorthWindContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

    ) ;

#region DI
builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();
builder.Services.AddScoped<ICategoryDAL, CategoryDALImpl>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISupplierDAL, SupplierDALImpl>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

builder.Services.AddScoped<IProductDAL, ProductDALImpl>();
builder.Services.AddScoped<IProductService, ProductService>();

#endregion




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
