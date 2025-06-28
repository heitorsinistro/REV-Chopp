using System;
using System.Windows.Forms;
using REVChopp.Services;
using REVChopp.Models;
using REVChopp.Repositories;

namespace REVChopp.UI
{
    public partial class EstoqueForm : Form
    {
        private readonly EstoqueService estoqueService;

        public EstoqueForm(Usuario usuario)
        {
            InitializeComponent();
            estoqueService = new EstoqueService();
        }

        private void btnAddProduto_Click(object sender, EventArgs e)
        {
            using var form = new ProdutoForm();
            form.ShowDialog();
        }

        private void btnAddBarril_Click(object sender, EventArgs e)
        {
            using var form = new BarrilForm();
            form.ShowDialog();
        }

        private void btnListarProdutos_Click(object sender, EventArgs e)
        {
            var produtos = ProdutoUnitarioRepository.ListarTodos();
            dgvEstoque.Rows.Clear();

            foreach (var p in produtos)
            {
                dgvEstoque.Rows.Add(p.Id, p.Nome, p.Preco, p.QuantidadeEstoque);
            }
        }

        private void btnListarBarris_Click(object sender, EventArgs e)
        {
            var barris = EstoqueService.ListarBarris();
            dgvEstoque.Rows.Clear();
            foreach (var barril in barris)
            {
                var tipo = BarrilTipoRepository.ObterPorId(barril.BarrilTipoId);
                dgvEstoque.Rows.Add(
                    barril.Id,
                    tipo?.Nome ?? "",
                    tipo?.CapacidadeLitros ?? 0,
                    barril.VolumeRestanteMl,
                    tipo?.TipoCerveja ?? "",
                    barril.Status
                );
            }
        }
    }
}