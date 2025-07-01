using MySql.Data.MySqlClient;
using REVChopp.Core;
using REVChopp.Models;

namespace REVChopp.Repositories
{
    public class VendaRepository
    {
        public static int RegistrarVenda(Venda venda)
        {
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand(@"INSERT INTO Venda (id_pedido, id_usuario, data_hora) 
                    VALUES (@id_pedido, @id_usuario, @data_hora); 
                    SELECT LAST_INSERT_ID();", conexao);
                comando.Parameters.AddWithValue("@id_pedido", venda.PedidoId);
                comando.Parameters.AddWithValue("@id_usuario", venda.UsuarioId);
                comando.Parameters.AddWithValue("@data_hora", venda.DataHora);
                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }

        public static List<Pedido> BuscarVendas(DateTime? inicio, DateTime? fim, int mesa, string formaPagamento)
        {
            var lista = new List<Pedido>();
            using (var conexao = BancoDados.ObterConexao())
            {
                var comando = new MySqlCommand(@"
                    SELECT p.*, v.data_hora, u.nome AS atendente
                    FROM Pedido p
                    JOIN Venda v ON p.id_pedido = v.id_pedido
                    JOIN Usuario u ON p.id_usuario = u.id_usuario
                    WHERE (@inicio IS NULL OR v.data_hora >= @inicio)
                    AND (@fim IS NULL OR v.data_hora <= @fim)
                    AND (p.numero_mesa = @mesa OR @mesa = 0)
                    AND (p.forma_pagamento LIKE @formaPagamento OR @formaPagamento = '')
                    ORDER BY v.data_hora DESC", conexao);

                comando.Parameters.AddWithValue("@inicio", inicio.HasValue ? inicio.Value.Date : (object)DBNull.Value);
                comando.Parameters.AddWithValue("@fim", fim.HasValue ? fim.Value.Date.AddDays(1).AddTicks(-1) : (object)DBNull.Value);
                comando.Parameters.AddWithValue("@mesa", mesa);
                comando.Parameters.AddWithValue("@formaPagamento", $"%{formaPagamento}%");

                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new Pedido
                        {
                            Id = leitor.GetInt32("id_pedido"),
                            UsuarioId = leitor.GetInt32("id_usuario"),
                            NumeroMesa = leitor.GetInt32("numero_mesa"),
                            DataHora = leitor.GetDateTime("data_hora"),
                            FormaPagamento = leitor.GetString("forma_pagamento"),
                            ValorTotal = leitor.GetDecimal("valor_total"),
                            Atendente = leitor.GetString("atendente")
                        });
                    }
                }
            }
            return lista;
        }
    }
}