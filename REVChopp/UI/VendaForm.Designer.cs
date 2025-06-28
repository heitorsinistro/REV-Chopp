namespace REVChopp.UI
{
    partial class VendaForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbPedidos = new System.Windows.Forms.ComboBox();
            this.btnFinalizarVenda = new System.Windows.Forms.Button();
            this.lblMesa = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // cmbPedidos
            this.cmbPedidos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPedidos.Location = new System.Drawing.Point(20, 20);
            this.cmbPedidos.Size = new System.Drawing.Size(250, 23);
            this.cmbPedidos.SelectedIndexChanged += new System.EventHandler(this.cmbPedidos_SelectedIndexChanged);

            // lblMesa
            this.lblMesa.Location = new System.Drawing.Point(20, 50);
            this.lblMesa.Size = new System.Drawing.Size(250, 20);
            this.lblMesa.Text = "Mesa:";

            // lblTotal
            this.lblTotal.Location = new System.Drawing.Point(20, 70);
            this.lblTotal.Size = new System.Drawing.Size(250, 20);
            this.lblTotal.Text = "Total:";

            // btnFinalizarVenda
            this.btnFinalizarVenda.Location = new System.Drawing.Point(20, 110);
            this.btnFinalizarVenda.Size = new System.Drawing.Size(250, 30);
            this.btnFinalizarVenda.Text = "Finalizar Venda";
            this.btnFinalizarVenda.Click += new System.EventHandler(this.btnFinalizarVenda_Click);

            // VendaForm
            this.ClientSize = new System.Drawing.Size(300, 170);
            this.Controls.Add(this.cmbPedidos);
            this.Controls.Add(this.lblMesa);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnFinalizarVenda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "VendaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar Venda";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ComboBox cmbPedidos;
        private System.Windows.Forms.Button btnFinalizarVenda;
        private System.Windows.Forms.Label lblMesa;
        private System.Windows.Forms.Label lblTotal;
    }
}
