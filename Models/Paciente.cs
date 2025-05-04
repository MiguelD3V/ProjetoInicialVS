using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoInicialVS.Models
{
    internal class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
        public string Logradouro { get; set; } = string.Empty;
        public int Numero { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
