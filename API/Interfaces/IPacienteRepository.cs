using ProjetoIniciaVs.API.Dtos.Requests;
using ProjetoIniciaVs.API.Dtos.Responses;
using ProjetoIniciaVs.API.Models;

namespace ProjetoIniciaVs.API.Interfaces
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> GetAllPacientesAsync();
        Task<Paciente> GetPacienteByIdAsync(int id);
        Task<Paciente> AddPacienteAsync(PacienteRequestDto paciente);
        Task<Paciente> UpdatePacienteAsync(PacienteRequestDto paciente, int id);
        Task DeletePacienteAsync(int id);
    }
}
