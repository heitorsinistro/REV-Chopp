using System;
using System.Windows.Forms;
using REVChopp.Models;
using REVChopp.Repositories;

namespace REVChopp.UI
{
    public partial class ProdutoForm : Form
    {
        public ProdutoForm()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                !decimal.TryParse(txtPreco.Text, out decimal preco) ||
                !int.TryParse(txtQuantidade.Text, out int qtd))
            {
                MessageBox.Show("Preencha todos os campos corretamente.");
                return;
            }

            var produto = new ProdutoUnitario
            {
                Nome = txtNome.Text,
                Preco = preco,
                QuantidadeEstoque = qtd
            };

            ProdutoUnitarioRepository.Inserir(produto);
            MessageBox.Show("Produto cadastrado com sucesso!");
            this.Close();
        }
    }
}
