using System;
using REVChopp.Models;

namespace REVChopp.Services
{
    public class VendaService
    {
        private Venda venda = new Venda();
        private Estoque estoque;

        public VendaService(Estoque estoque)
        {
            this.estoque = estoque;
        }

        public void MenuVendas()
        {
            while (true)
            {
                Console.WriteLine("\n1. Adicionar item ao pedido");
                Console.WriteLine("2. Finalizar pedido");
                Console.WriteLine("3. Voltar");
                Console.Write("Opção: ");
                string? opcao = Console.ReadLine();

                if (opcao == "1") AdicionarItem();
                else if (opcao == "2") FinalizarPedido();
                else if (opcao == "3") break;
                else Console.WriteLine("Opção inválida.");
            }
        }

        private void AdicionarItem()
        {
            estoque.ListarProdutos();
            Console.Write("ID do produto: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var produto = estoque.BuscarProduto(id);
                if (produto != null)
                {
                    venda.AdicionarProduto(produto);
                    estoque.RemoverProduto(id);
                    Console.WriteLine($"{produto.Nome} adicionado ao pedido.");
                }
                else Console.WriteLine("Produto não encontrado.");
            }
        }

        private void FinalizarPedido()
        {
            if (venda.Itens.Count == 0)
            {
                Console.WriteLine("Nenhum item no pedido.");
                return;
            }

            Console.WriteLine("Pedido finalizado. Itens:");
            foreach (var item in venda.Itens)
            {
                Console.WriteLine($"- {item.Nome}: R${item.Preco}");
            }
            Console.WriteLine($"Total: R${venda.CalcularTotal()}");
            venda.LimparPedido();
        }
    }
}