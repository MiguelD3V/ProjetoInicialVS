using ProjetoIniciaVs.API.Dtos.Requests;
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
        public Task<PacienteResponseDto> Inserir(PacienteRequestDto paciente);
         public Task<PacienteResponseDto> Deletar(int id);
        public Task<PacienteResponseDto> Atualizar(PacienteRequestDto paciente, int id);
        public Task<PacienteResponseDto> Consultar(int id);
        public Task<IEnumerable<PacienteResponseDto>> ListarTodos();

    }
}
