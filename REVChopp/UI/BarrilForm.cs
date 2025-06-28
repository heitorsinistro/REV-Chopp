using System;
using System.Windows.Forms;
using REVChopp.Services;
using REVChopp.Models;

namespace REVChopp.UI
{
    public partial class BarrilForm : Form
    {
        //private readonly EstoqueService _estoqueService;

        public BarrilForm()
        {
            InitializeComponent();
            //_estoqueService = new EstoqueService();
            CarregarTiposDeBarril();
        }

        private void CarregarTiposDeBarril()
        {
            var tipos = EstoqueService.ListarTiposBarril();
            cmbTipo.DataSource = tipos;
            cmbTipo.DisplayMember = "Nome";
            cmbTipo.ValueMember = "Id";
        }

        private void btnNovoTipo_Click(object sender, EventArgs e)
        {
            using (var tipoForm = new BarrilTipoForm())
            {
                if (tipoForm.ShowDialog() == DialogResult.OK)
                {
                    CarregarTiposDeBarril();
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedItem is BarrilTipo tipoSelecionado && nudLitros.Value > 0)
            {
                var novoBarril = new BarrilInstancia
                {
                    BarrilTipoId = tipoSelecionado.Id,
                    VolumeRestanteMl = (int)(nudLitros.Value * 1000), // converte litros para ml
                    Status = "Disponível", // ou outro status padrão
                    DataAbertura = null,
                    DataValidade = null
                };

                EstoqueService.AdicionarBarril(novoBarril);
                MessageBox.Show("Barril cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecione um tipo e informe a quantidade de litros.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
