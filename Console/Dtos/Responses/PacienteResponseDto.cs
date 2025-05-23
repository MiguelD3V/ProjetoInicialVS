using ProjetoInicialVS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoInicialVS.Dtos.Responses
{
    internal class PacienteResponseDto : ResponseBase
    {
        public string Mensagem { get; set; } = string.Empty;
        public Paciente Paciente { get; set; }


    }
}
