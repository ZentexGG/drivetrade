using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using DataLayer.ContextInterface;
using DataLayer.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IBrandService, BrandService>();
// builder.Services.AddScoped<ICategoryService, CategoryService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DriveTradeDb");
var frontendUrl = builder.Configuration.GetConnectionString("FrontendURL");


builder.Services.AddDbContext<DriveTradeContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IDbContext>(provider => provider.GetService<DriveTradeContext>());

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        if (frontendUrl != null)
            builder.WithOrigins(frontendUrl)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}


app.UseAuthorization();

app.MapControllers();

app.Run();

