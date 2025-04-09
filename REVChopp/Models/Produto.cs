namespace REVChopp.Models
{
    public class Produto //arrumar para ProdutoUnitario depois, e dependencias
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }

        public int QuantidadeEstoque { get; set; }
    }
}