using AssetsManager.API.DataAccess;
using AssetsManager.API.Extensions;
using AssetsManager.API.Interfaces;
using AssetsManager.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("AssetsDbConnection");
builder.Services.AddDbContext<AssetsManagerDbContext>(builder => builder.UseSqlServer(connectionString));
builder.Services.AddScoped<IAssetsManager, AssetsManagerService>();
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
