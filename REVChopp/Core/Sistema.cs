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
            Console.Write("Usuário: ");
            string nome = Console.ReadLine() ?? string.Empty;
            Console.Write("Senha: ");
            string senha = Console.ReadLine() ?? string.Empty;

            if (Usuario.Autenticar(nome, senha))
            {
                usuarioAutenticado = true;
                Console.WriteLine("Autenticação bem-sucedida!");
                var vendaService = new VendaService(estoque);
                vendaService.MenuVendas();
            }
            else Console.WriteLine("Falha na autenticação.");
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
                    if (decimal.TryParse(Console.ReadLine(), out decimal preco))
                    {
                        int id = new Random().Next(100, 999);
                        estoque.AdicionarProduto(new Produto { Id = id, Nome = nome, Preco = preco });
                    }
                    else Console.WriteLine("Preço inválido.");
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