using Models;
using Repository.Interfaces.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IFacturaRepository : IReadRepository<Factura, int>, ICreateRepository<Factura>, IUpdateRepository<Factura>, IRemoveRepository<int>
    {

    }
}
