namespace REVChopp.Models
{
    public class ItensPedido
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int? ProdutoId { get; set; }
        public int? CopoId { get; set; }
        public string TipoItem { get; set; } = "";
        public string NomeItem { get; set; } = "";
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public decimal Subtotal { get; set; }
        public int? BarrilId { get; set; }
    }
}