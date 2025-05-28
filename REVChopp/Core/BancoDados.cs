using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace REVChopp.Core
{
    public static class BancoDados
    {
        private static readonly string ConnectionString;

        static BancoDados()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            ConnectionString = configuration.GetConnectionString("RevChopp")
                ?? throw new InvalidOperationException("String de conexão 'RevChopp' não encontrada.");
        }

        public static MySqlConnection ObterConexao()
        {
            var conexao = new MySqlConnection(ConnectionString);
            conexao.Open();
            return conexao;
        }
    }
}