namespace REVChopp.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; } = "";
        public string? Senha { get; set; } = "";
        public string? NivelAcesso { get; set; } = "";
    }
}