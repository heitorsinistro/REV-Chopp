using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using REVChopp.Models;
using REVChopp.Core;

namespace REVChopp.Repositories
{
    public static class RelatorioItensRepository
    {
        public static List<(string Nome, int Total)> ResumoItensVendidos(DateTime inicio, DateTime fim)
        {
            var lista = new List<(string, int)>();
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand(@"
                    SELECT nome_item, SUM(quantidade) as total
                    FROM ItensPedido
                    WHERE tipo_item = 'produto'
                    AND id_pedido IN (SELECT id_pedido FROM Pedido WHERE data_hora BETWEEN @inicio AND @fim)
                    GROUP BY nome_item
                    ORDER BY total DESC", conexao);
                comando.Parameters.AddWithValue("@inicio", inicio);
                comando.Parameters.AddWithValue("@fim", fim);
                using var reader = comando.ExecuteReader();
                while (reader.Read())
                    lista.Add((reader.GetString("nome_item"), reader.GetInt32("total")));
                return lista;
            }
        }

        public static void Inserir(RelatorioItens item)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand(@"INSERT INTO RelatorioItens (id_relatorio, id_produto, nome_produto, quantidade_vendida, total_receita_produto) 
                    VALUES (@relatorio, @produto, @nome, @quantidade, @total)", conexao);
                comando.Parameters.AddWithValue("@relatorio", item.RelatorioId);
                comando.Parameters.AddWithValue("@produto", item.ProdutoId);
                comando.Parameters.AddWithValue("@nome", item.NomeProduto);
                comando.Parameters.AddWithValue("@quantidade", item.QuantidadeVendida);
                comando.Parameters.AddWithValue("@total", item.TotalReceitaProduto);
                comando.ExecuteNonQuery();
            }
        }
    }
}