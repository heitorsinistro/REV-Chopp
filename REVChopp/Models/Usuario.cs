namespace REVChopp.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; } = "";
        public string? Senha { get; set; } = "";
        public string? NivelAcesso { get; set; } = "";

        public static bool Autenticar(string nome, string senha, string nivelAcesso)
        {
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(senha) || string.IsNullOrWhiteSpace(nivelAcesso))
            {
                return false; // Invalid input
            }

            // Authentication logic here
            return nome == "admin" && senha == "admin123" && nivelAcesso == "admin";
        }
    }
}