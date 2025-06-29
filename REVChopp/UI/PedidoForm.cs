using System;
using System.Windows.Forms;
using REVChopp.Models;
using REVChopp.Services;
using REVChopp.Repositories;

namespace REVChopp.UI
{
    public partial class PedidoForm : Form
    {
        private readonly Usuario usuarioLogado;
        private readonly PedidoService pedidoService;
        private int pedidoId = 0;
        public PedidoForm(Usuario usuario)
        {
            InitializeComponent();
            usuarioLogado = usuario;
            pedidoService = new PedidoService();

            comboPagamento.Items.AddRange(new object[] { "Dinheiro", "Cartão", "Pix" });
            comboPagamento.SelectedIndex = 0;
        }
        private void btnCriarPedido_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMesa.Text, out int numeroMesa))
            {
                MessageBox.Show("Número da mesa inválido.");
                return;
            }

            if (comboPagamento.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma forma de pagamento.");
                return;
            }

            string formaPag = comboPagamento.SelectedItem.ToString()!;
            pedidoId = pedidoService.CriarPedido(usuarioLogado.Id, numeroMesa, formaPag).Id;

            MessageBox.Show($"Pedido criado com ID {pedidoId}.");
        }

        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            if (pedidoId == 0)
            {
                MessageBox.Show("Crie o pedido primeiro.");
                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox("ID do Produto:", "Adicionar Produto");
            if (int.TryParse(input, out int produtoId))
            {
                string qtdInput = Microsoft.VisualBasic.Interaction.InputBox("Quantidade:", "Quantidade do Produto");

                var pedido = PedidoRepository.BuscarPorId(pedidoId);
                var produto = ProdutoUnitarioRepository.BuscarPorId(produtoId);

                if (pedido == null || produto == null)
                {
                    MessageBox.Show("Pedido ou produto não encontrado.");
                    return;
                }

                if (int.TryParse(qtdInput, out int quantidade))
                {
                    if (produto.QuantidadeEstoque < quantidade)
                    {
                        MessageBox.Show("Estoque insuficiente para esse produto.", "Estoque insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    pedidoService.AdicionarItemProduto(pedido, produto, quantidade);
                    MessageBox.Show("Produto adicionado ao pedido.");
                }
            }
        }

        private void btnAdicionarCopo_Click(object sender, EventArgs e)
        {
            if (pedidoId == 0)
            {
                MessageBox.Show("Crie o pedido primeiro.");
                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox("ID do Copo:", "Adicionar Copo");
            if (int.TryParse(input, out int copoId))
            {
                string qtdInput = Microsoft.VisualBasic.Interaction.InputBox("Quantidade:", "Quantidade de Copos");
                var pedido = PedidoRepository.BuscarPorId(pedidoId);
                var copo = CopoRepository.BuscarPorId(copoId);

                if (pedido == null || copo == null)
                {
                    MessageBox.Show("Pedido ou copo não encontrado.");
                    return;
                }

                // novo: perguntar o tipo de cerveja
                var barrisDisponiveis = BarrilInstanciaRepository.ListarDisponiveis()
                    .Where(b => b.VolumeRestanteMl >= copo.CapacidadeMl * Convert.ToInt32(qtdInput))
                    .ToList();

                if (barrisDisponiveis.Count == 0)
                {
                    MessageBox.Show("Nenhum barril disponível com volume suficiente.");
                    return;
                }

                string msg = "Escolha o barril:\n";
                foreach (var b in barrisDisponiveis)
                {
                    var tipo = BarrilTipoRepository.ObterPorId(b.BarrilTipoId);
                    msg += $"{b.Id} - {tipo?.Nome ?? "?"} ({tipo?.TipoCerveja ?? "?"}) - {b.VolumeRestanteMl}ml restantes\n";
                }
                string barrilInput = Microsoft.VisualBasic.Interaction.InputBox(msg, "Escolha o Barril");

                if (!int.TryParse(barrilInput, out int barrilId) || barrisDisponiveis.All(b => b.Id != barrilId))
                {
                    MessageBox.Show("Barril inválido.");
                    return;
                }

                if (int.TryParse(qtdInput, out int quantidade))
                {
                    pedidoService.AdicionarItemCopo(pedido, copo, quantidade, barrilId);
                    MessageBox.Show("Copo adicionado ao pedido.");
                }
            }
        }

        private void btnVisualizarPedido_Click(object sender, EventArgs e)
        {
            if (pedidoId == 0)
            {
                MessageBox.Show("Crie o pedido primeiro.");
                return;
            }

            var itens = PedidoRepository.ObterItensDoPedido(pedidoId);
            if (itens.Count == 0)
            {
                MessageBox.Show("Nenhum item no pedido ainda.");
                return;
            }

            string resumo = "Itens do Pedido:\n";
            foreach (var item in itens)
            {
                resumo += $"- {item.Quantidade}x {item.NomeExibido} = R$ {item.TotalItem:F2}\n";
            }

            MessageBox.Show(resumo);
        }
    }
}