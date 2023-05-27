using Repository.Interfaces;
using Repository.Interfacess;
using Repository.SqlServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
    {
        public IProductoRepository ProductoRepository { get; }
        public IFacturaRepository FacturaRepository { get; }
        public IClienteRepository ClienteRepository { get; }
        public IDetalleFacturaRepository DetalleFacturaRepository { get; }
        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            FacturaRepository = new FacturaRepository(context,transaction);
            ClienteRepository = new ClienteRepository(context,transaction);
            ProductoRepository = new ProductoRepository(context,transaction);
            DetalleFacturaRepository = new DetalleFacturaRepository(context,transaction);
        }
    }
}
