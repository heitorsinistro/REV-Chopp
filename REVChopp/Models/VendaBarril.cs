using System;

namespace REVChopp.Models
{
    public class VendaBarril
    {
        public int Id { get; set; }
        public int BarrilId { get; set; }     // FK para Barril
        public int CopoId { get; set; }       // FK para Copo
        public int Quantidade { get; set; }   // Quantos copos foram vendidos
        public DateTime DataHora { get; set; } = DateTime.Now;
    }
}
