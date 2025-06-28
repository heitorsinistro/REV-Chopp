using System;
using System.Windows.Forms;
using REVChopp.Models;
using REVChopp.Services;

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
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdPedido.Text, out int pedidoId))
            {
                MessageBox.Show("ID do pedido inválido.");
                return;
            }

            try
            {
                vendaService.RegistrarVenda(pedidoId, usuarioLogado.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registrar venda: {ex.Message}");
            }
        }
    }
}