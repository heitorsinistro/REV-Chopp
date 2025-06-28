using System;
using System.Windows.Forms;
using REVChopp.Services;

namespace REVChopp.UI
{
    public partial class BarrilTipoForm : Form
    {
        //private readonly EstoqueService _estoqueService;

        public BarrilTipoForm()
        {
            InitializeComponent();
            //_estoqueService = new EstoqueService();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();

            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Informe o nome do tipo de barril.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                EstoqueService.AdicionarTipoBarril(nome);
                MessageBox.Show("Tipo de barril cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
