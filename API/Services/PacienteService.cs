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

        public async Task <PacienteResponseDto> Inserir(Paciente paciente)
        {
            var response = new PacienteResponseDto();

            if(!EhValido(paciente))
            {
                response.AddMessage("Dados inválidos para cadastro do paciente");
                await Task.FromResult(response);
            }

            if (response.Sucesso)
            {
                paciente.Id = _pacientes.Count + 1;
                _pacientes.Add(paciente);
                response.Paciente = paciente;
            }
            return await Task.FromResult(response);
        }

        public async Task<PacienteResponseDto> Deletar(int id)
        {
            var response = new PacienteResponseDto();

            var indx = _pacientes.FindIndex(p => p.Id == id);

            if (indx <= -1)
            {
                response.AddMessage("Id Inválido");
            }
            else
            {
                _pacientes.RemoveAt(indx);
                response.AddMessage("Paciente deletado com sucesso");
            }

            return await Task.FromResult(response);
        }

        public async Task<PacienteResponseDto> Atualizar(Paciente paciente)
        {
            var response = new PacienteResponseDto();

            var indx = _pacientes.FindIndex(p => p.Id == paciente.Id);

            if (indx == -1)
            {
                response.AddMessage("paciente não encontrado");
            }

            if (!EhValido(paciente))
            {
                response.AddMessage("Dados inválidos para atualização");
                await Task.FromResult(response);
            }

            if (response.Sucesso)
            {
                _pacientes[indx] = paciente;
                response.Paciente = paciente;
            }

            return await Task.FromResult(response);
        }

        public async Task<Paciente?> Consultar(int id)
        {
            var paciente = _pacientes.Find(p => p.Id == id);
            return await Task.FromResult(paciente);
        }

        public async Task<List<Paciente>> ListarTodos()
        {
            return await Task.FromResult(_pacientes);
        }

        private bool EhValido(Paciente paciente)
        {
            var response = new PacienteResponseDto();

            if (paciente.Nome.Length < 3)
            {
                return false;
            }
            if (paciente.Idade <= 0 || paciente.Idade > 120)
            {
                return false;
            }
            if (!Regex.IsMatch(paciente.Numero.ToString(), @"^\d+$"))
            {
                return false;
            }
            if (!Regex.IsMatch(paciente.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return false;
            }
            return true;
        }
    }
}
