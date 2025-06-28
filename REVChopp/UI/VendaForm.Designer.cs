namespace REVChopp.UI
{
    partial class VendaForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblIdPedido;
        private System.Windows.Forms.TextBox txtIdPedido;
        private System.Windows.Forms.Button btnFinalizarVenda;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblIdPedido = new System.Windows.Forms.Label();
            this.txtIdPedido = new System.Windows.Forms.TextBox();
            this.btnFinalizarVenda = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblIdPedido
            this.lblIdPedido.AutoSize = true;
            this.lblIdPedido.Location = new System.Drawing.Point(20, 20);
            this.lblIdPedido.Name = "lblIdPedido";
            this.lblIdPedido.Size = new System.Drawing.Size(112, 15);
            this.lblIdPedido.Text = "ID do Pedido (aberto):";

            // txtIdPedido
            this.txtIdPedido.Location = new System.Drawing.Point(20, 40);
            this.txtIdPedido.Name = "txtIdPedido";
            this.txtIdPedido.Size = new System.Drawing.Size(200, 23);

            // btnFinalizarVenda
            this.btnFinalizarVenda.Location = new System.Drawing.Point(20, 80);
            this.btnFinalizarVenda.Name = "btnFinalizarVenda";
            this.btnFinalizarVenda.Size = new System.Drawing.Size(200, 30);
            this.btnFinalizarVenda.Text = "Finalizar Venda";
            this.btnFinalizarVenda.UseVisualStyleBackColor = true;
            this.btnFinalizarVenda.Click += new System.EventHandler(this.btnFinalizarVenda_Click);

            // VendaForm
            this.ClientSize = new System.Drawing.Size(250, 130);
            this.Controls.Add(this.lblIdPedido);
            this.Controls.Add(this.txtIdPedido);
            this.Controls.Add(this.btnFinalizarVenda);
            this.Name = "VendaForm";
            this.Text = "Finalizar Venda";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}