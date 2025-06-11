using ProjetoInicialVS.Dtos.Responses;
using ProjetoIniciaVs.API.Interfaces;
using ProjetoIniciaVs.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIniciaVs.API.Dtos.Responses
{
    public class PacienteResponseDto : ResponseBase
    {
        public string Mensagem { get; set; } = string.Empty;
        public Paciente? Paciente { get; set; }
        public int Id { get; internal set; }
        public string Nome { get; internal set; }
        public int Idade { get; internal set; }
        public string Logradouro { get; internal set; }
        public int Numero { get; internal set; }
        public string Email { get; internal set; }
    }
}
