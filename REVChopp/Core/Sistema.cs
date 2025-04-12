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
                Console.WriteLine("\n1. Adicionar produto unitário");
                Console.WriteLine("2. Remover produto unitário");
                Console.WriteLine("3. Listar produtos no estoque");
                Console.WriteLine("4. Adicionar barril");
                Console.WriteLine("5. Remover barril");
                Console.WriteLine("6. Listar barris no estoque");
                Console.WriteLine("7. Voltar");
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
                        estoque.AdicionarProduto(new ProdutoUnitario { Id = new Random().Next(100, 999), Nome = nome, Preco = preco, QuantidadeEstoque = quantidade });
                    }
                    else Console.WriteLine("Quantidade inválida.");
                }
                else if (opcao == "2")
                {
                    estoque.ListarProdutos();
                    Console.Write("ID do produto para remover: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.Write("Quantidade a remover: ");
                        if (int.TryParse(Console.ReadLine(), out int quantidade) && quantidade > 0)
                        {
                            estoque.RemoverProduto(id, quantidade);
                        }
                        else Console.WriteLine("Quantidade inválida.");
                    }
                }
                else if (opcao == "3") estoque.ListarProdutos();
                else if (opcao == "4")
                {
                    Console.Write("Nome do barril: ");
                    string? nome = Console.ReadLine();
                    Console.Write("Cerveja: ");
                    string? cerveja = Console.ReadLine();
                    Console.Write("Litros (L): ");
                    if (int.TryParse(Console.ReadLine(), out int capacidadeL))
                    {
                        estoque.AdicionarBarril(new Barril { Id = new Random().Next(100, 999), Nome = nome, VolumeTotalLitros = capacidadeL, VolumeRestanteMl = capacidadeL*1000,TipoCerveja = cerveja });
                    }
                    else Console.WriteLine("Capacidade inválida.");
                }
                else if (opcao == "5")
                {
                    estoque.ListarBarris();
                    //if(estoque.barris.Count == 0) break; -- arrumar uma forma de voltar para o menu caso não tenha barris
                    Console.Write("ID do barril para remover: ");
                    if (int.TryParse(Console.ReadLine(), out int id)) estoque.RemoverBarril(id);
                }
                else if (opcao == "6") estoque.ListarBarris();
                else if (opcao == "7") break;
                else Console.WriteLine("Opção inválida.");
            }
        }
    }
}