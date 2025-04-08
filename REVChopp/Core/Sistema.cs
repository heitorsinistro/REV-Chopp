using REVChopp.Models;
using REVChopp.Services;

namespace REVChopp.Core
{
    public static class Sistema
    {
        private static Estoque estoque = new Estoque();
        private static bool usuarioAutenticado = false;

        public static void MenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine("\n1. Login");
                Console.WriteLine("2. Gerenciar Estoque (requer login)");
                Console.WriteLine("3. Sair");
                Console.Write("Opção: ");
                string? opcao = Console.ReadLine();

                if (opcao == "1") MenuLogin();
                else if (opcao == "2")
                {
                    if (usuarioAutenticado) MenuEstoque();
                    else Console.WriteLine("⚠ Acesso negado. Faça login primeiro.");
                }
                else if (opcao == "3") break;
                else Console.WriteLine("Opção inválida.");
            }
        }

        private static void MenuLogin()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine() ?? string.Empty;

            Console.Write("Senha: ");
            string senha = Console.ReadLine() ?? string.Empty;

            Console.Write("Nível de Acesso (admin/funcionario): ");
            string nivelAcesso = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(senha) || string.IsNullOrWhiteSpace(nivelAcesso))
            {
                Console.WriteLine("Todos os campos são obrigatórios.");
                return;
            }

            if (Usuario.Autenticar(nome, senha, nivelAcesso))
            {
                Console.WriteLine("Autenticação bem-sucedida!");
                usuarioAutenticado = true;
                Console.WriteLine($"Bem-vindo, {nome}! Você é um(a) {nivelAcesso}.");
            }
            else
            {
                Console.WriteLine("Falha na autenticação.");
            }
        }

        private static void MenuEstoque()
        {
            while (true)
            {
                Console.WriteLine("\n1. Adicionar produto");
                Console.WriteLine("2. Remover produto");
                Console.WriteLine("3. Listar produtos");
                Console.WriteLine("4. Voltar");
                Console.Write("Opção: ");
                string? opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    Console.Write("Nome do produto: ");
                    string? nome = Console.ReadLine();
                    Console.Write("Preço: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal preco))
                    {
                        Console.WriteLine("Preço inválido.");
                        continue;
                    }
                    Console.Write("Quantidade em estoque: ");
                    if (int.TryParse(Console.ReadLine(), out int quantidade))
                    {
                        estoque.AdicionarProduto(new Produto { Id = new Random().Next(100, 999), Nome = nome, Preco = preco, QuantidadeEstoque = quantidade });
                    }
                    else Console.WriteLine("Quantidade inválida.");
                }
                else if (opcao == "2")
                {
                    estoque.ListarProdutos();
                    Console.Write("ID do produto para remover: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                        estoque.RemoverProduto(id);
                }
                else if (opcao == "3") estoque.ListarProdutos();
                else if (opcao == "4") break;
                else Console.WriteLine("Opção inválida.");
            }
        }
    }
}