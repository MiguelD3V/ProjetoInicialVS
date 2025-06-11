using ProjetoIniciaVs.API.Dtos.Responses;
using ProjetoIniciaVs.API.Models;

namespace ProjetoIniciaVs.API.Interfaces
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<PacienteResponseDto>> GetAllPacientesAsync();
        Task<PacienteResponseDto> GetPacienteByIdAsync(int id);
        Task AddPacienteAsync(Paciente paciente);
        Task UpdatePacienteAsync(Paciente paciente);
        Task DeletePacienteAsync(int id);
    }
}
