namespace REVChopp.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int NumeroMesa { get; set; }
        public DateTime DataHora { get; set; }
        public String FormaPagamento { get; set; } = "";
        public decimal ValorTotal { get; set; }

        public string Atendente { get; set; } = "";
        public DateTime? DataVenda { get; set; }

        public string Descricao => $"#{Id} - Mesa {NumeroMesa} - R$ {ValorTotal:F2}";
    }

}