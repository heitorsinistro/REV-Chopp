using System.Windows.Forms;
using REVChopp.Repositories;

namespace REVChopp.UI
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblUsuario;
        private TextBox txtNome;
        private Label lblSenha;
        private TextBox txtSenha;
        private Label lblNivel;
        private ComboBox comboNivel;
        private Button btnLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblUsuario = new Label();
            this.txtNome = new TextBox();
            this.lblSenha = new Label();
            this.txtSenha = new TextBox();
            this.lblNivel = new Label();
            this.comboNivel = new ComboBox();
            this.btnLogin = new Button();
            this.SuspendLayout();

            // lblUsuario
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(30, 30);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(100, 15);
            this.lblUsuario.Text = "Nome de usuário:";

            // txtNome
            this.txtNome.Location = new System.Drawing.Point(30, 50);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(200, 23);

            // lblSenha
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(30, 85);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(42, 15);
            this.lblSenha.Text = "Senha:";

            // txtSenha
            this.txtSenha.Location = new System.Drawing.Point(30, 105);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(200, 23);

            // lblNivel
            this.lblNivel.AutoSize = true;
            this.lblNivel.Location = new System.Drawing.Point(30, 140);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(82, 15);
            this.lblNivel.Text = "Nível de acesso:";

            // comboNivel
            this.comboNivel.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboNivel.Location = new System.Drawing.Point(30, 160);
            this.comboNivel.Name = "comboNivel";
            this.comboNivel.Size = new System.Drawing.Size(200, 23);

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(30, 200);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(200, 30);
            this.btnLogin.Text = "Entrar";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // LoginForm
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(270, 260);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblNivel);
            this.Controls.Add(this.comboNivel);
            this.Controls.Add(this.btnLogin);
            this.Name = "LoginForm";
            this.Text = "Login - REVChopp";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}