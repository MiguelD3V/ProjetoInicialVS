using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
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
            builder.Services.AddAutoMapper(cfg => { cfg.AddMaps(typeof(Program)); });

            builder.Services.AddScoped<IPacienteService, PacienteService>();
            builder.Services.AddScoped<IProntuarioService, ProntuarioService>();
            builder.Services.AddScoped<IProntuarioRepository, ProntuarioRepository>(provider =>
            {
                var mapper = provider.GetRequiredService<IMapper>();
                var logger = provider.GetRequiredService<ILogger<ProntuarioRepository>>();
                return new ProntuarioRepository("Server=localhost; Database=HospitalDb;Integrated Security = true;Connect Timeout = 30;TrustServerCertificate=true;", logger, mapper);
            });
            builder.Services.AddScoped<IPacienteRepository, PacienteRepository>(provider =>
            {
                var logger = provider.GetRequiredService<ILogger<PacienteRepository>>();
                return new PacienteRepository("Server=localhost; Database=HospitalDb;Integrated Security = true;Connect Timeout = 30;TrustServerCertificate=true;", logger);
            });

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
