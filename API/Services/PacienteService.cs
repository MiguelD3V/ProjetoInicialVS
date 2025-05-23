using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ProjetoIniciaVs.API.Dtos.Responses;
using ProjetoIniciaVs.API.Interfaces;
using ProjetoIniciaVs.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ProjetoIniciaVs.API.Services
{
    public class PacienteService : IPacienteService
    {

        public static List<Paciente> _pacientes = new List<Paciente>();

        public Task <PacienteResponseDto> Inserir(Paciente paciente)
        {
            var response = new PacienteResponseDto();

            if (paciente.Nome.Length < 3)
            {
                response.AddMessage("Nome do Paciente é muito curto");
            }
            if (paciente.Idade <= 0 || paciente.Idade > 120)
            {
                response.AddMessage("A idade digitada invalida");
            }
            if (!Regex.IsMatch(paciente.Numero.ToString(), @"^\d+$"))
            {
                response.AddMessage("Valor digitado é inválido, digite apenas números:");
            }
            if (!Regex.IsMatch(paciente.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                response.AddMessage("Digite um email válido:");
            }

            if (response.Sucesso)
            {
                paciente.Id = _pacientes.Count + 1;
                _pacientes.Add(paciente);
                response.Paciente = paciente;
            }
            return Task.FromResult(response);
        }

        public Task<PacienteResponseDto> Deletar(int id)
        {
            var response = new PacienteResponseDto();

            var indx = _pacientes.FindIndex(p => p.Id == id);

            if (indx == -1)
            {
                response.AddMessage("Id Inválido");
            }
            else
            {
                _pacientes.RemoveAt(indx);
                response.AddMessage("Paciente deletado com sucesso");
            }

            return Task.FromResult(response);
        }

        public Task<PacienteResponseDto> Atualizar(Paciente paciente)
        {
            var response = new PacienteResponseDto();

            var indx = _pacientes.FindIndex(p => p.Id == paciente.Id);

            if (indx == -1)
            {
                response.AddMessage("paciente não encontrado");
            }

            if (paciente.Nome.Length < 3)
            {
                response.AddMessage("Nome do Paciente é muito curto");
            }
            if (paciente.Idade <= 0 || paciente.Idade > 120)
            {
                response.AddMessage("A idade digitada invalida");
            }
            if (!Regex.IsMatch(paciente.Numero.ToString(), @"^\d+$"))
            {
                response.AddMessage("Valor digitado é inválido, digite apenas números:");
            }
            if (!Regex.IsMatch(paciente.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                response.AddMessage("Digite um email válido:");
            }

            if (response.Sucesso)
            {
                _pacientes[indx] = paciente;
                response.Paciente = paciente;
            }

            return Task.FromResult(response);
        }

        public Task<Paciente> Consultar(int id)
        {
            var paciente = _pacientes.Find(p => p.Id == id);
            return Task.FromResult(paciente);
        }

        public Task<List<Paciente>> ListarTodos()
        {
            return Task.FromResult(_pacientes);
        }
    }
}
