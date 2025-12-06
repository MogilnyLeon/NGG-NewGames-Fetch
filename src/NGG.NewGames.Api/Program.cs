using Microsoft.EntityFrameworkCore;
using NGG.NewGames.Api.DataAccess;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NGG_NewGamesDbContext>(options =>
{
    options.UseInMemoryDatabase("NGG-NewGames");
});
var app = builder.Build();

app.EnsureDbIsCreated();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

try{ app.MapControllers(); }
catch (ReflectionTypeLoadException ex)
{
    foreach (var e in ex.LoaderExceptions)
    {
        Console.WriteLine(e.Message);
    }
}

app.Run();
