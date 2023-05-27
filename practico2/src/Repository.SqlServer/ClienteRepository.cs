using Models;
using Repository.Interfaces;
using Repository.Interfaces.Actions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SqlServer
{
    public class ClienteRepository : Repository, IClienteRepository
    {
        public ClienteRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transacion = transaction;
        }

        public void Create(Cliente t)
        {
            throw new NotImplementedException();
        }

        public Cliente Get(int id)
        {
            var command = CreateCommand("SELECT * FROM clientes WITH (NOLOCK) WHERE clientes.id = @id");
            command.Parameters.AddWithValue("@id", id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new Cliente
                {
                    id = Convert.ToInt32(reader["id"]),
                    nombre = reader["nombre"].ToString()
                };
            }
        } 

        public IEnumerable<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
