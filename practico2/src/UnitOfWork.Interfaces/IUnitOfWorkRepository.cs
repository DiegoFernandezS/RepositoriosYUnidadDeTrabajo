using Repository.Interfaces;
using Repository.Interfacess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        IFacturaRepository FacturaRepository { get; }
        IClienteRepository ClienteRepository { get; }
        IProductoRepository ProductoRepository { get; }
        IDetalleFacturaRepository DetalleFacturaRepository { get; }

    }
}
