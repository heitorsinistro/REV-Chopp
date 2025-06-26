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
                            Id = leitor.GetInt32("id_produto"),
                            Nome = leitor.GetString("nome"),
                            Preco = leitor.GetDecimal("preco"),
                            QuantidadeEstoque = leitor.GetInt32("quantidade_estoque")
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
                var comando = new MySqlCommand("SELECT * FROM ProdutoUnitario WHERE id_produto = @id", conexao);
                comando.Parameters.AddWithValue("@id", id);
                using (var leitor = comando.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return new ProdutoUnitario
                        {
                            Id = leitor.GetInt32("id_produto"),
                            Nome = leitor.GetString("nome"),
                            Preco = leitor.GetDecimal("preco"),
                            QuantidadeEstoque = leitor.GetInt32("quantidade_estoque")
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
                var comando = new MySqlCommand("DELETE FROM ProdutoUnitario WHERE id_produto = @id", conexao);
                comando.Parameters.AddWithValue("@id", produto.Id);
                comando.ExecuteNonQuery();
            }
        }

        public static void Inserir(ProdutoUnitario produto)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("INSERT INTO ProdutoUnitario (nome, preco, quantidade_estoque) VALUES (@nome, @preco, @quantidadeEstoque)", conexao);
                comando.Parameters.AddWithValue("@nome", produto.Nome);
                comando.Parameters.AddWithValue("@preco", produto.Preco);
                comando.Parameters.AddWithValue("@quantidadeEstoque", produto.QuantidadeEstoque);
                comando.ExecuteNonQuery();
            }
        }

        public static void DescontarEstoque(int produtoId, int quantidade)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand("UPDATE ProdutoUnitario SET quantidade_estoque = quantidade_estoque - @quantidade WHERE id_produto = @id", conexao);
                comando.Parameters.AddWithValue("@quantidade", quantidade);
                comando.Parameters.AddWithValue("@id", produtoId);
                comando.ExecuteNonQuery();
            }
        }
    }
}