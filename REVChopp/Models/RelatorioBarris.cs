namespace REVChopp.Models
{
    public class RelatorioBarris
    {
        public int Id { get; set; }
        public int RelatorioId { get; set; }
        public int BarrilTipoId { get; set; }
        public string NomeBarril { get; set; } = "";
        public int MlConsumidosTotal { get; set; }
    }
}