using ProjetoIniciaVs.API.Dtos.Requests;
using ProjetoIniciaVs.API.Dtos.Responses;
using ProjetoIniciaVs.API.Models;

namespace ProjetoIniciaVs.API.Interfaces
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<PacienteResponseDto>> GetAllPacientesAsync();
        Task<PacienteResponseDto> GetPacienteByIdAsync(int id);
        Task<PacienteResponseDto> AddPacienteAsync(PacienteRequestDto paciente);
        Task UpdatePacienteAsync(PacienteResponseDto paciente);
        Task DeletePacienteAsync(int id);
    }
}
