using AutoMapper;
using ProjetoIniciaVs.API.Dtos.Requests;
using ProjetoIniciaVs.API.Dtos.Responses;
using ProjetoIniciaVs.API.Interfaces;
using ProjetoIniciaVs.API.Models;

namespace ProjetoIniciaVs.API.Services
{
    public class ProntuarioService : IProntuarioService
    {
        private readonly IProntuarioRepository _prontuarioRepository;
        private readonly IMapper _mapper;

        public ProntuarioService(IProntuarioRepository prontuarioRepository,IMapper mapper)
        {
            _prontuarioRepository = prontuarioRepository;
            _mapper = mapper;
        }

        public async Task<ProntuarioResponseDto> CreateAsync(ProntuarioRequestDto request)
        {
            var response = new ProntuarioResponseDto();
            if (!EhValido(request))
            {
                response.AddMessage("Dados inválidos para criação do prontuário.");
                return response;
            }

            var prontuario = _mapper.Map<Prontuario>(request);
            var ProntuarioCriado = await _prontuarioRepository.CreateAsync(prontuario);
            response = _mapper.Map<ProntuarioResponseDto>(ProntuarioCriado);
            response.AddMessage($"Prontuário criado com sucesso: id {ProntuarioCriado.Id}, descrição: {ProntuarioCriado.Descricao}, pacienteId {ProntuarioCriado.PacienteId}.");

            return response;
        }

        public async Task DeleteAsync(int id)
        {
            var response = new ProntuarioResponseDto();
            await _prontuarioRepository.DeleteAsync(id);
            response.AddMessage("Prontuário deletado com sucesso.");
        }


        public async Task<IEnumerable<ProntuarioResponseDto>> GetAllAsync()
        {
            var Lista = await _prontuarioRepository.GetAllAsync();
            var response = _mapper.Map<IEnumerable<ProntuarioResponseDto>>(Lista);

            return response;
        }

        public async Task<ProntuarioResponseDto> GetByIdAsync(int id)
        {
            var response = new ProntuarioResponseDto();
            var prontuario = await _prontuarioRepository.GetByIdAsync(id);
            if (prontuario == null)
            {
                response.AddMessage("Prontuário não encontrado.");
                return response;
            }
            response = _mapper.Map<ProntuarioResponseDto>(prontuario);
            return response;
        }

        public async Task<ProntuarioResponseDto> UpdateAsync(int id, ProntuarioRequestDto request)
        {
            var response = new ProntuarioResponseDto();
            if (!EhValido(request))
            {
                response.AddMessage("Dados inválidos para atualização do prontuário.");
                return response;
            }

            var prontuario = _mapper.Map<Prontuario>(request);
            var prontuarioAtualizado = await _prontuarioRepository.UpdateAsync(id, prontuario);
            response = _mapper.Map<ProntuarioResponseDto>(prontuarioAtualizado);
            response.AddMessage($"Prontuário atualizado com sucesso: id {response.Id}, descrição {response.Descricao}, pacienteId {response.PacienteId}.");
            
            return prontuarioAtualizado;
        }
        public bool EhValido(ProntuarioRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Descricao) || request.PacienteId <= 0)
            {
                return false;
            }
            if (request.Descricao.Length < 10)
            {
                return false;
            }
          if (request.Descricao.Length > 500)
            {
                return false;
            }
            return true;

        }
    }
}
