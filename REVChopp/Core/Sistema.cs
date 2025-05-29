using System;
using REVChopp.Repositories;
using REVChopp.Models;

namespace REVChopp.Core
{
    public static class Sistema
    {
        public static void MenuPrincipal()
        {
            Console.WriteLine("REVChopp - Sistema de Vendas e Estoque");
            Console.WriteLine("1. Testar conexão com o banco");
            Console.WriteLine("2. Listar Produtos");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha: ");
            var opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    TestarConexao();
                    break;
                case "2":
                    ListarProdutos();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }

        private static void TestarConexao()
        {
            try
            {
                using var conexao = BancoDados.ObterConexao();
                Console.WriteLine("Conexão bem-sucedida!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        private static void ListarProdutos()
        {
            var produtos = ProdutoUnitarioRepository.ListarTodos();
            foreach (var p in produtos)
                Console.WriteLine($"{p.Id} - {p.Nome} - R${p.Preco} - Estoque: {p.QuantidadeEstoque}");
        }
    }
}