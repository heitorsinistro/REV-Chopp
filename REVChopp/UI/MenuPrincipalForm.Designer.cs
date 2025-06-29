namespace REVChopp.UI
{
    partial class MenuPrincipalForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnEstoque;
        private System.Windows.Forms.Button btnPedido;
        private System.Windows.Forms.Button btnVenda;
        private System.Windows.Forms.Button btnRelatorios;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnEstoque = new System.Windows.Forms.Button();
            this.btnPedido = new System.Windows.Forms.Button();
            this.btnVenda = new System.Windows.Forms.Button();
            this.btnRelatorios = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblUsuario
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(30, 20);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(95, 15);
            this.lblUsuario.Text = "Bem-vindo: nome";

            // btnEstoque
            this.btnEstoque.Location = new System.Drawing.Point(30, 50);
            this.btnEstoque.Name = "btnEstoque";
            this.btnEstoque.Size = new System.Drawing.Size(200, 30);
            this.btnEstoque.Text = "Gerenciar Estoque";
            this.btnEstoque.Click += new System.EventHandler(this.btnEstoque_Click);

            // btnPedido
            this.btnPedido.Location = new System.Drawing.Point(30, 90);
            this.btnPedido.Name = "btnPedido";
            this.btnPedido.Size = new System.Drawing.Size(200, 30);
            this.btnPedido.Text = "Iniciar Pedido";
            this.btnPedido.Click += new System.EventHandler(this.btnPedido_Click);

            // btnVenda
            this.btnVenda.Location = new System.Drawing.Point(30, 130);
            this.btnVenda.Name = "btnVenda";
            this.btnVenda.Size = new System.Drawing.Size(200, 30);
            this.btnVenda.Text = "Finalizar Venda";
            this.btnVenda.Click += new System.EventHandler(this.btnVenda_Click);

            // btnRelatorios
            this.btnRelatorios.Location = new System.Drawing.Point(30, 170);
            this.btnRelatorios.Name = "btnRelatorios";
            this.btnRelatorios.Size = new System.Drawing.Size(200, 30);
            this.btnRelatorios.Text = "Gerar Relatórios";
            this.btnRelatorios.Click += new System.EventHandler(this.btnRelatorios_Click);

            // MenuPrincipalForm
            this.ClientSize = new System.Drawing.Size(270, 270);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnEstoque);
            this.Controls.Add(this.btnPedido);
            this.Controls.Add(this.btnVenda);
            this.Controls.Add(this.btnRelatorios);
            this.Name = "MenuPrincipalForm";
            this.Text = "REVChopp - Menu Principal";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}