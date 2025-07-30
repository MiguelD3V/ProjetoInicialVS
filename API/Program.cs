using ProjetoIniciaVs.API.Interfaces;
using ProjetoIniciaVs.API.Mappers;
using ProjetoIniciaVs.API.Repositories;
using ProjetoIniciaVs.API.Services;

namespace ProjetoIniciaVs.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IPacienteService, PacienteService>();

            builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();

            builder.Services.AddAutoMapper(cfg => { cfg.AddMaps(typeof(Program)); });

            var app = builder.Build();
           
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
        }
    }
}