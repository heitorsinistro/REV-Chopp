namespace REVChopp.UI
{
    partial class ProdutoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Button btnSalvar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblPreco = new System.Windows.Forms.Label();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblNome
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(20, 20);
            this.lblNome.Text = "Nome:";

            // txtNome
            this.txtNome.Location = new System.Drawing.Point(20, 40);
            this.txtNome.Size = new System.Drawing.Size(200, 23);

            // lblPreco
            this.lblPreco.AutoSize = true;
            this.lblPreco.Location = new System.Drawing.Point(20, 75);
            this.lblPreco.Text = "Preço:";

            // txtPreco
            this.txtPreco.Location = new System.Drawing.Point(20, 95);
            this.txtPreco.Size = new System.Drawing.Size(200, 23);

            // lblQuantidade
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(20, 130);
            this.lblQuantidade.Text = "Quantidade:";

            // txtQuantidade
            this.txtQuantidade.Location = new System.Drawing.Point(20, 150);
            this.txtQuantidade.Size = new System.Drawing.Size(200, 23);

            // btnSalvar
            this.btnSalvar.Location = new System.Drawing.Point(20, 190);
            this.btnSalvar.Size = new System.Drawing.Size(200, 30);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            // ProdutoForm
            this.ClientSize = new System.Drawing.Size(250, 250);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblPreco);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.btnSalvar);
            this.Name = "ProdutoForm";
            this.Text = "Cadastro de Produto";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
