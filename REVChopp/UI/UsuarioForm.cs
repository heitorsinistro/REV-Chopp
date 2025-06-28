using System;
using System.Windows.Forms;
using REVChopp.Models;
using REVChopp.Repositories;

namespace REVChopp.UI
{
    public partial class UsuarioForm : Form
    {
        private Usuario usuario;

        public UsuarioForm(Usuario? usuarioExistente = null)
        {
            InitializeComponent();
            usuario = usuarioExistente ?? new Usuario();

            if (usuarioExistente != null)
            {
                txtNome.Text = usuarioExistente.Nome;
                txtSenha.Text = usuarioExistente.Senha;
                cmbNivelAcesso.SelectedItem = usuarioExistente.NivelAcesso;
            }
            else
            {
                cmbNivelAcesso.SelectedIndex = 0;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            usuario.Nome = txtNome.Text.Trim();
            usuario.Senha = txtSenha.Text;
            usuario.NivelAcesso = cmbNivelAcesso.SelectedItem?.ToString() ?? "Atendente";

            try
            {
                if (usuario.Id > 0)
                    UsuarioRepository.Atualizar(usuario);
                else
                    UsuarioRepository.Inserir(usuario);

                MessageBox.Show("Usuário salvo com sucesso!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar usuário: {ex.Message}");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
