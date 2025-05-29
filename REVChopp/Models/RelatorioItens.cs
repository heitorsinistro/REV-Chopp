namespace REVChopp.Models
{
    public class RelatorioItens
    {
        public int Id { get; set; }
        public int RelatorioId { get; set; }
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; } = "";
        public int QuantidadeVendida { get; set; }
        public decimal TotalReceitaProduto { get; set; }
    }
}