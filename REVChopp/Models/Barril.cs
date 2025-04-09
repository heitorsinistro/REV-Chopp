namespace REVChopp.Models
{
    public class Barril
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public decimal VolumeTotalLitros { get; set; } // Ex: 30.00
        public int VolumeRestanteMl { get; set; }      // Ex: 18000 ml
        public string TipoCerveja { get; set; } = "";  // Ex: IPA, Pilsen
    }
}
