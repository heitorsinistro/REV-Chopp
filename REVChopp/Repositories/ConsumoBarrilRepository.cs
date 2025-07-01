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
                var insert = new MySqlCommand(@"INSERT INTO consumobarril (id_venda, id_barril_instancia, ml_utilizado) 
                    VALUES (@vendaId, @barrilInstanciaId, @mlConsumido)", conexao);
                insert.Parameters.AddWithValue("@vendaId", vendaId);
                insert.Parameters.AddWithValue("@barrilInstanciaId", barrilInstanciaId);
                insert.Parameters.AddWithValue("@mlConsumido", mlConsumido);
                insert.ExecuteNonQuery();

                var update = new MySqlCommand(@"UPDATE barrilinstancia 
                    SET volume_restante_ml = volume_restante_ml - @mlConsumido 
                    WHERE id_barril_instancia = @barril", conexao);
                update.Parameters.AddWithValue("@mlConsumido", mlConsumido);
                update.Parameters.AddWithValue("@barril", barrilInstanciaId);
                int linhasAfetadas = update.ExecuteNonQuery();

                // LOG: mostra no Output do vscode (não na tela do sistema)
                Console.WriteLine($"Consumo registrado: venda={vendaId}, barril={barrilInstanciaId}, ml={mlConsumido}, linhas afetadas={linhasAfetadas}");
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
                            Id = reader.GetInt32("id_consumo"),
                            VendaId = reader.GetInt32("id_venda"),
                            BarrilInstanciaId = reader.GetInt32("id_barril_instancia"),
                            MlUtilizado = reader.GetInt32("ml_utilizado")
                        };
                        consumos.Add(consumo);
                    }
                }
            }

            return consumos;
        }

        public static List<(int BarrilTipoId, string NomeBarril, int MlConsumido)> ConsultarResumoBarris(DateTime inicio, DateTime fim)
        {
            var lista = new List<(int, string, int)>();
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand(@"
                    SELECT bt.id_barril_tipo, bt.nome, SUM(cb.ml_utilizado) as total
                    FROM ConsumoBarril cb
                    JOIN BarrilInstancia bi ON bi.id_barril_instancia = cb.id_barril_instancia
                    JOIN BarrilTipo bt ON bt.id_barril_tipo = bi.id_barril_tipo
                    JOIN Venda v ON v.id_venda = cb.id_venda
                    WHERE v.data_hora BETWEEN @inicio AND @fim
                    GROUP BY bt.id_barril_tipo, bt.nome", conexao);
                comando.Parameters.AddWithValue("@inicio", inicio);
                comando.Parameters.AddWithValue("@fim", fim);
                using var reader = comando.ExecuteReader();
                while (reader.Read())
                    lista.Add((reader.GetInt32("id_barril_tipo"), reader.GetString("nome"),
                            reader.GetInt32("total")));
                return lista;
            }
        }
    }
}