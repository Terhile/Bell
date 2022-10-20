using Invoices.API.DataAccess;
using Invoices.API.Extensions;
using Invoices.API.HttpClients;
using Invoices.API.Interfaces;
using Invoices.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<AssetsManagerServiceClient>();
var connectionString = builder.Configuration.GetConnectionString("DefaultDbConnection");
builder.Services.AddDbContext<InvoiceDbContext>(builder => builder.UseSqlServer(connectionString));
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();
app.ApplyMigrations();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
