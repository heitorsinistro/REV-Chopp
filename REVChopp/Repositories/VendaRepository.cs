using MySql.Data.MySqlClient;
using REVChopp.Core;
using REVChopp.Models;

namespace REVChopp.Repositories
{
    public class VendaRepository
    {
        public static void RegistrarVenda(Venda venda)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("INSERT INTO Venda (id_pedido, id_usuario, data_hora) VALUES (@id_pedido, @id_usuario, @data_hora)", conexao);
                comando.Parameters.AddWithValue("@pedido", venda.PedidoId);
                comando.Parameters.AddWithValue("@usuario", venda.UsuarioId);
                comando.Parameters.AddWithValue("@data", venda.DataHora);
                comando.ExecuteNonQuery();
            }
        }
    }
}