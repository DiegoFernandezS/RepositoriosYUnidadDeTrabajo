using Models;
using Repository.Interfaces;
using Repository.Interfacess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SqlServer
{
    public class FacturaRepository : Repository, IFacturaRepository
    {
        public FacturaRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transacion = transaction;
        }

        public void Create(Factura modelo)
        {
            var query = "INSERT into facturas(clienteId,iva,subTotal,total) output INSERTED.ID VALUES(@clienteId,@iva,@subTotal,@total)";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@clienteId", modelo.clienteId);
            command.Parameters.AddWithValue("@iva", modelo.iva);
            command.Parameters.AddWithValue("@subTotal", modelo.subTotal);
            command.Parameters.AddWithValue("@total", modelo.total);

            modelo.id = Convert.ToInt32(command.ExecuteScalar());
        }
            
        public Factura Get(int id)
        {
            var resultado = new Factura();
            var command = CreateCommand("SELECT * FROM facturas WHERE id = @id");
            command.Parameters.AddWithValue("@id", id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                resultado.id = Convert.ToInt32(reader["id"]);
                resultado.iva = Convert.ToDecimal(reader["iva"]);
                resultado.subTotal = Convert.ToDecimal(reader["subTotal"]);
                resultado.total = Convert.ToDecimal(reader["total"]);
                resultado.clienteId = Convert.ToInt32(reader["clienteId"]);
            }

            return resultado;
        }

        public IEnumerable<Factura> GetAll()
        {
            var resultado = new List<Factura>();
            var command = CreateCommand("SELECT * FROM facturas WITH (NOLOCK)");

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    resultado.Add(new Factura
                    {
                        id = Convert.ToInt32(reader["id"]),
                        iva = Convert.ToDecimal(reader["iva"]),
                        subTotal = Convert.ToDecimal(reader["subTotal"]),
                        total = Convert.ToDecimal(reader["total"]),
                        clienteId = Convert.ToInt32(reader["clienteId"])
                    });
                }
            }

            return resultado;
        }

        public void Remove(int id)
        {
            var command = CreateCommand("DELETE FROM facturas WHERE id = @id");
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
        }

        public void Update(Factura modelo)
        {
            var query = "UPDATE facturas SET clienteId = @clienteId, iva = @iva, subTotal = @subTotal, total = @total WHERE id = @id";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@clienteId", modelo.clienteId);
            command.Parameters.AddWithValue("@iva", modelo.iva);
            command.Parameters.AddWithValue("@subTotal", modelo.subTotal);
            command.Parameters.AddWithValue("@total", modelo.total);
            command.Parameters.AddWithValue("@id", modelo.id);

            command.ExecuteNonQuery();
        }
    }
}
