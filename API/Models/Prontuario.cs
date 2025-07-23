namespace ProjetoIniciaVs.API.Models
{
    public class Prontuario
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int PacienteId { get; set; }
    }
}
