using REVChopp.Models;
using REVChopp.Repositories;

namespace REVChopp.Services
{
    public class VendaService
    {
        public void RegistrarVenda(int pedidoId, int usuarioId)
        {
            var pedido = PedidoRepository.BuscarPorId(pedidoId);

            if (pedido == null)
            {
                throw new Exception("Pedido não encontrado.");
            }

            var venda = new Venda
            {
                PedidoId = pedidoId,
                UsuarioId = usuarioId,
                DataHora = DateTime.Now
            };
            int vendaId = VendaRepository.RegistrarVenda(venda);
            venda.Id = vendaId;

            var itens = ItensPedidoRepository.ListarPorPedido(pedidoId);
            foreach (var item in itens)
            {
                if (item.TipoItem == "produto" && item.ProdutoId.HasValue)
                {
                    ProdutoUnitarioRepository.DescontarEstoque(item.ProdutoId.Value, item.Quantidade);
                }
                else if (item.TipoItem == "copo" && item.CopoId.HasValue && item.BarrilId.HasValue)
                {
                    var copo = CopoRepository.BuscarPorId(item.CopoId.Value);
                    int totalMl = copo.CapacidadeMl * item.Quantidade;
                    ConsumoBarrilRepository.RegistrarConsumo(venda.Id, item.BarrilId.Value, totalMl);
                }
            }
            
            Console.WriteLine($"Venda registrada com sucesso! Pedido ID: {pedidoId}, Usuário ID: {usuarioId}, Data/Hora: {venda.DataHora}");
        }
    }
}