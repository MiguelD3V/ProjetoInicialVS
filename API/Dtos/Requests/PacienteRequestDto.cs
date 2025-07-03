namespace ProjetoIniciaVs.API.Dtos.Requests
{
    public class PacienteRequestDto
    {
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
        public string Logradouro { get; set; } = string.Empty;
        public int Numero { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
