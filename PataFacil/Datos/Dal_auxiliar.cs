using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using PataFacil.Clases; 

namespace PataFacil.Datos
{
    internal class Dal_Auxiliar
    {
        // Devuelve TODOS los productos de la tabla Producto, ordenados por nombre.
        // Los filtros (nombre, categoría, stock bajo) los hace después el formulario sobre esta lista.
        public List<Producto> ObtenerProductos()
        {
            // Se inicia una lista vacia para luego guardar los productos
            List<Producto> lista = new List<Producto>();

            // usar conexion (abre y cierra al terminar)
            using (SqlConnection conexion = new SqlConnection(Conexion.sConnection))
            {
                // Se piden las columnas que se necesitan
                SqlCommand comando = new SqlCommand(
                    "SELECT IdProducto, Nombre, Categoria, StockActual, StockMinimo " +
                    "FROM Producto ORDER BY Nombre", conexion);

                conexion.Open();

                // recorre resultado
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    // pasa a la siguiente fila y devuelve false cuando no quedan más
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

        //-----------------------------------------------------------------------------------//

        // Agrega un producto nuevo a la tabla Producto
        // id se asigna automaticamente y el precio en 0
        public void InsertarProducto(Producto nuevo)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.sConnection))
            {
                // parametros
                SqlCommand comando = new SqlCommand(
                    "INSERT INTO Producto (Nombre, Categoria, StockActual, StockMinimo) " +
                    "VALUES (@nombre, @categoria, @stockActual, @stockMinimo)", conexion);

                comando.Parameters.AddWithValue("@nombre", nuevo.Nombre);
                comando.Parameters.AddWithValue("@categoria", nuevo.Categoria);
                comando.Parameters.AddWithValue("@stockActual", nuevo.StockActual);
                comando.Parameters.AddWithValue("@stockMinimo", nuevo.StockMinimo);

                conexion.Open();
                comando.ExecuteNonQuery();   // ejecuta la orden (no devuelve datos)
            }
        }

        //-----------------------------------------------------------------------------------//

        // Cambia el nombre, la categoría y el stock min de un producto existente
        public void ModificarProducto(Producto editado)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.sConnection))
            {
                SqlCommand comando = new SqlCommand(
                    "UPDATE Producto SET Nombre = @nombre, Categoria = @categoria, StockMinimo = @stockMinimo " +
                    "WHERE IdProducto = @id", conexion);

                comando.Parameters.AddWithValue("@nombre", editado.Nombre);
                comando.Parameters.AddWithValue("@categoria", editado.Categoria);
                comando.Parameters.AddWithValue("@stockMinimo", editado.StockMinimo);
                comando.Parameters.AddWithValue("@id", editado.Id);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        //-----------------------------------------------------------------------------------//

        // Registra un ingreso o un egreso de stock de un producto
        // El email es el de quien hizo la modificacion
        public void RegistrarMovimiento(MovimientoStock movimiento, string email)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.sConnection))
            {
                conexion.Open();
                using (SqlTransaction tx = conexion.BeginTransaction())
                {
                    try
                    {
                        // ingresos suman y egresos restan
                        int cambio = movimiento.Cantidad;
                        if (movimiento.Tipo == "Egreso")
                        {
                            cambio = -movimiento.Cantidad;
                        }

                        // cambiamos stoick y se verifica q no quede en negativo
                        SqlCommand actualizar = new SqlCommand(
                            "UPDATE Producto SET StockActual = StockActual + @cambio " +
                            "WHERE IdProducto = @id AND StockActual + @cambio >= 0", conexion, tx);
                        actualizar.Parameters.AddWithValue("@cambio", cambio);
                        actualizar.Parameters.AddWithValue("@id", movimiento.Producto.Id);

                        // si es 0, es porque no había stock suficiente (o el producto ya no existe)
                        int filasModificadas = actualizar.ExecuteNonQuery();
                        if (filasModificadas == 0)
                        {
                            throw new Exception("No hay stock suficiente para este movimiento.");
                        }

                        // se guarda el movimiento

                        SqlCommand insertar = new SqlCommand(
                            "INSERT INTO MovimientoStock (IdProducto, IdUsuario, TipoMovimiento, Cantidad, FechaHora, Observacion) " +
                            "VALUES (@idProducto, (SELECT IdUsuario FROM Usuario WHERE Email = @email), " +
                            "@tipo, @cantidad, @fecha, @observacion)", conexion, tx);
                        insertar.Parameters.AddWithValue("@idProducto", movimiento.Producto.Id);
                        insertar.Parameters.AddWithValue("@email", email);
                        insertar.Parameters.AddWithValue("@tipo", movimiento.Tipo);
                        insertar.Parameters.AddWithValue("@cantidad", movimiento.Cantidad);
                        insertar.Parameters.AddWithValue("@fecha", movimiento.Fecha.Date.Add(DateTime.Now.TimeOfDay));
                        // si el detalle está vacío se guarda NULL en la base.
                        insertar.Parameters.AddWithValue("@observacion",
                            string.IsNullOrWhiteSpace(movimiento.Detalle) ? DBNull.Value : (object)movimiento.Detalle);
                        insertar.ExecuteNonQuery();

                        tx.Commit();      
                    }
                    catch
                    {
                        tx.Rollback();    // si falla algo se deshace todo
                        throw; 
                    }
                }
            }
        }
    }
}
