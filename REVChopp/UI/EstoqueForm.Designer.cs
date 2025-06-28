namespace REVChopp.UI
{
    partial class EstoqueForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAddProduto;
        private System.Windows.Forms.Button btnAddBarril;
        private System.Windows.Forms.Button btnListarProdutos;
        private System.Windows.Forms.Button btnListarBarris;
        private System.Windows.Forms.DataGridView dgvEstoque;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnAddProduto = new System.Windows.Forms.Button();
            this.btnAddBarril = new System.Windows.Forms.Button();
            this.btnListarProdutos = new System.Windows.Forms.Button();
            this.btnListarBarris = new System.Windows.Forms.Button();
            this.dgvEstoque = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoque)).BeginInit();
            this.SuspendLayout();

            // btnAddProduto
            this.btnAddProduto.Location = new System.Drawing.Point(30, 20);
            this.btnAddProduto.Size = new System.Drawing.Size(200, 30);
            this.btnAddProduto.Text = "Adicionar Produto";
            this.btnAddProduto.Click += new System.EventHandler(this.btnAddProduto_Click);

            // btnAddBarril
            this.btnAddBarril.Location = new System.Drawing.Point(30, 60);
            this.btnAddBarril.Size = new System.Drawing.Size(200, 30);
            this.btnAddBarril.Text = "Adicionar Barril";
            this.btnAddBarril.Click += new System.EventHandler(this.btnAddBarril_Click);

            // btnListarProdutos
            this.btnListarProdutos.Location = new System.Drawing.Point(30, 100);
            this.btnListarProdutos.Size = new System.Drawing.Size(200, 30);
            this.btnListarProdutos.Text = "Listar Produtos";
            this.btnListarProdutos.Click += new System.EventHandler(this.btnListarProdutos_Click);

            // btnListarBarris
            this.btnListarBarris.Location = new System.Drawing.Point(30, 140);
            this.btnListarBarris.Size = new System.Drawing.Size(200, 30);
            this.btnListarBarris.Text = "Listar Barris";
            this.btnListarBarris.Click += new System.EventHandler(this.btnListarBarris_Click);

            // dgvEstoque
            this.dgvEstoque.Location = new System.Drawing.Point(250, 20);
            this.dgvEstoque.Size = new System.Drawing.Size(500, 300);
            this.dgvEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstoque.Columns.Add("Id", "ID");
            this.dgvEstoque.Columns.Add("Nome", "Nome");
            this.dgvEstoque.Columns.Add("Col3", "Preço/Tipo");
            this.dgvEstoque.Columns.Add("Col4", "Qtd/Volume Total");
            this.dgvEstoque.Columns.Add("Col5", "Estoque/Restante");

            // EstoqueForm
            this.ClientSize = new System.Drawing.Size(800, 350);
            this.Controls.Add(this.btnAddProduto);
            this.Controls.Add(this.btnAddBarril);
            this.Controls.Add(this.btnListarProdutos);
            this.Controls.Add(this.btnListarBarris);
            this.Controls.Add(this.dgvEstoque);
            this.Text = "Gerenciar Estoque";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoque)).EndInit();
            this.ResumeLayout(false);
        }
    }
}