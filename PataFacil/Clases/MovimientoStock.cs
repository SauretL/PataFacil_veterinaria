using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PataFacil.Clases
{
    // Esta clase representa UN movimiento de stock (un ingreso o un egreso de un producto).
    internal class MovimientoStock
    {
        public Producto Producto { get; set; }   // producto al que se le mueve el stock
        public string Tipo { get; set; }         // "Ingreso" o "Egreso"
        public int Cantidad { get; set; }        // cuántas unidades entran o salen
        public DateTime Fecha { get; set; }      // fecha del movimiento
        public string Detalle { get; set; }      // observación (puede estar vacía)

        // Constructor: crea el movimiento con todos sus datos juntos
        public MovimientoStock(Producto producto, string tipo, int cantidad, DateTime fecha, string detalle)
        {
            Producto = producto;
            Tipo = tipo;
            Cantidad = cantidad;
            Fecha = fecha;
            Detalle = detalle;
        }
    }
}
