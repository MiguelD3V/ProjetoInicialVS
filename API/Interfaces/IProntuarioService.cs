using ProjetoIniciaVs.API.Dtos.Requests;
using ProjetoIniciaVs.API.Dtos.Responses;

namespace ProjetoIniciaVs.API.Interfaces
{
    public interface IProntuarioService
    {
        public Task<ProntuarioResponseDto> CreateAsync(ProntuarioRequestDto request);
        public Task<ProntuarioResponseDto> GetByIdAsync(int id);
        public Task<IEnumerable<ProntuarioResponseDto>> GetAllAsync();
        public Task<ProntuarioResponseDto> UpdateAsync(int id, ProntuarioRequestDto request);
        public Task DeleteAsync(int id);
        public bool EhValido(ProntuarioRequestDto request);
    }
}
