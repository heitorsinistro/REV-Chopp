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
            else
            {
                AdicionarBotaoGerenciarUsuarios();
            }
        }

        private void AdicionarBotaoGerenciarUsuarios()
        {
            Button btnUsuarios = new Button
            {
                Text = "Gerenciar Usuários",
                Width = 200,
                Height = 30,
                Left = 30,
                Top = btnRelatorios.Bottom + 10
            };

            btnUsuarios.Click += (s, e) =>
            {
                var usuarioForm = new UsuarioForm();
                usuarioForm.ShowDialog();
            };

            this.Controls.Add(btnUsuarios);
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            var estoque = new EstoqueForm(usuarioLogado);
            this.Hide();
            estoque.ShowDialog();
            this.Show();
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            var pedido = new PedidoForm(usuarioLogado);
            this.Hide();
            pedido.ShowDialog();
            this.Show();
        }

        private void btnVenda_Click(object sender, EventArgs e)
        {
            var venda = new VendaForm(usuarioLogado);
            this.Hide();
            venda.ShowDialog();
            this.Show();
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            var relatorio = new RelatorioForm(usuarioLogado.Id);
            this.Hide();
            relatorio.ShowDialog();
            this.Show();
        }
    }
}
