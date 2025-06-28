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
            VendaRepository.RegistrarVenda(venda);

            var itens = ItensPedidoRepository.ListarPorPedido(pedidoId);
            foreach (var item in itens)
            {
                if (item.TipoItem == "copo" && item.CopoId.HasValue)
                {
                    // Buscar o copo para saber capacidade  
                    var copo = CopoRepository.BuscarPorId(item.CopoId.Value);
                    int totalMl = copo.CapacidadeMl * item.Quantidade;

                    // Buscar o primeiro barril disponível com volume suficiente  
                    var barris = BarrilInstanciaRepository.ListarDisponiveis();
                    var barril = barris.Find(b => b.VolumeRestanteMl >= totalMl);

                    if (barril == null)
                    {
                        Console.WriteLine("⚠ Nenhum barril disponível com volume suficiente.");
                        continue;
                    }

                    // Registrar consumo  
                    ConsumoBarrilRepository.RegistrarConsumo(venda.Id, barril.Id, totalMl);
                }
                else if (item.TipoItem == "produto" && item.ProdutoId.HasValue)
                {
                    // Atualizar estoque do produto (subtrair)  
                    ProdutoUnitarioRepository.DescontarEstoque(item.ProdutoId.Value, item.Quantidade);
                }
            }
            
            Console.WriteLine($"Venda registrada com sucesso! Pedido ID: {pedidoId}, Usuário ID: {usuarioId}, Data/Hora: {venda.DataHora}");
        }
    }
}