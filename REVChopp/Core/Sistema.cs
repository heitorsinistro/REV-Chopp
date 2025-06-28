/*using System;
using REVChopp.Models;
using REVChopp.Repositories;
using REVChopp.Services;

namespace REVChopp.Core
{
    public static class Sistema
    {
        private static Usuario? usuarioLogado;

        public static void Iniciar()
        {
            while (true)
            {
                Console.WriteLine("\n--- Menu Principal ---");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Cadastrar Usuário");
                Console.WriteLine("3. Sair");
                Console.Write("Opção: ");
                var opcao = Console.ReadLine();

                if (opcao == "1") FazerLogin();
                else if (opcao == "2") CadastrarUsuario();
                else if (opcao == "3") break;
                else Console.WriteLine("Opção inválida.");
            }
        }

        private static void FazerLogin()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine() ?? "";

            Console.Write("Senha: ");
            string senha = Console.ReadLine() ?? "";

            Console.Write("Acesso (admin ou funcionario): ");
            string nivel = Console.ReadLine() ?? "";

            var usuario = UsuarioRepository.Autenticar(nome, senha, nivel);
            if (usuario != null)
            {
                usuarioLogado = usuario;
                Console.WriteLine($">>> Bem-vindo, {usuario.Nome} ({usuario.NivelAcesso})");
                MenuPrincipal();
            }
            else Console.WriteLine("⚠ Credenciais inválidas.");
        }

        private static void CadastrarUsuario()
        {
            Console.Write("Nome do novo usuário: ");
            string nome = Console.ReadLine() ?? "";

            Console.Write("Senha: ");
            string senha = Console.ReadLine() ?? "";

            Console.Write("Nível de acesso (admin/funcionario): ");
            string nivel = Console.ReadLine() ?? "";

            Usuario novo = new Usuario { Nome = nome, Senha = senha, NivelAcesso = nivel };
            UsuarioRepository.Inserir(novo);
            Console.WriteLine("✅ Usuário cadastrado.");
        }

        private static void MenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine("\n--- Menu do Sistema ---");
                Console.WriteLine("1. Gerenciar Estoque");
                Console.WriteLine("2. Iniciar Pedido");
                Console.WriteLine("3. Finalizar Venda");
                if (usuarioLogado!.NivelAcesso == "admin")
                    Console.WriteLine("4. Gerar Relatório");
                Console.WriteLine("0. Logout");
                Console.Write("Opção: ");
                var op = Console.ReadLine();

                if (op == "1") MenuEstoque();
                else if (op == "2")
                {
                    Console.Write("Número da mesa: ");
                    int numeroMesa = int.Parse(Console.ReadLine() ?? "0");

                    Console.Write("Forma de pagamento: ");
                    string formaPagamento = Console.ReadLine() ?? "";

                    var pedidoService = new PedidoService();
                    
                    pedidoService.CriarPedido(usuarioLogado.Id, numeroMesa, formaPagamento);
                }
                else if (op == "3")
                {
                    Console.Write("ID do Pedido: ");
                    if (int.TryParse(Console.ReadLine(), out int idPedido))
                        VendaService.RegistrarVenda(idPedido, usuarioLogado.Id);
                }
                else if (op == "4" && usuarioLogado!.NivelAcesso == "admin")
                {
                    Console.WriteLine("1. Diário  2. Semanal  3. Mensal");
                    var tipo = Console.ReadLine();
                    if (tipo == "1") RelatorioService.GerarRelatorioDiario(usuarioLogado.Id);
                    else if (tipo == "2") RelatorioService.GerarRelatorioSemanal(usuarioLogado.Id);
                    else if (tipo == "3") RelatorioService.GerarRelatorioMensal(usuarioLogado.Id);
                }
                else if (op == "0") { usuarioLogado = null; break; }
                else Console.WriteLine("Opção inválida.");
            }
        }

        private static void MenuEstoque()
        {
            while (true)
            {
                Console.WriteLine("\n--- Menu Estoque ---");
                Console.WriteLine("1. Adicionar Produto");
                Console.WriteLine("2. Listar Produtos");
                Console.WriteLine("3. Adicionar Barril");
                Console.WriteLine("4. Listar Barris");
                Console.WriteLine("0. Voltar");
                Console.Write("Opção: ");
                var opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine() ?? "";
                    Console.Write("Preço: ");
                    decimal preco = decimal.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Quantidade: ");
                    int qtd = int.Parse(Console.ReadLine() ?? "0");

                    ProdutoUnitarioRepository.Inserir(new ProdutoUnitario
                    {
                        Nome = nome,
                        Preco = preco,
                        QuantidadeEstoque = qtd
                    });
                    Console.WriteLine("Produto adicionado.");
                }
                else if (opcao == "2")
                {
                    var lista = ProdutoUnitarioRepository.ListarTodos();
                    foreach (var p in lista)
                        Console.WriteLine($"{p.Id}. {p.Nome} - R${p.Preco} - {p.QuantidadeEstoque} und");
                }
                else if (opcao == "3")
                {
                    Console.Write("ID do Tipo do Barril: ");
                    int tipoId = int.Parse(Console.ReadLine() ?? "0");
                    var tipo = BarrilTipoRepository.ObterPorId(tipoId);
                    if (tipo == null) Console.WriteLine("Tipo não encontrado.");
                    else
                    {
                        BarrilInstanciaRepository.Inserir(new BarrilInstancia
                        {
                            BarrilTipoId = tipo.Id,
                            VolumeRestanteMl = tipo.CapacidadeLitros * 1000,
                            Status = "em_uso"
                        });
                        Console.WriteLine("Barril adicionado ao estoque.");
                    }
                }
                else if (opcao == "4")
                {
                    var lista = BarrilInstanciaRepository.ListarTodos();
                    foreach (var b in lista)
                        Console.WriteLine($"{b.Id}. Barril Tipo {b.BarrilTipoId} - {b.VolumeRestanteMl}ml restantes - {b.Status}");
                }
                else if (opcao == "0") break;
                else Console.WriteLine("Opção inválida.");
            }
        }
    }
}*/