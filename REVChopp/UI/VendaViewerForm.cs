using System;
using System.Collections.Generic;
using System.Windows.Forms;
using REVChopp.Models;
using REVChopp.Repositories;

namespace REVChopp.UI
{
    public partial class VendaViewerForm : Form
    {
        public VendaViewerForm()
        {
            InitializeComponent();
            CarregarVendas();
        }

        private void CarregarVendas()
        {
            DateTime? inicio = dtInicio.Checked ? dtInicio.Value.Date : null;
            DateTime? fim = dtFim.Checked ? dtFim.Value.Date.AddDays(1).AddTicks(-1) : null;

            int.TryParse(txtMesa.Text, out int mesa);
            string formaPagamento = txtFormaPagamento.Text.Trim();

            List<Pedido> vendas = VendaRepository.BuscarVendas(inicio, fim, mesa, formaPagamento);
            dgvVendas.DataSource = vendas;

            // Opcional: renomear colunas
            var colId = dgvVendas.Columns["Id"];
            if (colId != null) colId.HeaderText = "Pedido ID";

            var colMesa = dgvVendas.Columns["NumeroMesa"];
            if (colMesa != null) colMesa.HeaderText = "Mesa";

            var colTotal = dgvVendas.Columns["ValorTotal"];
            if (colTotal != null) colTotal.HeaderText = "Total (R$)";

            var colPagamento = dgvVendas.Columns["FormaPagamento"];
            if (colPagamento != null) colPagamento.HeaderText = "Pagamento";

            var colAtendente = dgvVendas.Columns["Atendente"];
            if (colAtendente != null) colAtendente.HeaderText = "Atendente";

            var colDataVenda = dgvVendas.Columns["DataVenda"];
            if (colDataVenda != null) colDataVenda.HeaderText = "Data da Venda";

            // Ocultar colunas não relevantes
            var colUsuarioId = dgvVendas.Columns["UsuarioId"];
            if (colUsuarioId != null) colUsuarioId.Visible = false;

            var colDataHora = dgvVendas.Columns["DataHora"];
            if (colDataHora != null) colDataHora.Visible = false;

            var colDescricao = dgvVendas.Columns["Descricao"];
            if (colDescricao != null) colDescricao.Visible = false;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CarregarVendas();
        }
    }
}
