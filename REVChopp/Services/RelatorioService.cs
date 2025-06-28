using REVChopp.Models;
using REVChopp.Repositories;

namespace REVChopp.Services
{
    public static class RelatorioService
    {
        public static void GerarRelatorioDiario(int usuarioId)
        {
            DateTime hoje = DateTime.Today;
            DateTime inicio = hoje;
            DateTime fim = hoje.AddDays(1).AddTicks(-1);

            var relatorio = new Relatorio
            {
                Tipo = "Diário",
                DataInicio = inicio,
                DataFim = fim,
                GeradoPor = usuarioId
            };
            int relatorioId = RelatorioRepository.Inserir(relatorio);

            var itens = ResumoItens(inicio, fim);
            foreach (var item in itens)
            {
                RelatorioItensRepository.Inserir(new RelatorioItens
                {
                    RelatorioId = relatorioId,
                    ProdutoId = item.ProdutoId,
                    NomeProduto = item.Nome,
                    QuantidadeVendida = item.Quantidade,
                    TotalReceitaProduto = item.Total
                });
            }

            var copos = ResumoCopos(inicio, fim);
            foreach (var copo in copos)
            {
                RelatorioCoposRepository.Inserir(new RelatorioCopos
                {
                    RelatorioId = relatorioId,
                    CopoId = copo.CopoId,
                    CapacidadeMl = copo.CapacidadeMl,
                    QuantidadeVendida = copo.Quantidade,
                    TotalReceitaCopos = copo.Total
                });
            }

            var barris = ResumoBarris(inicio, fim);
            foreach (var barril in barris)
            {
                RelatorioBarrisRepository.Inserir(new RelatorioBarris
                {
                    RelatorioId = relatorioId,
                    BarrilTipoId = barril.BarrilTipoId,
                    NomeBarril = barril.Nome,
                    MlConsumidosTotal = barril.MlConsumido
                });
            }

            Console.WriteLine($"✅ Relatório diário gerado com ID {relatorioId}.");
        }

        public static void GerarRelatorioSemanal(int usuarioId)
        {
            DateTime hoje = DateTime.Today;
            DateTime inicio = hoje.AddDays(-(int)hoje.DayOfWeek); // Domingo
            DateTime fim = inicio.AddDays(7).AddTicks(-1); // Sábado

            var relatorio = new Relatorio
            {
                Tipo = "Semanal",
                DataInicio = inicio,
                GeradoPor = usuarioId
            };
            int relatorioId = RelatorioRepository.Inserir(relatorio);

            var itens = ResumoItens(inicio, fim);
            foreach (var item in itens)
            {
                RelatorioItensRepository.Inserir(new RelatorioItens
                {
                    RelatorioId = relatorioId,
                    ProdutoId = item.ProdutoId,
                    NomeProduto = item.Nome,
                    QuantidadeVendida = item.Quantidade,
                    TotalReceitaProduto = item.Total
                });
            }

            var copos = ResumoCopos(inicio, fim);
            foreach (var copo in copos)
            {
                RelatorioCoposRepository.Inserir(new RelatorioCopos
                {
                    RelatorioId = relatorioId,
                    CopoId = copo.CopoId,
                    CapacidadeMl = copo.CapacidadeMl,
                    QuantidadeVendida = copo.Quantidade,
                    TotalReceitaCopos = copo.Total
                });
            }

            var barris = ResumoBarris(inicio, fim);
            foreach (var b in barris)
            {
                RelatorioBarrisRepository.Inserir(new RelatorioBarris
                {
                    RelatorioId = relatorioId,
                    BarrilTipoId = b.BarrilTipoId,
                    NomeBarril = b.Nome,
                    MlConsumidosTotal = b.MlConsumido
                });
            }

            Console.WriteLine($"✅ Relatório semanal gerado com ID {relatorioId}.");
        }

        public static void GerarRelatorioMensal(int usuarioId)
        {
            DateTime hoje = DateTime.Today;
            DateTime inicio = new DateTime(hoje.Year, hoje.Month, 1);
            DateTime fim = inicio.AddMonths(1).AddTicks(-1);

            var relatorio = new Relatorio
            {
                Tipo = "Mensal",
                DataInicio = inicio,
                GeradoPor = usuarioId
            };
            int relatorioId = RelatorioRepository.Inserir(relatorio);

            var itens = ResumoItens(inicio, fim);
            foreach (var item in itens)
            {
                RelatorioItensRepository.Inserir(new RelatorioItens
                {
                    RelatorioId = relatorioId,
                    ProdutoId = item.ProdutoId,
                    NomeProduto = item.Nome,
                    QuantidadeVendida = item.Quantidade,
                    TotalReceitaProduto = item.Total
                });
            }

            var copos = ResumoCopos(inicio, fim);
            foreach (var copo in copos)
            {
                RelatorioCoposRepository.Inserir(new RelatorioCopos
                {
                    RelatorioId = relatorioId,
                    CopoId = copo.CopoId,
                    CapacidadeMl = copo.CapacidadeMl,
                    QuantidadeVendida = copo.Quantidade,
                    TotalReceitaCopos = copo.Total
                });
            }

            var barris = ResumoBarris(inicio, fim);
            foreach (var b in barris)
            {
                RelatorioBarrisRepository.Inserir(new RelatorioBarris
                {
                    RelatorioId = relatorioId,
                    BarrilTipoId = b.BarrilTipoId,
                    NomeBarril = b.Nome,
                    MlConsumidosTotal = b.MlConsumido
                });
            }

            Console.WriteLine($"✅ Relatório mensal gerado com ID {relatorioId}.");
        }

        private static List<(int ProdutoId, string Nome, int Quantidade, decimal Total)> ResumoItens(DateTime inicio, DateTime fim)
        {
            var lista = new List<(int, string, int, decimal)>();
            var reader = ItensPedidoRepository.ConsultarResumoItens(inicio, fim);
            foreach (var i in reader)
                lista.Add((i.ProdutoId, i.NomeItem, i.Quantidade, i.Subtotal));
            return lista;
        }

        private static List<(int CopoId, int CapacidadeMl, int Quantidade, decimal Total)> ResumoCopos(DateTime inicio, DateTime fim)
        {
            var lista = new List<(int, int, int, decimal)>();
            var reader = ItensPedidoRepository.ConsultarResumoCopos(inicio, fim);
            foreach (var i in reader)
                lista.Add((i.CopoId, i.CapacidadeMl, i.Quantidade, i.Subtotal));
            return lista;
        }

        private static List<(int BarrilTipoId, string Nome, int MlConsumido)> ResumoBarris(DateTime inicio, DateTime fim)
        {
            var lista = new List<(int, string, int)>();
            var reader = ConsumoBarrilRepository.ConsultarResumoBarris(inicio, fim);
            foreach (var b in reader)
                lista.Add((b.BarrilTipoId, b.NomeBarril, b.MlConsumido));
            return lista;
        }
    }
}