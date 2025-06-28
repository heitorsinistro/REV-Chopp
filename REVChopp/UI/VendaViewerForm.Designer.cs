namespace REVChopp.UI
{
    partial class VendaViewerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvVendas = new System.Windows.Forms.DataGridView();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.dtFim = new System.Windows.Forms.DateTimePicker();
            this.txtMesa = new System.Windows.Forms.TextBox();
            this.txtFormaPagamento = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.lblInicio = new System.Windows.Forms.Label();
            this.lblFim = new System.Windows.Forms.Label();
            this.lblMesa = new System.Windows.Forms.Label();
            this.lblFormaPagamento = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).BeginInit();
            this.SuspendLayout();

            // dgvVendas
            this.dgvVendas.Location = new System.Drawing.Point(20, 120);
            this.dgvVendas.Size = new System.Drawing.Size(740, 300);
            this.dgvVendas.ReadOnly = true;
            this.dgvVendas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // dtInicio
            this.dtInicio.Location = new System.Drawing.Point(20, 30);
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicio.ShowCheckBox = true;

            // dtFim
            this.dtFim.Location = new System.Drawing.Point(150, 30);
            this.dtFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFim.ShowCheckBox = true;

            // txtMesa
            this.txtMesa.Location = new System.Drawing.Point(280, 30);
            this.txtMesa.Size = new System.Drawing.Size(50, 23);

            // txtFormaPagamento
            this.txtFormaPagamento.Location = new System.Drawing.Point(340, 30);
            this.txtFormaPagamento.Size = new System.Drawing.Size(120, 23);

            // btnFiltrar
            this.btnFiltrar.Location = new System.Drawing.Point(470, 28);
            this.btnFiltrar.Size = new System.Drawing.Size(100, 25);
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            // Labels
            this.lblInicio.Text = "Início:";
            this.lblInicio.Location = new System.Drawing.Point(20, 10);

            this.lblFim.Text = "Fim:";
            this.lblFim.Location = new System.Drawing.Point(150, 10);

            this.lblMesa.Text = "Mesa:";
            this.lblMesa.Location = new System.Drawing.Point(280, 10);

            this.lblFormaPagamento.Text = "Pagamento:";
            this.lblFormaPagamento.Location = new System.Drawing.Point(340, 10);

            // VendaViewerForm
            this.ClientSize = new System.Drawing.Size(780, 450);
            this.Controls.Add(this.dgvVendas);
            this.Controls.Add(this.dtInicio);
            this.Controls.Add(this.dtFim);
            this.Controls.Add(this.txtMesa);
            this.Controls.Add(this.txtFormaPagamento);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.lblFim);
            this.Controls.Add(this.lblMesa);
            this.Controls.Add(this.lblFormaPagamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "VendaViewerForm";
            this.Text = "Visualizar Vendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvVendas;
        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.DateTimePicker dtFim;
        private System.Windows.Forms.TextBox txtMesa;
        private System.Windows.Forms.TextBox txtFormaPagamento;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblFim;
        private System.Windows.Forms.Label lblMesa;
        private System.Windows.Forms.Label lblFormaPagamento;
    }
}
