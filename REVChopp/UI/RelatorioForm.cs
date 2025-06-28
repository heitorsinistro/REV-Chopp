using System;
using System.Windows.Forms;
using REVChopp.Services;

namespace REVChopp.UI
{
    public partial class RelatorioForm : Form
    {
        private readonly int _usuarioId;

        public RelatorioForm(int usuarioId)
        {
            InitializeComponent();
            _usuarioId = usuarioId;
        }

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            if (cmbTipoRelatorio.SelectedItem == null)
            {
                MessageBox.Show("Selecione o tipo de relatório.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tipo = cmbTipoRelatorio.SelectedItem?.ToString() ?? "";

            try
            {
                switch (tipo)
                {
                    case "Diário":
                        RelatorioService.GerarRelatorioDiario(_usuarioId);
                        break;
                    case "Semanal":
                        RelatorioService.GerarRelatorioSemanal(_usuarioId);
                        break;
                    case "Mensal":
                        RelatorioService.GerarRelatorioMensal(_usuarioId);
                        break;
                }

                MessageBox.Show($"Relatório {tipo.ToLower()} gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVisualizarRelatorios_Click(object sender, EventArgs e)
        {
            var viewer = new RelatorioViewerForm();
            this.Hide();
            viewer.ShowDialog();
            this.Show();
        }
    }
}
