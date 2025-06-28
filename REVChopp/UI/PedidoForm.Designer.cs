namespace REVChopp.UI
{
    partial class PedidoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMesa;
        private System.Windows.Forms.TextBox txtMesa;
        private System.Windows.Forms.Label lblPagamento;
        private System.Windows.Forms.ComboBox comboPagamento;
        private System.Windows.Forms.Button btnCriarPedido;
        private System.Windows.Forms.Button btnAdicionarProduto;
        private System.Windows.Forms.Button btnAdicionarCopo;
        private System.Windows.Forms.Button btnVisualizarPedido;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMesa = new System.Windows.Forms.Label();
            this.txtMesa = new System.Windows.Forms.TextBox();
            this.lblPagamento = new System.Windows.Forms.Label();
            this.comboPagamento = new System.Windows.Forms.ComboBox();
            this.btnCriarPedido = new System.Windows.Forms.Button();
            this.btnAdicionarProduto = new System.Windows.Forms.Button();
            this.btnAdicionarCopo = new System.Windows.Forms.Button();
            this.btnVisualizarPedido = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblMesa
            this.lblMesa.AutoSize = true;
            this.lblMesa.Location = new System.Drawing.Point(20, 20);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Size = new System.Drawing.Size(92, 15);
            this.lblMesa.Text = "Número da Mesa:";

            // txtMesa
            this.txtMesa.Location = new System.Drawing.Point(20, 40);
            this.txtMesa.Name = "txtMesa";
            this.txtMesa.Size = new System.Drawing.Size(200, 23);

            // lblPagamento
            this.lblPagamento.AutoSize = true;
            this.lblPagamento.Location = new System.Drawing.Point(20, 75);
            this.lblPagamento.Name = "lblPagamento";
            this.lblPagamento.Size = new System.Drawing.Size(110, 15);
            this.lblPagamento.Text = "Forma de Pagamento:";

            // comboPagamento
            this.comboPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPagamento.Location = new System.Drawing.Point(20, 95);
            this.comboPagamento.Name = "comboPagamento";
            this.comboPagamento.Size = new System.Drawing.Size(200, 23);

            // btnCriarPedido
            this.btnCriarPedido.Location = new System.Drawing.Point(20, 130);
            this.btnCriarPedido.Name = "btnCriarPedido";
            this.btnCriarPedido.Size = new System.Drawing.Size(200, 30);
            this.btnCriarPedido.Text = "Criar Pedido";
            this.btnCriarPedido.UseVisualStyleBackColor = true;
            this.btnCriarPedido.Click += new System.EventHandler(this.btnCriarPedido_Click);

            // btnAdicionarProduto
            this.btnAdicionarProduto.Location = new System.Drawing.Point(20, 170);
            this.btnAdicionarProduto.Name = "btnAdicionarProduto";
            this.btnAdicionarProduto.Size = new System.Drawing.Size(200, 30);
            this.btnAdicionarProduto.Text = "Adicionar Produto";
            this.btnAdicionarProduto.UseVisualStyleBackColor = true;
            this.btnAdicionarProduto.Click += new System.EventHandler(this.btnAdicionarProduto_Click);

            // btnAdicionarCopo
            this.btnAdicionarCopo.Location = new System.Drawing.Point(20, 210);
            this.btnAdicionarCopo.Name = "btnAdicionarCopo";
            this.btnAdicionarCopo.Size = new System.Drawing.Size(200, 30);
            this.btnAdicionarCopo.Text = "Adicionar Copo";
            this.btnAdicionarCopo.UseVisualStyleBackColor = true;
            this.btnAdicionarCopo.Click += new System.EventHandler(this.btnAdicionarCopo_Click);

            // btnVisualizarPedido
            this.btnVisualizarPedido.Location = new System.Drawing.Point(20, 250);
            this.btnVisualizarPedido.Name = "btnVisualizarPedido";
            this.btnVisualizarPedido.Size = new System.Drawing.Size(200, 30);
            this.btnVisualizarPedido.Text = "Visualizar Pedido";
            this.btnVisualizarPedido.UseVisualStyleBackColor = true;
            this.btnVisualizarPedido.Click += new System.EventHandler(this.btnVisualizarPedido_Click);

            // PedidoForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(250, 310);
            this.Controls.Add(this.lblMesa);
            this.Controls.Add(this.txtMesa);
            this.Controls.Add(this.lblPagamento);
            this.Controls.Add(this.comboPagamento);
            this.Controls.Add(this.btnCriarPedido);
            this.Controls.Add(this.btnAdicionarProduto);
            this.Controls.Add(this.btnAdicionarCopo);
            this.Controls.Add(this.btnVisualizarPedido);
            this.Name = "PedidoForm";
            this.Text = "Iniciar Pedido";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}