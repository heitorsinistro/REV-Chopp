using System.Collections.Generic;
using MySql.Data.MySqlClient;
using REVChopp.Models;
using REVChopp.Core;

namespace REVChopp.Repositories
{
    public static class ConsumoBarrilRepository
    {
        public static void RegistrarConsumo(int vendaId, int barrilInstanciaId, int mlConsumido)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var insert = new MySqlCommand("INSERT INTO ConsumoBarril (id_venda, id_barril_instancia, ml_consumido) VALUES (@vendaId, @barrilInstanciaId, @mlConsumido)", conexao);
                insert.Parameters.AddWithValue("@vendaId", vendaId);
                insert.Parameters.AddWithValue("@barrilInstanciaId", barrilInstanciaId);
                insert.Parameters.AddWithValue("@mlConsumido", mlConsumido);
                insert.ExecuteNonQuery();

                var update = new MySqlCommand("UPDATE BarrilInstancia SET volume_restante_ml = volume_restante_ml - @mlConsumido WHERE id_barril_instancia = @barril", conexao);
                update.Parameters.AddWithValue("@ml", mlConsumido);
                update.Parameters.AddWithValue("@barril", barrilInstanciaId);
                update.ExecuteNonQuery();
            }
        }

        public static List<ConsumoBarril> ListarPorVenda(int vendaId)
        {
            var consumos = new List<ConsumoBarril>();

            using (var conexao = BancoDados.ObterConexao())
            {
                var select = new MySqlCommand("SELECT * FROM ConsumoBarril WHERE id_venda = @vendaId", conexao);
                select.Parameters.AddWithValue("@vendaId", vendaId);

                using (var reader = select.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var consumo = new ConsumoBarril
                        {
                            Id = reader.GetInt32("id_consumo_barril"),
                            VendaId = reader.GetInt32("id_venda"),
                            BarrilInstanciaId = reader.GetInt32("id_barril_instancia"),
                            MlUtilizado = reader.GetInt32("ml_consumido")
                        };
                        consumos.Add(consumo);
                    }
                }
            }

            return consumos;
        }
    }
}