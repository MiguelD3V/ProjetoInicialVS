using AutoMapper;
using ProjetoIniciaVs.API.Dtos.Responses;
using ProjetoIniciaVs.API.Models;

namespace ProjetoIniciaVs.API.Mappers
{
    public class PacienteMapper : Profile
    {
        public PacienteMapper()
        {
            CreateMap<Paciente, PacienteResponseDto>();
        }
    }
}
