using REVChopp.Models;

namespace REVChopp.Services
{
    public class Estoque
    {
        private List<ProdutoUnitario> produtos = new List<ProdutoUnitario>();
        private List<Barril> barris = new List<Barril>();

        public Estoque()
        {
            produtos.Add(new ProdutoUnitario { Id = 1, Nome = "Chopp Pilsen", Preco = 10.0m, QuantidadeEstoque = 10 });
            produtos.Add(new ProdutoUnitario { Id = 2, Nome = "Chopp IPA", Preco = 12.0m, QuantidadeEstoque = 5 });
        }

        public void AdicionarProduto(ProdutoUnitario produto)
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

        public void AdicionarBarril(Barril barril)
        {
            barris.Add(barril);
            Console.WriteLine($"{barril.Nome} adicionado ao estoque.");
        }

        public bool RemoverBarril(int id)
        {
            var barril = barris.FirstOrDefault(b => b.Id == id);
            if (barril != null)
            {
                barris.Remove(barril);
                Console.WriteLine($"{barril.Nome} removido do estoque.");
                return true;
            }
            Console.WriteLine("Barril não encontrado.");
            return false;
        }
        
        public bool ListarBarris()
        {
            if (!barris.Any())
            {
                Console.WriteLine("Estoque de barris vazio.");
                return false;
            }
            Console.WriteLine("Barris no estoque:");
            foreach (var b in barris)
            {
                Console.WriteLine($"{b.Id}. {b.Nome} - {b.VolumeTotalLitros}L - {b.VolumeRestanteMl}ml restantes - Tipo: {b.TipoCerveja}");
            }
            return true;
        }

        public ProdutoUnitario? BuscarProduto(int id)
        {
            return produtos.FirstOrDefault(p => p.Id == id);
        }
    }
}