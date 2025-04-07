using ReactiveUI;
using System.Reactive;

namespace REVChopp.UI.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private string nome = string.Empty;
        private string resultado = string.Empty;

        public string Nome
        {
            get => nome;
            set => this.RaiseAndSetIfChanged(ref nome, value);
        }

        public string Resultado
        {
            get => resultado;
            set => this.RaiseAndSetIfChanged(ref resultado, value);
        }

        public ReactiveCommand<Unit, Unit> ExibirNomeCommand { get; }

        public MainWindowViewModel()
        {
            ExibirNomeCommand = ReactiveCommand.Create(() =>
            {
                Resultado = $"Olá, {Nome}!";
            });
        }
    }
}
