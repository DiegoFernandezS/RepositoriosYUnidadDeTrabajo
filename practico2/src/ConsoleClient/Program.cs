using Models;
using Services;
using UnitOfWork.SqlServer;

internal class Program
{
    private static void Main(string[] args)
    {
        var unitoOfWork = new UnitOfWorkSqlServer();
        var Ordenfacturas = new FactServicios(unitoOfWork);


        // ------------ Ver objetos ------------------
        //var resultado = Ordenfacturas.Get(1);
        //var resultado1 = Ordenfacturas.Get(6);
        //var resultado2 = Ordenfacturas.Get(3);
       // Console.Read();

        //--------------Agregar datos ----------------
         /*var factura = new Factura
         {
             clienteId = 1,
             detalles = new List<DetalleFactura>
             {
                 new DetalleFactura
                 {
                     prodId = 1,
                     cantidad = 5,
                     precio = 1250
                 },
                 new DetalleFactura
                 {
                     prodId = 3,
                     cantidad = 15,
                     precio = 500
                 }
             }
         };

         Ordenfacturas.Create(factura);*/

        //Console.Read();
        //-------------Modificar datos ----------------
        /*var factura = new Factura
        {
            id = 14,
            clienteId = 1,
            detalles = new List<DetalleFactura>
            {
                new DetalleFactura
                {
                    prodId = 1,
                    cantidad = 3,
                    precio = 1250
                },
                new DetalleFactura
                {
                    prodId = 3,
                    cantidad = 10,
                    precio = 500
                }
            }
        };

        Ordenfacturas.Update(factura);*/

        //------------Borrar Datos -------------------

        //Ordenfacturas.DeleteHeader(10);
        //Ordenfacturas.DeleteHeader(9);
        //Console.Read();
    }
}