using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DetalleFactura
    {
        public int id { get; set; }
        public int facturaId { get; set; }
        public Factura factura { get; set; }
        public int prodId { get; set; }
        public Producto producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal iva { get; set; }
        public decimal subTotal { get; set; }
        public decimal total { get; set; }
    }
}
