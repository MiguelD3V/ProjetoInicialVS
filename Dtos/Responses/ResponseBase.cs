using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoInicialVS.Dtos.Responses
{
    internal class ResponseBase
    {
        public bool Sucesso { get; set; } = true;
        public List<string> Mensagens { get; set; } = new List<string>();

        public void AddMessage(string Mensagem)
        {
            Mensagens.Add(Mensagem);
            Sucesso = false;

        }
    }
}
