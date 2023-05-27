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
    public class DetalleFacturaRepository : Repository, IDetalleFacturaRepository
    {
        public DetalleFacturaRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transacion = transaction;
        }

        public DetalleFactura Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<DetalleFactura> IReadRepository<DetalleFactura, int>.GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(IEnumerable<DetalleFactura> detalles, int factId)
        {
            var query = "DELETE FROM detalleFactura WHERE facturaId = @facturaId";

            var command = CreateCommand(query);
            command.Parameters.AddWithValue("@facturaId", factId);

            command.ExecuteNonQuery();
        }

        public void Create(IEnumerable<DetalleFactura> detalles, int factId)
        {
            foreach (var detalle in detalles)
            {
                var query = "INSERT into detalleFactura(facturaId,prodId,cantidad,precio,iva,subTotal,total) VALUES(@facturaId,@prodId,@cantidad,@precio,@iva,@subTotal,@total)";
                var command = CreateCommand(query);

                command.Parameters.AddWithValue("@facturaId", factId);
                command.Parameters.AddWithValue("@prodId", detalle.prodId);
                command.Parameters.AddWithValue("@cantidad", detalle.cantidad);
                command.Parameters.AddWithValue("@precio", detalle.precio);
                command.Parameters.AddWithValue("@iva", detalle.iva);
                command.Parameters.AddWithValue("@subTotal", detalle.subTotal);
                command.Parameters.AddWithValue("@total", detalle.total);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<DetalleFactura> GetAllByDetalleFactura(int facturaId)
        {
            var resultado = new List<DetalleFactura>();
            var command = CreateCommand("SELECT * FROM detalleFactura WITH (NOLOCK) WHERE detalleFactura.id = @id");
            command.Parameters.AddWithValue("@id", facturaId);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    resultado.Add(new DetalleFactura
                    {
                        id = Convert.ToInt32(reader["id"]),
                        facturaId = Convert.ToInt32(reader["facturaId"]),
                        prodId = Convert.ToInt32(reader["prodId"]),
                        cantidad = Convert.ToInt32(reader["cantidad"]),
                        precio = Convert.ToDecimal(reader["precio"]),
                        iva = Convert.ToDecimal(reader["iva"]),
                        subTotal = Convert.ToDecimal(reader["subTotal"]),
                        total = Convert.ToDecimal(reader["total"])
                    });
                }
            }

            return resultado;
        }
    }
}
