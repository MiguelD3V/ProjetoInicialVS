using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ProjetoInicialVS.Models;

namespace ProjetoInicialVS.Controllers
{
    internal class PacienteController
    {
        public void Cadastrar()
        {
            Paciente paciente = new Paciente()
            {
                Id = 001,
                Nome = "Miguel Tonho",
                Idade = 20,
                Email = "Miguel@gmail.com",
                Logradouro = "Rua dos anjos",
                Numero = 123
            };
        }

        public void Atualizar() {

            Paciente pacienteAtualizado = new Paciente()
            {
                Id = 001,
                Nome = "Miguel Tonho",
                Idade = 20,
                Email = "Miguel123@gmail.com",
                Logradouro = "Rua dos anjos",
                Numero = 456

            };
        }

        public void Deletar(int id)
        {

        }

        public void Consulta(int id)
        {

        }

    }

}
