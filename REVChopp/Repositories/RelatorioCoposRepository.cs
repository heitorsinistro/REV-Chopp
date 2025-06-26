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
    }
}