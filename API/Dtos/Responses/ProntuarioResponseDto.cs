using ProjetoInicialVS.Dtos.Responses;

namespace ProjetoIniciaVs.API.Dtos.Responses
{
    public class ProntuarioResponseDto : ResponseBase
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int PacienteId { get; set; }
        public string? NomePaciente { get; set; }
    }
}
