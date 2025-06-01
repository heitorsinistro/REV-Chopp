using MySql.Data.MySqlClient;
using REVChopp.Core;
using REVChopp.Models;

namespace REVChopp.Repositories
{
    public class BarrilInstanciaRepository
    {
        public static void Adicionar(BarrilInstancia barril)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("INSERT INTO BarrilInstancia (BarrilTipoId, VolumeRestanteMl, Status, DataAbertura, DataValidade) VALUES (@barrilTipoId, @volumeRestanteMl, @status, @dataAbertura, @dataValidade)", conexao);
                comando.Parameters.AddWithValue("@barrilTipoId", barril.BarrilTipoId);
                comando.Parameters.AddWithValue("@volumeRestanteMl", barril.VolumeRestanteMl);
                comando.Parameters.AddWithValue("@status", barril.Status);
                comando.Parameters.AddWithValue("@dataAbertura", barril.DataAbertura.HasValue ? (object)barril.DataAbertura.Value : DBNull.Value);
                comando.Parameters.AddWithValue("@dataValidade", barril.DataValidade.HasValue ? (object)barril.DataValidade.Value : DBNull.Value);
                comando.ExecuteNonQuery();
            }
        }

        public static void Remover(int id)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("DELETE FROM BarrilInstancia WHERE Id = @id", conexao);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
            }
        }

        public static BarrilInstancia? BuscarPorId(int id)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("SELECT * FROM BarrilInstancia WHERE Id = @id", conexao);
                comando.Parameters.AddWithValue("@id", id);
                using (var leitor = comando.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return new BarrilInstancia
                        {
                            Id = leitor.GetInt32("Id"),
                            BarrilTipoId = leitor.GetInt32("BarrilTipoId"),
                            VolumeRestanteMl = leitor.GetInt32("VolumeRestanteMl"),
                            Status = leitor.GetString("Status"),
                            DataAbertura = leitor.IsDBNull(leitor.GetOrdinal("DataAbertura")) ? null : leitor.GetDateTime(leitor.GetOrdinal("DataAbertura")),
                            DataValidade = leitor.IsDBNull(leitor.GetOrdinal("DataValidade")) ? null : leitor.GetDateTime(leitor.GetOrdinal("DataValidade"))
                        };
                    }
                }
            }
            return null;
        }

        public static List<BarrilInstancia> ListarTodos()
        {
            var barris = new List<BarrilInstancia>();
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("SELECT * FROM BarrilInstancia", conexao);
                using (var leitor = comando.ExecuteReader())
                {
                    int idxDataAbertura = leitor.GetOrdinal("DataAbertura");
                    int idxDataValidade = leitor.GetOrdinal("DataValidade");
                    while (leitor.Read())
                    {
                        var barril = new BarrilInstancia
                        {
                            Id = leitor.GetInt32("Id"),
                            BarrilTipoId = leitor.GetInt32("BarrilTipoId"),
                            VolumeRestanteMl = leitor.GetInt32("VolumeRestanteMl"),
                            Status = leitor.GetString("Status"),
                            DataAbertura = leitor.IsDBNull(idxDataAbertura) ? null : leitor.GetDateTime(idxDataAbertura),
                            DataValidade = leitor.IsDBNull(idxDataValidade) ? null : leitor.GetDateTime(idxDataValidade)
                        };
                        barris.Add(barril);
                    }
                }
            }
            return barris;
        }
    }
}