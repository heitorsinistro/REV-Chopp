using MySql.Data.MySqlClient;
using REVChopp.Models;
using REVChopp.Core;

namespace REVChopp.Repositories
{
    public static class UsuarioRepository
    {

        public static void Inserir(Usuario usuario)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("INSERT INTO Usuario (nome, senha, nivel_acesso) VALUES (@nome, @senha, @nivel)", conexao);
                comando.Parameters.AddWithValue("@nome", usuario.Nome);
                comando.Parameters.AddWithValue("@senha", usuario.Senha);
                comando.Parameters.AddWithValue("@nivel", usuario.NivelAcesso);
                comando.ExecuteNonQuery();
            }
        }

        public static Usuario? Autenticar(string nome, string senha, string nivelAcesso)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("SELECT * FROM Usuario WHERE nome = @nome AND senha = @senha AND nivel_acesso = @nivel", conexao);
                comando.Parameters.AddWithValue("@nome", nome);
                comando.Parameters.AddWithValue("@senha", senha);
                comando.Parameters.AddWithValue("@nivel", nivelAcesso);

                using var reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    return new Usuario
                    {
                        Id = reader.GetInt32("id_usuario"),
                        Nome = reader.GetString("nome"),
                        Senha = reader.GetString("senha"),
                        NivelAcesso = reader.GetString("nivel_acesso")
                    };
                }

                return null;
            }
        }

        public static Usuario? ObterPorNome(string nome)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("SELECT * FROM Usuario WHERE nome = @nome", conexao);
                comando.Parameters.AddWithValue("@nome", nome);
                using var reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    return new Usuario
                    {
                        Id = reader.GetInt32("id_usuario"),
                        Nome = reader.GetString("nome"),
                        Senha = reader.GetString("senha"),
                        NivelAcesso = reader.GetString("nivel_acesso")
                    };
                }
                return null;
            }
        }
    }
}