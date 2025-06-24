using MySql.Data.MySqlClient;
using REVChopp.Core;
using REVChopp.Models;

namespace REVChopp.Repositories
{
    public class PedidoRepository
    {
        public static int Inserir(Pedido pedido)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("INSERT INTO Pedido (UsuarioId, NumeroMesa, DataHora, FormaPagamento, ValorTotal) VALUES (@usuario, @mesa, @data, @pagamento, @valor); SELECT LAST_INSERT_ID();", conexao);
                comando.Parameters.AddWithValue("@usuario", pedido.UsuarioId);
                comando.Parameters.AddWithValue("@mesa", pedido.NumeroMesa);
                comando.Parameters.AddWithValue("@data", pedido.DataHora);
                comando.Parameters.AddWithValue("@pagamento", pedido.FormaPagamento);
                comando.Parameters.AddWithValue("@valor", pedido.ValorTotal);

                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }

        public static void AtualizarValorTotal(int pedidoId, decimal novoTotal)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("UPDATE Pedido SET ValorTotal = @valor WHERE id_pedido = @id", conexao);
                comando.Parameters.AddWithValue("@valor", novoTotal);
                comando.Parameters.AddWithValue("@id", pedidoId);
                comando.ExecuteNonQuery();
            }
        }

        public static Pedido? BuscarPorId(int id)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("SELECT * FROM Pedido WHERE id_pedido = @id", conexao);
                comando.Parameters.AddWithValue("@id", id);
                using (var leitor = comando.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return new Pedido
                        {
                            Id = leitor.GetInt32("id_pedido"),
                            UsuarioId = leitor.GetInt32("UsuarioId"),
                            NumeroMesa = leitor.GetInt32("NumeroMesa"),
                            DataHora = leitor.GetDateTime("DataHora"),
                            FormaPagamento = leitor.GetString("FormaPagamento"),
                            ValorTotal = leitor.GetDecimal("ValorTotal")
                        };
                    }
                }
            }
            return null;
        }
    }
}