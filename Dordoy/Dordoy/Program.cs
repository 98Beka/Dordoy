using AutoMapper;
using BLL.Services;
using Dordoy.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionStr = builder.Configuration["ConnectionStrings:DefaultConnection"];

builder.Services.AddSingleton<ProductService, ProductService>(
    s => new ProductService(connectionStr));

builder.Services.AddSingleton<OwnerService, OwnerService>(
    s => new OwnerService(connectionStr));

builder.Services.AddSingleton<SaleService, SaleService>(
    s => new SaleService(connectionStr));

builder.Services.AddSingleton<WarehouseService, WarehouseService>(
    s => new WarehouseService(connectionStr));

builder.Services.AddSingleton<IMapper, IMapper>(
    s => new MapperConfiguration(c => {
        c.AddProfile<MapperConfig>();
    }).CreateMapper()
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
