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
            using var conn = BancoDados.ObterConexao();
            var cmd = new MySqlCommand(@"
                SELECT nome_item, SUM(quantidade) as total 
                FROM ItensPedido
                WHERE tipo_item = 'produto'
                  AND id_pedido IN (SELECT id_pedido FROM Pedido WHERE data_hora BETWEEN @inicio AND @fim)
                GROUP BY nome_item
                ORDER BY total DESC", conn);
            cmd.Parameters.AddWithValue("@inicio", inicio);
            cmd.Parameters.AddWithValue("@fim", fim);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                lista.Add((reader.GetString("nome_item"), reader.GetInt32("total")));
            return lista;
        }
    }
}