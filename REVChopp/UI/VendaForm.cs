using System;
using System.Collections.Generic;
using System.Windows.Forms;
using REVChopp.Models;
using REVChopp.Services;
using REVChopp.Repositories;

namespace REVChopp.UI
{
    public partial class VendaForm : Form
    {
        private readonly VendaService vendaService;
        private readonly Usuario usuarioLogado;

        public VendaForm(Usuario usuario)
        {
            InitializeComponent();
            vendaService = new VendaService();
            usuarioLogado = usuario;
            CarregarPedidosPendentes();
        }

        private void CarregarPedidosPendentes()
        {
            var pedidos = PedidoRepository.BuscarPedidosAbertos();
            cmbPedidos.DisplayMember = "Descricao";
            cmbPedidos.ValueMember = "id_pedido";
            cmbPedidos.DataSource = pedidos;
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            if (cmbPedidos.SelectedItem is Pedido pedido)
            {
                try
                {
                    vendaService.RegistrarVenda(pedido.Id, usuarioLogado.Id);
                    MessageBox.Show("Venda registrada com sucesso!");
                    CarregarPedidosPendentes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao registrar venda: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Selecione um pedido.");
            }
        }

        private void cmbPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPedidos.SelectedItem is Pedido pedido)
            {
                lblMesa.Text = $"Mesa: {pedido.NumeroMesa}";
                lblTotal.Text = $"Total: R$ {pedido.ValorTotal:F2}";
            }
        }
    }
}
