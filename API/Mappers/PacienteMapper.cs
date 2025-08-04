using AutoMapper;
using ProjetoIniciaVs.API.Dtos.Requests;
using ProjetoIniciaVs.API.Dtos.Responses;
using ProjetoIniciaVs.API.Models;

namespace ProjetoIniciaVs.API.Mappers
{
    public class PacienteMapper : Profile
    {
        public PacienteMapper()
        {
            CreateMap<Paciente, PacienteResponseDto>();
            CreateMap<PacienteResponseDto, Paciente>();
            CreateMap<Paciente, PacienteRequestDto>();
            CreateMap<PacienteRequestDto, PacienteResponseDto>();
            CreateMap<PacienteRequestDto, Paciente>();
            CreateMap<PacienteResponseDto, PacienteRequestDto>();

        }
    }
}
