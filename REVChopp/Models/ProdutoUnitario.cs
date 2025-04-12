namespace REVChopp.Models
{
    public class ProdutoUnitario
    {
        public int Id { get; set; }
        public string? Nome { get; set; } = "";
        public decimal Preco { get; set; }

        public int QuantidadeEstoque { get; set; }
    }
}