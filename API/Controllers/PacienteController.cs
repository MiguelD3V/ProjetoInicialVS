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
        public async Task<IActionResult> CadastroAsync([FromBody] Paciente paciente)
        {
            try
            {
                var resultado = await _pacienteService.Inserir(paciente);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return Problem($"Ocorreu o erro {ex.Message}", statusCode: 500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id,[FromBody] Paciente paciente)
        {
            try
            {
                var atualizado = await _pacienteService.Atualizar(paciente,id);
                return Ok(atualizado);
            }
            catch (Exception ex)
            {
                return Problem($"Ocorreu o erro {ex.Message}", statusCode: 500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                var resultado = await _pacienteService.Deletar(id);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return Problem($"Ocorreu o erro {ex.Message}", statusCode: 500);
            }
        }

            [HttpGet("{id}")]
        public async Task<IActionResult> Consulta(int id)
        {
            try
            {
                var busca = await _pacienteService.Consultar(id);

                return Ok(busca);
            }
            catch(Exception ex)
            {
                return Problem($"Ocorreu o erro{ex.Message}", statusCode: 500);
            }

        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var lista = await _pacienteService.ListarTodos();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return Problem($"Ocorreu o erro{ex.Message}", statusCode: 500);
            }
        }
    }

}
