namespace REVChopp.Models
{
    public class Venda //arrumar para VendaProdutoUnitario depois, e dependencias
    {
        public List<ProdutoUnitario> Itens { get; private set; } = new List<ProdutoUnitario>();

        public void AdicionarProduto(ProdutoUnitario produto)
        {
            Itens.Add(produto);
        }

        public void LimparPedido()
        {
            Itens.Clear();
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in Itens)
                total += item.Preco;
            return total;
        }
    }
}