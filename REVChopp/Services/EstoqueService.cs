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

            ProdutoUnitarioRepository.Adicionar(produto);
        }
    }
}