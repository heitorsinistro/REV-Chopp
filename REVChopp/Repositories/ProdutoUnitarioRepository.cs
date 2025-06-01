using MySql.Data.MySqlClient;
using REVChopp.Core;
using REVChopp.Models;

namespace REVChopp.Repositories
{
    public class ProdutoUnitarioRepository
    {
        public static List<ProdutoUnitario> ListarTodos()
        {
            var produtos = new List<ProdutoUnitario>();
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("SELECT * FROM ProdutoUnitario", conexao);
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        var produto = new ProdutoUnitario
                        {
                            Id = leitor.GetInt32("Id"),
                            Nome = leitor.GetString("Nome"),
                            Preco = leitor.GetDecimal("Preco"),
                            QuantidadeEstoque = leitor.GetInt32("QuantidadeEstoque")
                        };
                        produtos.Add(produto);
                    }
                }
            }
            return produtos;
        }

        public static ProdutoUnitario? BuscarPorId(int id)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("SELECT * FROM ProdutoUnitario WHERE Id = @id", conexao);
                comando.Parameters.AddWithValue("@id", id);
                using (var leitor = comando.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return new ProdutoUnitario
                        {
                            Id = leitor.GetInt32("Id"),
                            Nome = leitor.GetString("Nome"),
                            Preco = leitor.GetDecimal("Preco"),
                            QuantidadeEstoque = leitor.GetInt32("QuantidadeEstoque")
                        };
                    }
                }
            }
            return null;
        }

        public static void Remover(ProdutoUnitario produto)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("DELETE FROM ProdutoUnitario WHERE Id = @id", conexao);
                comando.Parameters.AddWithValue("@id", produto.Id);
                comando.ExecuteNonQuery();
            }
        }

        public static void Adicionar(ProdutoUnitario produto)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("INSERT INTO ProdutoUnitario (Nome, Preco, QuantidadeEstoque) VALUES (@nome, @preco, @quantidadeEstoque)", conexao);
                comando.Parameters.AddWithValue("@nome", produto.Nome);
                comando.Parameters.AddWithValue("@preco", produto.Preco);
                comando.Parameters.AddWithValue("@quantidadeEstoque", produto.QuantidadeEstoque);
                comando.ExecuteNonQuery();
            }
        }
    }
}