using REVChopp.Models;
using REVChopp.Repositories;

namespace REVChopp.Services
{
    public class EstoqueService
    {
        public static void AdicionarProduto(ProdutoUnitario produto)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto), "Produto não pode ser nulo.");

            if (produto.QuantidadeEstoque < 0)
                throw new ArgumentException("Quantidade em estoque não pode ser negativa.", nameof(produto.QuantidadeEstoque));

            ProdutoUnitarioRepository.Inserir(produto);
        }

        public static void RemoverProduto(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID do produto deve ser maior que zero.", nameof(id));

            var produto = ProdutoUnitarioRepository.BuscarPorId(id);
            if (produto == null)
                throw new KeyNotFoundException($"Produto com ID {id} não encontrado.");

            ProdutoUnitarioRepository.Remover(produto);
        }

        public static void ListarProdutos()
        {
            var produtos = ProdutoUnitarioRepository.ListarTodos();
            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto encontrado.");
                return;
            }

            foreach (var produto in produtos)
            {
                Console.WriteLine($"{produto.Id} - {produto.Nome} - R${produto.Preco} - Estoque: {produto.QuantidadeEstoque}");
            }
        }

        public static ProdutoUnitario? BuscarProdutoPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID do produto deve ser maior que zero.", nameof(id));

            var produto = ProdutoUnitarioRepository.BuscarPorId(id);
            if (produto == null)
                Console.WriteLine($"Produto com ID {id} não encontrado.");
            return produto;
        }

        public static void AdicionarBarril(BarrilInstancia barril)
        {
            if (barril == null)
                throw new ArgumentNullException(nameof(barril), "Barril não pode ser nulo.");

            BarrilInstanciaRepository.Inserir(barril);
        }

        public static void RemoverBarril(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID do barril deve ser maior que zero.", nameof(id));

            var barril = BarrilInstanciaRepository.BuscarPorId(id);
            if (barril == null)
                throw new KeyNotFoundException($"Barril com ID {id} não encontrado.");

            BarrilInstanciaRepository.Remover(id);
        }

        public static List<BarrilInstancia> ListarBarris()
        {
            return BarrilInstanciaRepository.ListarTodos();
        }

        public static List<BarrilTipo> ListarTiposBarril()
        {
            return BarrilTipoRepository.ListarTodos();
        }

    }
}