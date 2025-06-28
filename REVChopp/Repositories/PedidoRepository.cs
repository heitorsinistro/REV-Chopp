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
                var comando = new MySqlCommand(@"INSERT INTO Pedido (id_usuario, numero_mesa, data_hora, forma_pagamento, valor_total) 
                    VALUES (@usuario, @mesa, @data, @pagamento, @valor); SELECT LAST_INSERT_ID();", conexao);
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
                var comando = new MySqlCommand("UPDATE Pedido SET valor_total = @valor WHERE id_pedido = @id", conexao);
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
                            UsuarioId = leitor.GetInt32("id_usuario"),
                            NumeroMesa = leitor.GetInt32("numero_mesa"),
                            DataHora = leitor.GetDateTime("data_hora"),
                            FormaPagamento = leitor.GetString("forma_pagamento"),
                            ValorTotal = leitor.GetDecimal("valor_total")
                        };
                    }
                }
            }
            return null;
        }

        public class ItemResumoPedido
        {
            public string NomeExibido { get; set; } = "";
            public int Quantidade { get; set; }
            public decimal TotalItem { get; set; }
        }

        public static List<ItemResumoPedido> ObterItensDoPedido(int pedidoId)
        {
            var itens = new List<ItemResumoPedido>();

            using var conexao = BancoDados.ObterConexao();

            // Itens com ProdutoUnitario
            string sqlProduto = @"
                SELECT i.quantidade, p.nome, i.subtotal
                FROM itenspedido i
                JOIN produtounitario p ON i.id_produto = p.id_produto
                WHERE i.id_pedido = @pedidoId AND i.id_produto IS NOT NULL";

            using (var comando = new MySqlCommand(sqlProduto, conexao))
            {
                comando.Parameters.AddWithValue("@pedidoId", pedidoId);
                using var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    itens.Add(new ItemResumoPedido
                    {
                        NomeExibido = reader.GetString("nome"),
                        Quantidade = reader.GetInt32("quantidade"),
                        TotalItem = reader.GetDecimal("subtotal")
                    });
                }
            }

            // Itens com Copo
            string sqlCopo = @"
                SELECT i.quantidade, c.capacidade_ml, i.subtotal
                FROM itenspedido i
                JOIN copo c ON i.id_copo = c.id_copo
                WHERE i.id_pedido = @pedidoId AND i.id_copo IS NOT NULL";

            using (var comando = new MySqlCommand(sqlCopo, conexao))
            {
                comando.Parameters.AddWithValue("@pedidoId", pedidoId);
                using var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    string nomeCopo = $"Copo {reader.GetInt32("capacidade_ml")}ml";
                    itens.Add(new ItemResumoPedido
                    {
                        NomeExibido = nomeCopo,
                        Quantidade = reader.GetInt32("quantidade"),
                        TotalItem = reader.GetDecimal("subtotal")
                    });
                }
            }

            return itens;
        }

        public static List<Pedido> BuscarPedidosAbertos()
        {
            var lista = new List<Pedido>();

            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand(
                    "SELECT id_pedido, numero_mesa, valor_total FROM Pedido WHERE id_pedido NOT IN (SELECT id_pedido FROM Venda)", conexao);

                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new Pedido
                        {
                            Id = leitor.GetInt32("id_pedido"),
                            NumeroMesa = leitor.GetInt32("numero_mesa"),
                            ValorTotal = leitor.GetDecimal("valor_total")
                        });
                    }
                }
            }

            return lista;
        }

    }
}