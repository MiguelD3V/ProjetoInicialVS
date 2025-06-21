using ProjetoIniciaVs.API.Dtos.Responses;
using ProjetoIniciaVs.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIniciaVs.API.Interfaces
{
    public interface IPacienteService
    {
        public Task<PacienteResponseDto> Inserir(Paciente paciente);
         public Task<PacienteResponseDto> Deletar(int id);
         public Task<PacienteResponseDto> Atualizar(Paciente paciente, int id);
         public Task<PacienteResponseDto> Consultar(int id);
        public Task<IEnumerable<PacienteResponseDto>> ListarTodos();

    }
}
