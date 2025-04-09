namespace REVChopp.Models
{
    public class Copo
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";           // Ex: "Copo 400ml"
        public int CapacidadeMl { get; set; }            // Ex: 400 ou 1000
        public decimal Preco { get; set; }               // Ex: 9.00 ou 20.00
    }
}
