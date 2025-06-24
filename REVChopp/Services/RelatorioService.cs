using REVChopp.Models;
using REVChopp.Repositories;

namespace REVChopp.Services
{
    public static class RelatorioService
    {
        public static void GerarRelatorioDiario()
        {
            DateTime hoje = DateTime.Today;
            DateTime inicio = hoje;
            DateTime fim = hoje.AddDays(1).AddTicks(-1);

            decimal totalVendas = RelatorioRepository.CalcularTotalVendas(inicio, fim);
            var itensMaisVendidos = RelatorioItensRepository.ResumoItensVendidos(inicio, fim);
            var coposMaisVendidos = RelatorioCoposRepository.ResumoCoposVendidos(inicio, fim);
            var barrisMaisUsados = RelatorioBarrisRepository.ResumoBarrisUtilizados(inicio, fim);

            var relatorio = new Relatorio
            {
                Periodo = "Diário",
                DataInicio = inicio,
                DataFim = fim,
                TotalVendas = totalVendas,
                ProdutoMaisVendido = itensMaisVendidos.Count > 0 ? itensMaisVendidos[0].Nome : "N/A",
                CopoMaisVendido = coposMaisVendidos.Count > 0 ? coposMaisVendidos[0].Descricao : "N/A",
                BarrilMaisUsado = barrisMaisUsados.Count > 0 ? barrisMaisUsados[0].Nome : "N/A"
            };

            RelatorioRepository.Inserir(relatorio);

            Console.WriteLine("Relatório diário gerado com sucesso!");
            Console.WriteLine($"Total vendido: R${relatorio.TotalVendas:F2}");
            Console.WriteLine($"Produto mais vendido: {relatorio.ProdutoMaisVendido}");
            Console.WriteLine($"Copo mais vendido: {relatorio.CopoMaisVendido}");
            Console.WriteLine($"Barril mais usado: {relatorio.BarrilMaisUsado}");
        }
    }
}