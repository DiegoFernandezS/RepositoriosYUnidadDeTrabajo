using Models;
using Repository.Interfaces;
using Repository.Interfaces.Actions;
using Repository.Interfacess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SqlServer
{
    public class ProductoRepository : Repository, IProductoRepository
    {
        public ProductoRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transacion = transaction;
        }

        public Producto Get(int id)
        {
            var command = CreateCommand("SELECT * FROM productos WITH(NOLOCK) WHERE productos.id = @prodId");
            command.Parameters.AddWithValue("@prodId", id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new Producto
                {
                    id = Convert.ToInt32(reader["id"]),
                    nombre = reader["nombre"].ToString(),
                    precio = Convert.ToDecimal(reader["precio"]),
                };
            }
        }

        public IEnumerable<Producto> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
