namespace REVChopp.UI
{
    partial class RelatorioViewerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lstRelatorios = new System.Windows.Forms.ListBox();
            this.dgvItens = new System.Windows.Forms.DataGridView();
            this.dgvCopos = new System.Windows.Forms.DataGridView();
            this.dgvBarris = new System.Windows.Forms.DataGridView();
            this.lblItens = new System.Windows.Forms.Label();
            this.lblCopos = new System.Windows.Forms.Label();
            this.lblBarris = new System.Windows.Forms.Label();
            this.lblDataInicio = new System.Windows.Forms.Label();
            this.lblDataFim = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCopos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarris)).BeginInit();
            this.SuspendLayout();

            // lstRelatorios
            this.lstRelatorios.Location = new System.Drawing.Point(20, 20);
            this.lstRelatorios.Size = new System.Drawing.Size(200, 400);
            this.lstRelatorios.SelectedIndexChanged += new System.EventHandler(this.lstRelatorios_SelectedIndexChanged);

            // lblDataInicio
            this.lblDataInicio.Location = new System.Drawing.Point(240, 10);
            this.lblDataInicio.Size = new System.Drawing.Size(250, 15);
            this.lblDataInicio.Text = "Data de Início:";

            // lblDataFim
            this.lblDataFim.Location = new System.Drawing.Point(500, 10);
            this.lblDataFim.Size = new System.Drawing.Size(250, 15);
            this.lblDataFim.Text = "Data de Fim:";

            // lblItens
            this.lblItens.Text = "Produtos";
            this.lblItens.Location = new System.Drawing.Point(240, 30);

            // dgvItens
            this.dgvItens.Location = new System.Drawing.Point(240, 50);
            this.dgvItens.Size = new System.Drawing.Size(500, 100);
            this.dgvItens.ReadOnly = true;
            this.dgvItens.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // lblCopos
            this.lblCopos.Text = "Copos";
            this.lblCopos.Location = new System.Drawing.Point(240, 160);

            // dgvCopos
            this.dgvCopos.Location = new System.Drawing.Point(240, 180);
            this.dgvCopos.Size = new System.Drawing.Size(500, 100);
            this.dgvCopos.ReadOnly = true;
            this.dgvCopos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // lblBarris
            this.lblBarris.Text = "Barris";
            this.lblBarris.Location = new System.Drawing.Point(240, 290);

            // dgvBarris
            this.dgvBarris.Location = new System.Drawing.Point(240, 310);
            this.dgvBarris.Size = new System.Drawing.Size(500, 100);
            this.dgvBarris.ReadOnly = true;
            this.dgvBarris.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // RelatorioViewerForm
            this.ClientSize = new System.Drawing.Size(770, 440);
            this.Controls.Add(this.lstRelatorios);
            this.Controls.Add(this.lblDataInicio);
            this.Controls.Add(this.lblDataFim);
            this.Controls.Add(this.lblItens);
            this.Controls.Add(this.dgvItens);
            this.Controls.Add(this.lblCopos);
            this.Controls.Add(this.dgvCopos);
            this.Controls.Add(this.lblBarris);
            this.Controls.Add(this.dgvBarris);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RelatorioViewerForm";
            this.Text = "Visualizar Relatórios";

            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCopos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarris)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListBox lstRelatorios;
        private System.Windows.Forms.DataGridView dgvItens;
        private System.Windows.Forms.DataGridView dgvCopos;
        private System.Windows.Forms.DataGridView dgvBarris;
        private System.Windows.Forms.Label lblItens;
        private System.Windows.Forms.Label lblCopos;
        private System.Windows.Forms.Label lblBarris;
        private System.Windows.Forms.Label lblDataInicio;
        private System.Windows.Forms.Label lblDataFim;
    }
}
