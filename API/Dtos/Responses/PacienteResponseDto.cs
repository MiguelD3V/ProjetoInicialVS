using ProjetoInicialVS.Dtos.Responses;
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


    }
}
