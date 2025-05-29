namespace REVChopp.Models
{
    public class RelatorioCopos
    {
        public int Id { get; set; }
        public int RelatorioId { get; set; }
        public int CopoId { get; set; }
        public int CapacidadeMl { get; set; }
        public int QuantidadeVendida { get; set; }
        public decimal TotalReceitaCopos { get; set; }
    }
}