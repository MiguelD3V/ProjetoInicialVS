using ProjetoInicialVS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProjetoInicialVS.Dtos.Responses;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjetoInicialVS.Services
{
    internal class PacienteService
    {

        private static List<Paciente> _pacientes = [];
        public static PacienteResponseDto Inserir(Paciente paciente)
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
            return response;
        }

        public static void Deletar(int id)
        {
            var indx = _pacientes.FindIndex(p => p.Id == id);
            _pacientes.RemoveRange(indx, 1);

        }

        public static void Atualizar(Paciente paciente)
        {
            var indx = _pacientes.FindIndex(p => p.Id == paciente.Id);
            _pacientes[indx] = paciente;
        }

        public static Paciente? Buscar(Predicate<Paciente> predicado)
        {
            return _pacientes.Find(predicado);

        }
    }
}
