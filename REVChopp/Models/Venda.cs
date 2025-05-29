namespace REVChopp.Models
{
    public class Venda //arrumar para VendaProdutoUnitario depois, e dependencias
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataHora { get; set; }
    }
}