using System.Collections.Generic;
using MySql.Data.MySqlClient;
using REVChopp.Models;
using REVChopp.Core;

namespace REVChopp.Repositories
{
    public static class RelatorioBarrisRepository
    {
        public static void Inserir(RelatorioBarris barril)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand(@"INSERT INTO RelatorioBarris (id_relatorio, id_barril_tipo, nome_barril, ml_consumidos_total)
                    VALUES (@relatorio, @barril, @nome, @ml);", conexao);
                comando.Parameters.AddWithValue("@relatorio", barril.RelatorioId);
                comando.Parameters.AddWithValue("@barril", barril.BarrilTipoId);
                comando.Parameters.AddWithValue("@nome", barril.NomeBarril);
                comando.Parameters.AddWithValue("@ml", barril.MlConsumidosTotal);
                comando.ExecuteNonQuery();

            }
        }

        public static List<RelatorioBarris> BuscarPorRelatorio(int relatorioId)
        {
            var lista = new List<RelatorioBarris>();
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("SELECT * FROM RelatorioBarris WHERE id_relatorio = @relatorio", conexao);
                comando.Parameters.AddWithValue("@relatorio", relatorioId);
                using var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new RelatorioBarris
                    {
                        Id = reader.GetInt32("id"),
                        RelatorioId = reader.GetInt32("id_relatorio"),
                        BarrilTipoId = reader.GetInt32("id_barril_tipo"),
                        NomeBarril = reader.GetString("nome_barril"),
                        MlConsumidosTotal = reader.GetInt32("ml_consumidos_total")
                    });
                }
            }
            return lista;
        }
    }
}