namespace REVChopp.Models
{
    public class Relatorio
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = "";
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; } = DateTime.Now;
        public int GeradoPor { get; set; }
    }
}