using ProjetoIniciaVs.API.Dtos.Requests;
using ProjetoIniciaVs.API.Dtos.Responses;
using ProjetoIniciaVs.API.Models;

namespace ProjetoIniciaVs.API.Interfaces
{
    public interface IProntuarioRepository
    {
        public Task<ProntuarioResponseDto> CreateAsync(Prontuario prontuario);
        public Task<ProntuarioResponseDto> GetByIdAsync(int id);
        public Task<IEnumerable<ProntuarioResponseDto>> GetAllAsync();
        public Task<ProntuarioResponseDto> UpdateAsync(int id, Prontuario prontuario);
        public Task DeleteAsync(int id);
    }
}
