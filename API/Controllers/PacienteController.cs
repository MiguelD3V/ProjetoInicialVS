using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjetoIniciaVs.API.Interfaces;
using ProjetoIniciaVs.API.Models;

namespace ProjetoIniciaVs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        
        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpPost]
        public IActionResult Cadastro([FromBody] Paciente paciente)
        {
            var resultado = _pacienteService.Inserir(paciente);

            return Ok(resultado);
        }

        [HttpPut("{Id}")]
        public IActionResult Atualizar(int id,[FromBody] Paciente paciente) 
        {
            var atualizado = _pacienteService.Atualizar(paciente);

            return Ok(atualizado);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var resultado = _pacienteService.Deletar(id);

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public IActionResult Consulta(int id)
        {
            try
            {
                var busca = _pacienteService.Consultar(id);

                return Ok(busca);
            }
            catch
            {
                return Problem("Ocorreu um erro", statusCode: 500);
            }

        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                var lista = _pacienteService.ListarTodos();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return Problem($"Ocorreu o erro{ex}");
            }
        }
    }

}
