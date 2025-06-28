namespace REVChopp.UI
{
    partial class RelatorioForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipoRelatorio = new System.Windows.Forms.ComboBox();
            this.btnGerarRelatorio = new System.Windows.Forms.Button();
            this.btnVisualizarRelatorios = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTipo
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(20, 20);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(95, 15);
            this.lblTipo.Text = "Tipo de Relatório:";

            // cmbTipoRelatorio
            this.cmbTipoRelatorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoRelatorio.FormattingEnabled = true;
            this.cmbTipoRelatorio.Items.AddRange(new object[] { "Diário", "Semanal", "Mensal" });
            this.cmbTipoRelatorio.Location = new System.Drawing.Point(20, 40);
            this.cmbTipoRelatorio.Name = "cmbTipoRelatorio";
            this.cmbTipoRelatorio.Size = new System.Drawing.Size(200, 23);

            // btnGerarRelatorio
            this.btnGerarRelatorio.Location = new System.Drawing.Point(20, 80);
            this.btnGerarRelatorio.Name = "btnGerarRelatorio";
            this.btnGerarRelatorio.Size = new System.Drawing.Size(200, 30);
            this.btnGerarRelatorio.Text = "Gerar Relatório";
            this.btnGerarRelatorio.Click += new System.EventHandler(this.btnGerarRelatorio_Click);

            // btnVisualizarRelatorios
            this.btnVisualizarRelatorios.Location = new System.Drawing.Point(20, 120);
            this.btnVisualizarRelatorios.Name = "btnVisualizarRelatorios";
            this.btnVisualizarRelatorios.Size = new System.Drawing.Size(200, 30);
            this.btnVisualizarRelatorios.Text = "Visualizar Relatórios";
            this.btnVisualizarRelatorios.Click += new System.EventHandler(this.btnVisualizarRelatorios_Click);

            // RelatorioForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(250, 170);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cmbTipoRelatorio);
            this.Controls.Add(this.btnGerarRelatorio);
            this.Controls.Add(this.btnVisualizarRelatorios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RelatorioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gerar Relatório";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipoRelatorio;
        private System.Windows.Forms.Button btnGerarRelatorio;
        private System.Windows.Forms.Button btnVisualizarRelatorios;
    }
}
