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
    }
}