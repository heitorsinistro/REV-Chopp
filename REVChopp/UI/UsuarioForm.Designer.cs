namespace REVChopp.UI
{
    partial class UsuarioForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.cmbNivelAcesso = new System.Windows.Forms.ComboBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.lblNivel = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // txtNome
            this.txtNome.Location = new System.Drawing.Point(20, 30);
            this.txtNome.Size = new System.Drawing.Size(260, 23);

            // txtSenha
            this.txtSenha.Location = new System.Drawing.Point(20, 80);
            this.txtSenha.Size = new System.Drawing.Size(260, 23);
            this.txtSenha.PasswordChar = '●';

            // cmbNivelAcesso
            this.cmbNivelAcesso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNivelAcesso.Items.AddRange(new object[] { "funcionario", "admin" });
            this.cmbNivelAcesso.Location = new System.Drawing.Point(20, 130);
            this.cmbNivelAcesso.Size = new System.Drawing.Size(260, 23);

            // Labels
            this.lblNome.Text = "Nome:";
            this.lblNome.Location = new System.Drawing.Point(20, 10);

            this.lblSenha.Text = "Senha:";
            this.lblSenha.Location = new System.Drawing.Point(20, 60);

            this.lblNivel.Text = "Nível de Acesso:";
            this.lblNivel.Location = new System.Drawing.Point(20, 110);

            // btnSalvar
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Location = new System.Drawing.Point(20, 180);
            this.btnSalvar.Size = new System.Drawing.Size(100, 30);
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            // btnCancelar
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(180, 180);
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // UsuarioForm
            this.ClientSize = new System.Drawing.Size(300, 230);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.cmbNivelAcesso);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.lblNivel);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UsuarioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Usuário";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.ComboBox cmbNivelAcesso;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
