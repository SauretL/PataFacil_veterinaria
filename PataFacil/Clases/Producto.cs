using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PataFacil.Clases
{
    // Esta clase representa UN producto del inventario.
    // Cada objeto Producto guarda los datos de una fila de la grilla.
    internal class Producto
    {
        // Datos del producto (coinciden con las columnas de la tabla Producto)
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }

        // Constructor: sirve para crear un producto pasando todos los datos juntos.
        public Producto(int id, string nombre, string categoria, int stockActual, int stockMinimo)
        {
            Id = id;
            Nombre = nombre;
            Categoria = categoria;
            StockActual = stockActual;
            StockMinimo = stockMinimo;
        }

        // Devuelve true si el stock actual es MENOR al stock mínimo.
        // (Si es igual al mínimo todavía no se considera "bajo").
        public bool EstaBajoMinimo()
        {
            return StockActual < StockMinimo;
        }

        // Devuelve el texto que se muestra en la columna "Estado" de la grilla.
        public string ObtenerEstado()
        {
            if (EstaBajoMinimo())
            {
                return "Stock bajo";
            }
            else
            {
                return "OK";
            }
        }
    }
}
