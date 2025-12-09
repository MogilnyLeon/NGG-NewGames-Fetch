
using Microsoft.EntityFrameworkCore;
using NGG_GameFetch_V2.NewGames.Api.DataAccess;

namespace NGG_GameFetch_V2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.UseUrls("http://0.0.0.0:8080");
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<NGG_NewGamesDbContext>(options =>
            {
                options.UseInMemoryDatabase("NGG-NewGames");
            });

            builder.Services.AddCors(o => o.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            var app = builder.Build();

            app.EnsureDbIsCreated();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
