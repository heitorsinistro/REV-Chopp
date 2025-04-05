using REVChopp.Models;
using Dapper;

namespace REVChopp.Data
{
    public class UsuarioRepository
    {
        public List<Usuario> ListarUsuarios()
        {
            using var connection = DbConnectionFactory.CreateConnection();
            return connection.Query<Usuario>("SELECT * FROM Usuario").ToList();
        }
    }
}
