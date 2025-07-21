using ActividadDeportiva.Application.Contract;
using ActividadDeportiva.Application.Service;
using ActividadDeportiva.Infrastructure.Context;
using ActividadDeportiva.Infrastructure.Interfaces;
using ActividadDeportiva.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ActividadDeportiva.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ActividadDeportivaContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IUsuarioDeportivoRepository, UsuarioDeportivoRepository>();
            builder.Services.AddScoped<IUsuarioDeportivoService, UsuarioDeportivoService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
