using MySqlConnector;
using System.Data;

namespace REVChopp.Data
{
    public static class DbConnectionFactory
    {
        private static readonly string connectionString = "Server=localhost;Database=revchopp;User ID=root;Password=Lloydcueio1!;";

        public static IDbConnection CreateConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
