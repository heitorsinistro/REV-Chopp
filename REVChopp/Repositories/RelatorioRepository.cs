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
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("INSERT INTO Relatorio (tipo, data_inicio, data_fim, gerado_por) VALUES (@tipo, @data, @fim, @autor); SELECT LAST_INSERT_ID();", conexao);
                comando.Parameters.AddWithValue("@tipo", r.Tipo);
                comando.Parameters.AddWithValue("@data", r.DataInicio);
                comando.Parameters.AddWithValue("@fim", r.DataFim);
                comando.Parameters.AddWithValue("@autor", r.GeradoPor);
                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }

        public static decimal CalcularTotalVendas(DateTime inicio, DateTime fim)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("SELECT SUM(valor_total) FROM Pedido WHERE data_hora BETWEEN @inicio AND @fim", conexao);
                comando.Parameters.AddWithValue("@inicio", inicio);
                comando.Parameters.AddWithValue("@fim", fim);
                var result = comando.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
            }
        }

        public static List<Relatorio> BuscarTodos()
        {
            var relatorios = new List<Relatorio>();
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("SELECT * FROM Relatorio ORDER BY data_inicio DESC", conexao);
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        relatorios.Add(new Relatorio
                        {
                            Id = leitor.GetInt32("id_relatorio"),
                            Tipo = leitor.GetString("tipo"),
                            DataInicio = leitor.GetDateTime("data_inicio"),
                            GeradoPor = leitor.GetInt32("gerado_por")
                        });
                    }
                }
            }
            return relatorios;
        }
    }
}