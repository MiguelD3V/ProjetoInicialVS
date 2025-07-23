using Microsoft.AspNetCore.Mvc;
using ProjetoIniciaVs.API.Dtos.Requests;
using ProjetoIniciaVs.API.Interfaces;

namespace ProjetoIniciaVs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProntuarioController : Controller
    {
        private readonly IProntuarioService _prontuarioService;

        public ProntuarioController(IProntuarioService prontuarioService)
        {
            _prontuarioService = prontuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastroAsync([FromBody] ProntuarioRequestDto prontuario)
        {
            try
            {
                if (!_prontuarioService.EhValido(prontuario))
                {
                    return BadRequest("Dados inválidos.");
                }
                var resultado = await _prontuarioService.CreateAsync(prontuario);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return Problem($"Ocorreu o erro {ex.Message}", statusCode: 500);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            try
            {
                var resultado = await _prontuarioService.GetByIdAsync(id);
                if (resultado == null)
                {
                    return NotFound("Prontuário não encontrado.");
                }
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return Problem($"Ocorreu o erro {ex.Message}", statusCode: 500);
            }
        }
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var resultado = await _prontuarioService.GetAllAsync();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return Problem($"Ocorreu o erro {ex.Message}", statusCode: 500);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] ProntuarioRequestDto prontuario)
        {
            try
            {
                if (!_prontuarioService.EhValido(prontuario))
                {
                    return BadRequest("Dados inválidos.");
                }
                var atualizado = await _prontuarioService.UpdateAsync(id, prontuario);
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
                await _prontuarioService.DeleteAsync(id);
                return Ok("Prontuário deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return Problem($"Ocorreu o erro {ex.Message}", statusCode: 500);
            }
        }
    }
}
