namespace REVChopp.Models
{
    public class Venda //arrumar para VendaProdutoUnitario depois, e dependencias
    {
        public List<Produto> Itens { get; private set; } = new List<Produto>();

        public void AdicionarProduto(Produto produto)
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