using REVChopp.Models;
using MySql.Data.MySqlClient;
using REVChopp.Core;

namespace REVChopp.Repositories
{
    public class BarrilTipoRepository
    {
        public static BarrilTipo ObterPorId(int id)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("SELECT * FROM BarrilTipo WHERE Id = @id", conexao);
                comando.Parameters.AddWithValue("@id", id);
                using (var leitor = comando.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return new BarrilTipo
                        {
                            Id = leitor.GetInt32("Id"),
                            Nome = leitor.GetString("Nome"),
                            TipoCerveja = leitor.GetString("TipoCerveja"),
                            CapacidadeLitros = leitor.GetInt32("CapacidadeLitros")
                        };
                    }
                }
            }
            throw new Exception("BarrilTipo não encontrado.");
        }
    }
}