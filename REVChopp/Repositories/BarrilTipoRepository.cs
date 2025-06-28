using REVChopp.Models;
using MySql.Data.MySqlClient;
using REVChopp.Core;

namespace REVChopp.Repositories
{
    public class BarrilTipoRepository
    {

        public static void Inserir(BarrilTipo barrilTipo)
        {
            if (barrilTipo == null)
                throw new ArgumentNullException(nameof(barrilTipo), "BarrilTipo não pode ser nulo.");

            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("INSERT INTO BarrilTipo (nome, tipo_cerveja, capacidade_litros) VALUES (@nome, @tipoCerveja, @capacidadeLitros)", conexao);
                comando.Parameters.AddWithValue("@nome", barrilTipo.Nome);
                comando.Parameters.AddWithValue("@tipoCerveja", barrilTipo.TipoCerveja);
                comando.Parameters.AddWithValue("@capacidadeLitros", barrilTipo.CapacidadeLitros);
                comando.ExecuteNonQuery();
            }
        }
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

        public static List<BarrilTipo> ListarTodos()
        {
            var lista = new List<BarrilTipo>();
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("SELECT * FROM BarrilTipo", conexao);
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new BarrilTipo
                        {
                            Id = leitor.GetInt32("id_barril_tipo"),
                            Nome = leitor.GetString("nome"),
                            TipoCerveja = leitor.GetString("tipo_cerveja"),
                            CapacidadeLitros = leitor.GetInt32("capacidade_litros")
                        });
                    }
                }
            }
            return lista;
        }
    }
}