
using Logistics.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Logistics.Domain.Repositories;
using Logistics.Infrastructure.Repositories;
using Logistics.Application.Factories;
using Logistics.Infrastructure.Payments;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add Entity Framework
builder.Services.AddDbContext<LogisticsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add repositories
builder.Services.AddScoped<IPackageRepository, PackageRepository>();

// Add factories
builder.Services.AddScoped<IShipmentFactory, ShipmentFactory>();

// Add payment services
builder.Services.AddScoped<ICardValidator, CardValidator>();
builder.Services.AddScoped<IFraudService, FraudService>();
builder.Services.AddScoped<IStripePaymentGateway, StripePaymentGateway>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();

// Add payment facade
builder.Services.AddScoped<IPaymentFacade, PaymentFacade>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

