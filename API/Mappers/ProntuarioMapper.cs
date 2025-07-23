using AutoMapper;
using ProjetoIniciaVs.API.Dtos.Requests;
using ProjetoIniciaVs.API.Dtos.Responses;
using ProjetoIniciaVs.API.Interfaces;
using ProjetoIniciaVs.API.Models;

namespace ProjetoIniciaVs.API.Mappers
{
    public class ProntuarioMapper : Profile
    {
        public ProntuarioMapper()
        {
            CreateMap<ProntuarioResponseDto, ProntuarioRequestDto>();
            CreateMap<ProntuarioRequestDto, ProntuarioResponseDto>();
            CreateMap<Prontuario, ProntuarioResponseDto>();
            CreateMap<ProntuarioResponseDto, Prontuario>();
            CreateMap<ProntuarioRequestDto, Prontuario>();
            CreateMap<Prontuario, ProntuarioRequestDto>();
        }
    }
}
