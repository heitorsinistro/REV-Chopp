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
    }
}