using Common;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Input;
using UnitOfWork.Interfaces;

namespace Services
{
    public class FactServicios
    {
        private IUnitOfWork _unitOfWork;

        public FactServicios(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Factura> GetAll()
        {
            using (var context = _unitOfWork.Create())
            {
                var records = context.Repositories.FacturaRepository.GetAll();

                foreach(var record in records)
                {
                    record.cliente = context.Repositories.ClienteRepository.Get(record.id);
                    record.detalles = context.Repositories.DetalleFacturaRepository.GetAllByDetalleFactura(record.id);
                    
                    foreach(var detalle in record.detalles)
                    {
                        detalle.producto = context.Repositories.ProductoRepository.Get(detalle.prodId);
                    }
                }

                return records;
            }
        }

        public Factura Get(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                var resultado = context.Repositories.FacturaRepository.Get(id);
                resultado.cliente = context.Repositories.ClienteRepository.Get(resultado.clienteId);
                resultado.detalles = context.Repositories.DetalleFacturaRepository.GetAllByDetalleFactura(resultado.id);

                foreach (var detalle in resultado.detalles)
                {
                    detalle.producto = context.Repositories.ProductoRepository.Get(detalle.prodId);
                }

                return resultado;
            }


        }

        public void Create(Factura modelo)
        {
            PrepararOrden(modelo);

            using (var context = _unitOfWork.Create())
            {
                context.Repositories.FacturaRepository.Create(modelo);
                context.Repositories.DetalleFacturaRepository.Create(modelo.detalles, modelo.id);
                context.SaveChanges();
            }
        }

        public void Update(Factura modelo)
        {
            PrepararOrden(modelo);

            using(var context = _unitOfWork.Create())
            {
                context.Repositories.FacturaRepository.Update(modelo);
                context.Repositories.DetalleFacturaRepository.Remove(modelo.detalles, modelo.id);
                context.Repositories.DetalleFacturaRepository.Create(modelo.detalles,modelo.id);
                context.SaveChanges();
            }
        }

        public void DeleteHeader(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                context.Repositories.FacturaRepository.Remove(id);
                context.SaveChanges();
            }
        }

        private void PrepararOrden(Factura modelo)
        {
            foreach (var detalle in modelo.detalles)
            {
                detalle.total = detalle.cantidad * detalle.precio;
                detalle.iva = detalle.total * Parameters.IVAvalor;
                detalle.subTotal = detalle.total - detalle.iva;
            }

            modelo.total = modelo.detalles.Sum(x => x.total);
            modelo.iva = modelo.detalles.Sum(x => x.iva);
            modelo.subTotal = modelo.detalles.Sum(x => x.subTotal);
        }
    }
}
