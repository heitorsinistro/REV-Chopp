namespace REVChopp.Models
{
    public class Usuario
    {
        public string? Nome { get; set; }
        public string? Senha { get; set; }

        public static bool Autenticar(string nome, string senha)
        {
            return nome == "admin" && senha == "1234";
        }
    }
}