using MySql.Data.MySqlClient;
using REVChopp.Core;
using REVChopp.Models;

namespace REVChopp.Repositories
{
    public class BarrilInstanciaRepository
    {
        public static void Inserir(BarrilInstancia barril)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand(@"INSERT INTO BarrilInstancia (id_barril_tipo, volume_restante_ml, status, data_abertura, data_validade) 
                    VALUES (@barrilTipoId, @volumeRestanteMl, @status, @dataAbertura, @dataValidade)", conexao);
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
                var comando = new MySqlCommand("DELETE FROM BarrilInstancia WHERE id_barril_instancia = @id", conexao);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
            }
        }

        public static BarrilInstancia? BuscarPorId(int id)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("SELECT * FROM BarrilInstancia WHERE id_barril_instancia = @id", conexao);
                comando.Parameters.AddWithValue("@id", id);
                using (var leitor = comando.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return new BarrilInstancia
                        {
                            Id = leitor.GetInt32("id_barril_instancia"),
                            BarrilTipoId = leitor.GetInt32("id_barril_tipo"),
                            VolumeRestanteMl = leitor.GetInt32("volume_restante_ml"),
                            Status = leitor.GetString("status"),
                            DataAbertura = leitor.IsDBNull(leitor.GetOrdinal("data_abertura")) ? null : leitor.GetDateTime(leitor.GetOrdinal("DataAbertura")),
                            DataValidade = leitor.IsDBNull(leitor.GetOrdinal("data_validade")) ? null : leitor.GetDateTime(leitor.GetOrdinal("DataValidade"))
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
                    int idxDataAbertura = leitor.GetOrdinal("data_abertura");
                    int idxDataValidade = leitor.GetOrdinal("data_validade");
                    while (leitor.Read())
                    {
                        var barril = new BarrilInstancia
                        {
                            Id = leitor.GetInt32("id_barril_instancia"),
                            BarrilTipoId = leitor.GetInt32("id_barril_tipo"),
                            VolumeRestanteMl = leitor.GetInt32("volume_restante_ml"),
                            Status = leitor.GetString("status"),
                            DataAbertura = leitor.IsDBNull(idxDataAbertura) ? null : leitor.GetDateTime(idxDataAbertura),
                            DataValidade = leitor.IsDBNull(idxDataValidade) ? null : leitor.GetDateTime(idxDataValidade)
                        };
                        barris.Add(barril);
                    }
                }
            }
            return barris;
        }

        public static List<BarrilInstancia> ListarDisponiveis()
        {
            var barris = new List<BarrilInstancia>();
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("SELECT * FROM barrilinstancia WHERE status = 'em_uso' AND volume_restante_ml > 0", conexao);
                using (var leitor = comando.ExecuteReader())
                {
                    int idxDataAbertura = leitor.GetOrdinal("data_abertura");
                    int idxDataValidade = leitor.GetOrdinal("data_validade");
                    while (leitor.Read())
                    {
                        var barril = new BarrilInstancia
                        {
                            Id = leitor.GetInt32("id_barril_instancia"),
                            BarrilTipoId = leitor.GetInt32("id_barril_tipo"),
                            VolumeRestanteMl = leitor.GetInt32("volume_restante_ml"),
                            Status = leitor.GetString("status")
                        };
                        barris.Add(barril);
                    }
                }
            }
            return barris;
        }
    }
}