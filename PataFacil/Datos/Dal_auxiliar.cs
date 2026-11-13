using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using PataFacil.Clases;   // para poder usar la clase Producto

namespace PataFacil.Datos
{
    // Acá van todas las consultas a la base de datos que usa el formulario Auxiliar.
    // Es un archivo aparte de Dal.cs para que no se pisen los cambios al unir las ramas.
    internal class Dal_Auxiliar
    {
        // Devuelve TODOS los productos de la tabla Producto, ordenados por nombre.
        // Los filtros (nombre, categoría, stock bajo) los hace después el formulario sobre esta lista.
        public List<Producto> ObtenerProductos()
        {
            // Lista vacía donde vamos a ir guardando los productos que lea de la base
            List<Producto> lista = new List<Producto>();

            // "using" abre la conexión y la cierra sola al terminar
            using (SqlConnection conexion = new SqlConnection(Conexion.sConnection))
            {
                // La consulta SQL: pedimos solo las columnas que necesitamos
                SqlCommand comando = new SqlCommand(
                    "SELECT IdProducto, Nombre, Categoria, StockActual, StockMinimo " +
                    "FROM Producto ORDER BY Nombre", conexion);

                conexion.Open();

                // El "lector" recorre el resultado fila por fila
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    // Read() pasa a la siguiente fila y devuelve false cuando no quedan más
                    while (lector.Read())
                    {
                        // Leemos cada columna por su nombre y armamos un Producto
                        int id = Convert.ToInt32(lector["IdProducto"]);
                        string nombre = lector["Nombre"].ToString();
                        string categoria = lector["Categoria"].ToString();
                        int stockActual = Convert.ToInt32(lector["StockActual"]);
                        int stockMinimo = Convert.ToInt32(lector["StockMinimo"]);

                        lista.Add(new Producto(id, nombre, categoria, stockActual, stockMinimo));
                    }
                }
            }

            return lista;
        }
    }
}
