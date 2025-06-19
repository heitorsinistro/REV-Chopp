using MySql.Data.MySqlClient;
using REVChopp.Core;
using REVChopp.Models;

namespace REVChopp.Repositories
{
    public class ItensPedidoRepository
    {
        public static void Inserir(ItensPedido item)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("INSERT INTO ItensPedido (id_pedido, id_produto, id_copo, tipo_item, nome_item, preco_unitario, quantidade, subtotal) VALUES (@id_pedido, @id_produto, @id_copo, @tipo_item, @nome_item, @preco_unitario, @quantidade, @subtotal)", conexao);
                comando.Parameters.AddWithValue("@pedido", item.PedidoId);
                comando.Parameters.AddWithValue("@produto", (object?)item.ProdutoId ?? DBNull.Value);
                comando.Parameters.AddWithValue("@copo", (object?)item.CopoId ?? DBNull.Value);
                comando.Parameters.AddWithValue("@tipo", item.TipoItem);
                comando.Parameters.AddWithValue("@nome", item.NomeItem);
                comando.Parameters.AddWithValue("@preco", item.PrecoUnitario);
                comando.Parameters.AddWithValue("@qtd", item.Quantidade);
                comando.Parameters.AddWithValue("@sub", item.Subtotal);
                comando.ExecuteNonQuery();
            }
        }
    }
}