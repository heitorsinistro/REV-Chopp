using System.Collections.Generic;
using MySql.Data.MySqlClient;
using REVChopp.Models;
using REVChopp.Core;

namespace REVChopp.Repositories
{
    public static class CopoRepository
    {
        public static void Inserir(Copo copo)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("INSERT INTO Copo (capacidade_ml, preco_unidade) VALUES (@ml, @preco)", conexao);
                comando.Parameters.AddWithValue("@preco", copo.CapacidadeMl);
                comando.Parameters.AddWithValue("@volume", copo.Preco);
                comando.ExecuteNonQuery();
            }
        }

        public static void Remover(int copoId)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("DELETE FROM Copo WHERE id_copo = @id", conexao);
                comando.Parameters.AddWithValue("@id", copoId);
                comando.ExecuteNonQuery();
            }
        }

        public static List<Copo> ListarTodos()
        {
            var copos = new List<Copo>();
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("SELECT * FROM Copo", conexao);
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        var copo = new Copo
                        {
                            Id = leitor.GetInt32("id_copo"),
                            CapacidadeMl = leitor.GetInt32("capacidade_ml"),
                            Preco = leitor.GetDecimal("preco_unidade")
                        };
                        copos.Add(copo);
                    }
                }
            }
            return copos;
        }

        public static Copo BuscarPorId(int id)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("SELECT * FROM Copo WHERE id_copo = @id", conexao);
                comando.Parameters.AddWithValue("@id", id);
                using (var leitor = comando.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return new Copo
                        {
                            Id = leitor.GetInt32("id_copo"),
                            CapacidadeMl = leitor.GetInt32("capacidade_ml"),
                            Preco = leitor.GetDecimal("preco_unidade")
                        };
                    }
                    throw new Exception("Copo não encontrado.");  
                }
            }
        }
    }
}