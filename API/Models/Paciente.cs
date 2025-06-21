using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoIniciaVs.API.Models
{
    public class Paciente
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
        public string Logradouro { get; set; } = string.Empty;
        public int Numero { get; set; }
        public string Email { get; set; } = string.Empty;
              
    }
}
