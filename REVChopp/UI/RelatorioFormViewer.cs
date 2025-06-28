using System;
using System.Collections.Generic;
using System.Windows.Forms;
using REVChopp.Models;
using REVChopp.Repositories;

namespace REVChopp.UI
{
    public partial class RelatorioViewerForm : Form
    {
        public RelatorioViewerForm()
        {
            InitializeComponent();
            CarregarRelatorios();
        }

        private void CarregarRelatorios()
        {
            var relatorios = RelatorioRepository.BuscarTodos();
            lstRelatorios.DisplayMember = "Descricao";
            lstRelatorios.ValueMember = "Id";
            lstRelatorios.DataSource = relatorios;
        }

        private void lstRelatorios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRelatorios.SelectedItem is Relatorio relatorio)
            {
                dgvItens.DataSource = RelatorioItensRepository.BuscarPorRelatorio(relatorio.Id);
                dgvCopos.DataSource = RelatorioCoposRepository.BuscarPorRelatorio(relatorio.Id);
                dgvBarris.DataSource = RelatorioBarrisRepository.BuscarPorRelatorio(relatorio.Id);

                lblDataInicio.Text = $"Data de Início: {relatorio.DataInicio:dd/MM/yyyy HH:mm}";
                lblDataFim.Text = $"Data de Fim: {relatorio.DataFim:dd/MM/yyyy HH:mm}";
            }
        }
    }
}
