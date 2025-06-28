using System.Collections.Generic;
using MySql.Data.MySqlClient;
using REVChopp.Models;
using REVChopp.Core;

namespace REVChopp.Repositories
{
    public static class RelatorioCoposRepository
    {
        public static void Inserir(RelatorioCopos copo)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand(@"INSERT INTO RelatorioCopos (id_relatorio, id_copo, capacidade_ml, quantidade_vendida, total_receita_copos)
                    VALUES (@relatorio, @copo, @ml, @quantidade, @total)", conexao);
                comando.Parameters.AddWithValue("@relatorio", copo.RelatorioId);
                comando.Parameters.AddWithValue("@copo", copo.CopoId);
                comando.Parameters.AddWithValue("@ml", copo.CapacidadeMl);
                comando.Parameters.AddWithValue("@quantidade", copo.QuantidadeVendida);
                comando.Parameters.AddWithValue("@total", copo.TotalReceitaCopos);
                comando.ExecuteNonQuery();
            }
        }

        public static List<RelatorioCopos> BuscarPorRelatorio(int relatorioId)
        {
            var lista = new List<RelatorioCopos>();
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("SELECT * FROM RelatorioCopos WHERE id_relatorio = @relatorio", conexao);
                comando.Parameters.AddWithValue("@relatorio", relatorioId);
                using var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new RelatorioCopos
                    {
                        Id = reader.GetInt32("id"),
                        RelatorioId = reader.GetInt32("id_relatorio"),
                        CopoId = reader.GetInt32("id_copo"),
                        CapacidadeMl = reader.GetInt32("capacidade_ml"),
                        QuantidadeVendida = reader.GetInt32("quantidade_vendida"),
                        TotalReceitaCopos = reader.GetDecimal("total_receita_copos")
                    });
                }
            }
            return lista;
        }
    }
}