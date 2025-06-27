using System;
using System.Windows.Forms;
using REVChopp.Models;

namespace REVChopp.UI
{
    public partial class MenuPrincipalForm : Form
    {
        private Usuario usuarioLogado;

        public MenuPrincipalForm(Usuario usuario)
        {
            InitializeComponent();
            usuarioLogado = usuario;
            lblUsuario.Text = $"Bem-vindo, {usuario.Nome} ({usuario.NivelAcesso})";

            if (usuario.NivelAcesso != "admin")
            {
                btnRelatorios.Enabled = false;
            }
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Abrir gerenciamento de estoque...");
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Abrir tela de pedido...");
        }

        private void btnVenda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Abrir tela de finalização de venda...");
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Abrir geração de relatórios...");
        }
    }
}