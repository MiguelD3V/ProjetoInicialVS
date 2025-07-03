using ProjetoIniciaVs.API.Interfaces;
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
            var logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<PacienteRepository>>();
            builder.Services.AddScoped<IPacienteRepository>(provider =>
            new PacienteRepository("Server=localhost; Database=HospitalDb;Integrated Security = true;Connect Timeout = 30;TrustServerCertificate=true;", logger));


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
