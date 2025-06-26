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
                var comando = new MySqlCommand(@"INSERT INTO ItensPedido (id_pedido, id_produto, id_copo, tipo_item, nome_item, preco_unitario, quantidade, subtotal) 
                    VALUES (@id_pedido, @id_produto, @id_copo, @tipo_item, @nome_item, @preco_unitario, @quantidade, @subtotal)", conexao);
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

        public static List<ItensPedido> ListarPorPedido(int pedidoId)
        {
            var lista = new List<ItensPedido>();
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("SELECT * FROM ItensPedido WHERE id_pedido = @pedido", conexao);
                comando.Parameters.AddWithValue("@pedido", pedidoId);
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new ItensPedido
                        {
                            Id = leitor.GetInt32("id_item_pedido"),
                            PedidoId = leitor.GetInt32("id_pedido"),
                            ProdutoId = leitor["id_produto"] as int?,
                            CopoId = leitor["id_copo"] as int?,
                            TipoItem = leitor.GetString("tipo_item"),
                            NomeItem = leitor.GetString("nome_item"),
                            PrecoUnitario = leitor.GetDecimal("preco_unitario"),
                            Quantidade = leitor.GetInt32("quantidade"),
                            Subtotal = leitor.GetDecimal("subtotal")
                        });
                    }

                    return lista;
                }
            }
        }

        public static List<(int ProdutoId, string NomeItem, int Quantidade, decimal Subtotal)> ConsultarResumoItens(DateTime inicio, DateTime fim)
        {
            var lista = new List<(int, string, int, decimal)>();
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand(@"
                    SELECT id_produto, nome_item, SUM(quantidade) as total, SUM(subtotal) as receita
                    FROM ItensPedido
                    WHERE tipo_item = 'produto' AND id_pedido IN
                    (SELECT id_pedido FROM Pedido WHERE data_hora BETWEEN @inicio AND @fim)
                    GROUP BY id_produto, nome_item", conexao);
                comando.Parameters.AddWithValue("@inicio", inicio);
                comando.Parameters.AddWithValue("@fim", fim);
                using var reader = comando.ExecuteReader();
                while (reader.Read())
                    lista.Add((reader.GetInt32("id_produto"), reader.GetString("nome_item"),
                            reader.GetInt32("total"), reader.GetDecimal("receita")));
                return lista;
            }
        }

        public static List<(int CopoId, int CapacidadeMl, int Quantidade, decimal Subtotal)> ConsultarResumoCopos(DateTime inicio, DateTime fim)
        {
            var lista = new List<(int, int, int, decimal)>();
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand(@"
                    SELECT ip.id_copo, c.capacidade_ml, SUM(ip.quantidade) as total, SUM(ip.subtotal) as receita
                    FROM ItensPedido ip
                    JOIN Copo c ON c.id_copo = ip.id_copo
                    WHERE tipo_item = 'copo' AND id_pedido IN
                    (SELECT id_pedido FROM Pedido WHERE data_hora BETWEEN @inicio AND @fim)
                    GROUP BY ip.id_copo, c.capacidade_ml", conexao);
                comando.Parameters.AddWithValue("@inicio", inicio);
                comando.Parameters.AddWithValue("@fim", fim);
                using var reader = comando.ExecuteReader();
                while (reader.Read())
                    lista.Add((reader.GetInt32("id_copo"), reader.GetInt32("capacidade_ml"),
                            reader.GetInt32("total"), reader.GetDecimal("receita")));
                return lista;
            }
        }
    }
}