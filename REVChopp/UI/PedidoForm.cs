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

                if (int.TryParse(qtdInput, out int quantidade))
                {
                    pedidoService.AdicionarItemCopo(pedido, copo, quantidade);
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