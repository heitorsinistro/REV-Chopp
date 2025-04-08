using REVChopp.Models;

namespace REVChopp.Services
{
    public class Estoque
    {
        private List<Produto> produtos = new List<Produto>();

        public Estoque()
        {
            produtos.Add(new Produto { Id = 1, Nome = "Chopp Pilsen", Preco = 10.0m, QuantidadeEstoque = 10 });
            produtos.Add(new Produto { Id = 2, Nome = "Chopp IPA", Preco = 12.0m, QuantidadeEstoque = 5 });
        }

        public void AdicionarProduto(Produto produto)
        {
            produtos.Add(produto);
            Console.WriteLine($"{produto.Nome} adicionado ao estoque.");
        }

        public bool RemoverProduto(int id, int quantidade)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto != null && produto.QuantidadeEstoque >= quantidade)
            {
                produto.QuantidadeEstoque -= quantidade;
                Console.WriteLine($"{quantidade} unidades de {produto.Nome} removidas do estoque.");
                return true;
            }
            Console.WriteLine("Produto não encontrado ou quantidade insuficiente.");
            return false;
        }

        public void ListarProdutos()
        {
            if (!produtos.Any())
            {
                Console.WriteLine("Estoque vazio.");
                return;
            }
            Console.WriteLine("Produtos no estoque:");
            foreach (var p in produtos)
            {
                Console.WriteLine($"{p.Id}. {p.Nome} - R${p.Preco} - {p.QuantidadeEstoque} unidades");
            }
        }

        public Produto? BuscarProduto(int id)
        {
            return produtos.FirstOrDefault(p => p.Id == id);
        }
    }
}