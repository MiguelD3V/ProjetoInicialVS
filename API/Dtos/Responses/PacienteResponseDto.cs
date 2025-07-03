using ProjetoInicialVS.Dtos.Responses;
using ProjetoIniciaVs.API.Interfaces;
using ProjetoIniciaVs.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoIniciaVs.API.Dtos.Responses
{
    public class PacienteResponseDto : ResponseBase
    {
        [JsonIgnore]
        public string Mensagem { get; set; } = string.Empty;
        [JsonIgnore]
        public PacienteResponseDto? Paciente { get; set; }
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
        public string Logradouro { get; set; } = string.Empty;
        public int Numero { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
