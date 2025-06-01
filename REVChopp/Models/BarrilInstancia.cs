namespace REVChopp.Models
{
    public class BarrilInstancia
    {
        public int Id { get; set; }
        public int BarrilTipoId { get; set; }
        public int VolumeRestanteMl { get; set; }
        public string Status { get; set; } = "";
        public DateTime? DataAbertura { get; set; }
        public DateTime? DataValidade { get; set; }
    }
}
