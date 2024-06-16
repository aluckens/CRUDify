using CRUDy.Repository;
using CRUDyExample.Data;
using CRUDyExample.Repository;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyCrudDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped(typeof(ICrudyGenericRepository<,>), typeof(CrudyGenericRepositoryImpl<,>));
builder.Services.AddScoped<IProductRepository, ProductRepositoryImpl>();

var app = builder.Build();

app.MapGet("/",async (context ) => {
    var productRepository = context.RequestServices.GetRequiredService<IProductRepository>(); 
    var products = await productRepository.GetAllAsync(); 
    await context.Response.WriteAsJsonAsync(products);
});

app.Run();
