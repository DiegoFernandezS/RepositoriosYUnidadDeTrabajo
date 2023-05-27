using Models;
using Repository.Interfaces.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfacess
{
    public interface IDetalleFacturaRepository : IReadRepository<DetalleFactura, int>
    {
        void Create(IEnumerable<DetalleFactura> modelo, int factId);
        public void Remove(IEnumerable<DetalleFactura> detalles, int factId);
        IEnumerable<DetalleFactura> GetAllByDetalleFactura(int facturaId);
    }
}
