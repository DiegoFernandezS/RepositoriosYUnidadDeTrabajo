using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Factura
    {
        public int id { get; set; }
        public int clienteId { get; set; }
        public Cliente cliente {get; set;}

        public IEnumerable<DetalleFactura> detalles {get; set;}
        public decimal iva { get; set; }
        public decimal subTotal { get; set; }
        public decimal total { get; set; }

        public Factura()
        {
            detalles = new List<DetalleFactura>();  
        }

    }
}
