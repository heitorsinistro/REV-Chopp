using System;
using System.Windows.Forms;
using REVChopp.Repositories;
using REVChopp.Models;

namespace REVChopp.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            comboNivel.Items.Add("admin");
            comboNivel.Items.Add("funcionario");
            comboNivel.SelectedIndex = 0;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string senha = txtSenha.Text.Trim();
            string nivel = comboNivel.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            var usuario = UsuarioRepository.Autenticar(nome, senha, nivel);

            if (usuario != null)
            {
                MessageBox.Show($"Bem-vindo, {usuario.Nome} ({usuario.NivelAcesso})");

                // Aqui você pode abrir o MenuPrincipal ou MainForm
                var menu = new MenuPrincipalForm(usuario);
                this.Hide();
                menu.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("⚠ Credenciais inválidas.");
            }
        }
    }
}