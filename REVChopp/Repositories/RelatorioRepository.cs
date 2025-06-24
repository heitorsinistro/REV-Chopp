using System;
using MySql.Data.MySqlClient;
using REVChopp.Models;
using REVChopp.Core;

namespace REVChopp.Repositories
{
    public static class RelatorioRepository
    {
        public static int Inserir(Relatorio r)
        {
            using var conexao = BancoDados.ObterConexao();
            var comando = new MySqlCommand("INSERT INTO Relatorio (tipo, data_inicio, gerado_por) VALUES (@tipo, @data, @autor); SELECT LAST_INSERT_ID();", conexao);
            comando.Parameters.AddWithValue("@tipo", r.Tipo);
            comando.Parameters.AddWithValue("@data", r.DataInicio);
            comando.Parameters.AddWithValue("@autor", r.GeradoPor);
            return Convert.ToInt32(comando.ExecuteScalar());
        }

        public static decimal CalcularTotalVendas(DateTime inicio, DateTime fim)
        {
            using var conexao = BancoDados.ObterConexao();
            var comando = new MySqlCommand("SELECT SUM(valor_total) FROM Pedido WHERE data_hora BETWEEN @inicio AND @fim", conexao);
            comando.Parameters.AddWithValue("@inicio", inicio);
            comando.Parameters.AddWithValue("@fim", fim);
            var result = comando.ExecuteScalar();
            return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
        }
    }
}