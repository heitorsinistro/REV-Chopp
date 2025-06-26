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
                var comando = new MySqlCommand("SELECT * FROM BarrilTipo WHERE id_barril_tipo = @id", conexao);
                comando.Parameters.AddWithValue("@id", id);
                using (var leitor = comando.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return new BarrilTipo
                        {
                            Id = leitor.GetInt32("id_barril_tipo"),
                            Nome = leitor.GetString("nome"),
                            TipoCerveja = leitor.GetString("tipo_cerveja"),
                            CapacidadeLitros = leitor.GetInt32("capacidade_litros")
                        };
                    }
                }
            }
            throw new Exception("BarrilTipo não encontrado.");
        }
    }
}