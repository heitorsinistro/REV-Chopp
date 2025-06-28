namespace REVChopp.UI
{
    partial class BarrilForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.btnNovoTipo = new System.Windows.Forms.Button();
            this.lblLitros = new System.Windows.Forms.Label();
            this.nudLitros = new System.Windows.Forms.NumericUpDown();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudLitros)).BeginInit();
            this.SuspendLayout();

            // lblTipo
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(20, 20);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(70, 15);
            this.lblTipo.Text = "Tipo de Barril:";

            // cmbTipo
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Location = new System.Drawing.Point(20, 40);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(220, 23);

            // btnNovoTipo
            this.btnNovoTipo.Location = new System.Drawing.Point(250, 40);
            this.btnNovoTipo.Name = "btnNovoTipo";
            this.btnNovoTipo.Size = new System.Drawing.Size(90, 23);
            this.btnNovoTipo.Text = "Novo Tipo";
            this.btnNovoTipo.Click += new System.EventHandler(this.btnNovoTipo_Click);

            // lblLitros
            this.lblLitros.AutoSize = true;
            this.lblLitros.Location = new System.Drawing.Point(20, 80);
            this.lblLitros.Name = "lblLitros";
            this.lblLitros.Size = new System.Drawing.Size(90, 15);
            this.lblLitros.Text = "Quantidade (L):";

            // nudLitros
            this.nudLitros.DecimalPlaces = 2;
            this.nudLitros.Location = new System.Drawing.Point(20, 100);
            this.nudLitros.Maximum = 999;
            this.nudLitros.Minimum = 1;
            this.nudLitros.Name = "nudLitros";
            this.nudLitros.Size = new System.Drawing.Size(100, 23);
            this.nudLitros.Value = 1;

            // btnSalvar
            this.btnSalvar.Location = new System.Drawing.Point(60, 150);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 30);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            // btnCancelar
            this.btnCancelar.Location = new System.Drawing.Point(170, 150);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // BarrilForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 200);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.btnNovoTipo);
            this.Controls.Add(this.lblLitros);
            this.Controls.Add(this.nudLitros);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BarrilForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Barril";
            ((System.ComponentModel.ISupportInitialize)(this.nudLitros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Button btnNovoTipo;
        private System.Windows.Forms.Label lblLitros;
        private System.Windows.Forms.NumericUpDown nudLitros;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
