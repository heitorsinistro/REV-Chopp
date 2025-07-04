using REVChopp.Models;
using REVChopp.Repositories;

namespace REVChopp.Services
{
    public class PedidoService
    {
        public Pedido CriarPedido(int usuarioId, int numeroMesa, string formaPagamento)
        {
            if (usuarioId <= 0 || numeroMesa <= 0 || string.IsNullOrEmpty(formaPagamento))
            {
                throw new ArgumentException("Parâmetros inválidos para criar o pedido.");
            }

            Pedido novoPedido = new Pedido
            {
                UsuarioId = usuarioId,
                NumeroMesa = numeroMesa,
                DataHora = DateTime.Now,
                FormaPagamento = formaPagamento,
                ValorTotal = 0
            };

            int pedidoId = PedidoRepository.Inserir(novoPedido);
            novoPedido.Id = pedidoId;

            return novoPedido;
        }

        public void AdicionarItemProduto(Pedido pedido, ProdutoUnitario produto, int quantidade)
        {
            var item = new ItensPedido
            {
                PedidoId = pedido.Id,
                ProdutoId = produto.Id,
                TipoItem = "produto",
                NomeItem = produto.Nome,
                Quantidade = quantidade,
                PrecoUnitario = produto.Preco,
                Subtotal = produto.Preco * quantidade
            };

            ItensPedidoRepository.Inserir(item);
            pedido.ValorTotal += item.Subtotal;
            PedidoRepository.AtualizarValorTotal(pedido.Id, pedido.ValorTotal);
        }

        public void AdicionarItemCopo(Pedido pedido, Copo copo, int quantidade, int barrilId)
        {
            var item = new ItensPedido
            {
                PedidoId = pedido.Id,
                CopoId = copo.Id,
                TipoItem = "copo",
                NomeItem = $"{copo.CapacidadeMl}ml",
                Quantidade = quantidade,
                PrecoUnitario = copo.Preco,
                Subtotal = copo.Preco * quantidade,
                BarrilId = barrilId
            };

            ItensPedidoRepository.Inserir(item);
            pedido.ValorTotal += item.Subtotal;
            PedidoRepository.AtualizarValorTotal(pedido.Id, pedido.ValorTotal);

            //tirar se necessario vv
            int totalMl = quantidade * copo.CapacidadeMl;

            var barril = BarrilInstanciaRepository.BuscarPorId(barrilId);

            if (barril == null || barril.VolumeRestanteMl < totalMl)
            {
                throw new Exception("Barril selecionado não existe ou não possui volume suficiente.");
            }
            //ConsumoBarrilRepository.RegistrarConsumo(pedido.Id, barril.Id, totalMl);
        }

        public void FinalizarPedido(Pedido pedido)
        {
            if (pedido == null || pedido.Id <= 0)
            {
                throw new ArgumentException("Pedido inválido para finalizar.");
            }

            VendaRepository.RegistrarVenda(new Venda
            {
                PedidoId = pedido.Id,
                UsuarioId = pedido.UsuarioId,
                DataHora = DateTime.Now
            });

            Console.WriteLine($"Pedido {pedido.Id} finalizado. Total: R${pedido.ValorTotal:F2}");
        }

        
    }
}