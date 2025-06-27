using System.Windows.Forms;
using REVChopp.UI;

namespace REVChopp.Program
{

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}