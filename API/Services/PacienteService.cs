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
using ProjetoIniciaVs.API.Dtos.Requests;

namespace ProjetoIniciaVs.API.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

    

    public async Task<PacienteResponseDto> Inserir(PacienteRequestDto paciente)
        {
            var response = new PacienteResponseDto();

            if (!EhValido(paciente))
            {
                response.AddMessage("Dados inválidos para cadastro do paciente");
                return response;
            }

            if (response.Sucesso)
            {
               var pacienteCriado =  await _pacienteRepository.AddPacienteAsync(paciente);
                response.AddMessage($"Paciente cadastrado com sucesso: id {pacienteCriado.Id},nome {pacienteCriado.Nome}, idade {pacienteCriado.Idade}, Logradouro {pacienteCriado.Logradouro}, numero {pacienteCriado.Numero}.");
            }
            
            return response;
        }

        public async Task<PacienteResponseDto> Deletar(int id)
        {
            var response = new PacienteResponseDto();

                await _pacienteRepository.DeletePacienteAsync(id);
                response.AddMessage("Paciente deletado com sucesso");
          
            return response;
        }

        //public async Task<PacienteResponseDto> Atualizar(PacienteResponseDto paciente, int id)
        //{
        //    var response = new PacienteResponseDto();

        //    if (!EhValido(paciente))
        //    {
        //        response.AddMessage("Dados inválidos para atualização");
        //        return response;
        //    }

        //    if (response.Sucesso)
        //    {
        //        paciente.Id = id; 
        //        await _pacienteRepository.UpdatePacienteAsync(paciente);
        //        response.Paciente = paciente;
        //    }

        //    return response;
        //}

        public async Task<PacienteResponseDto> Consultar(int id)
        {
            var paciente = await _pacienteRepository.GetPacienteByIdAsync(id);
            return paciente;
        }

        public async Task<IEnumerable<PacienteResponseDto>> ListarTodos()
        {
            var lista = await _pacienteRepository.GetAllPacientesAsync();

            var response = lista.Select(p => new PacienteResponseDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Idade = p.Idade,
                Logradouro = p.Logradouro,
                Numero = p.Numero,
                Email = p.Email
            });
            return response;
        }

        private bool EhValido(PacienteRequestDto paciente)
        {
            var response = new Paciente();

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
