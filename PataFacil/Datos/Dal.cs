using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PataFacil.Datos
{
    public static class Dal
    {
        //En esta clase se haran las Conexiones con la base de datos, desde agregar usuarios, hasta ocultarlos, editarlos, etc.
        public static (int IdUsuario, string Nombre)? ObtenerUsuarioAuxiliar()
        {
            const string sql = @"SELECT TOP 1 IdUsuario, Nombre
                                 FROM Usuario
                                 WHERE Rol = 'Auxiliar' AND Activo = 1
                                 ORDER BY IdUsuario";

            using var cn = Conexion.ObtenerConexion();
            using var cmd = new SqlCommand(sql, cn);
            cn.Open();
            using var rd = cmd.ExecuteReader();

            if (rd.Read())
                return (rd.GetInt32(0), rd.GetString(1));

            return null;
        }

        public static DataTable BuscarProductos(string nombre, string categoria, bool soloBajoMinimo)
        {
            const string sql = @"
                SELECT IdProducto, Nombre, Categoria, StockActual, StockMinimo
                FROM Producto
                WHERE (@nombre = '' OR Nombre LIKE '%' + @nombre + '%')
                  AND (@categoria IS NULL OR Categoria = @categoria)
                  AND (@soloBajo = 0 OR StockActual < StockMinimo)
                ORDER BY Nombre;";

            using var cn = Conexion.ObtenerConexion();
            using var cmd = new SqlCommand(sql, cn);

            cmd.Parameters.AddWithValue("@nombre", nombre ?? "");
            cmd.Parameters.AddWithValue("@categoria", (object)categoria ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@soloBajo", soloBajoMinimo ? 1 : 0);

            cn.Open();
            using var rd = cmd.ExecuteReader();

            var tabla = new DataTable();
            tabla.Load(rd);
            return tabla;
        }

        public static (string Nombre, int StockActual)? ObtenerProducto(int idProducto)
        {
            const string sql = "SELECT Nombre, StockActual FROM Producto WHERE IdProducto = @id";

            using var cn = Conexion.ObtenerConexion();
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@id", idProducto);
            cn.Open();
            using var rd = cmd.ExecuteReader();

            if (rd.Read())
                return (rd.GetString(0), rd.GetInt32(1));

            return null;
        }

        public static bool ExisteProductoConNombre(string nombre, int? idExcluir)
        {
            const string sql = @"SELECT COUNT(*) FROM Producto
                                 WHERE Nombre = @nombre
                                   AND (@id IS NULL OR IdProducto <> @id)";

            using var cn = Conexion.ObtenerConexion();
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value =
                idExcluir.HasValue ? (object)idExcluir.Value : DBNull.Value;

            cn.Open();
            return (int)cmd.ExecuteScalar() > 0;
        }

        public static int InsertarProducto(string nombre, string categoria, int stockMinimo)
        {
            const string sql = @"INSERT INTO Producto (Nombre, PrecioUnitario, StockActual, StockMinimo, Categoria)
                                 OUTPUT INSERTED.IdProducto
                                 VALUES (@nombre, 0, 0, @minimo, @categoria)";

            using var cn = Conexion.ObtenerConexion();
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@minimo", stockMinimo);
            cmd.Parameters.AddWithValue("@categoria", categoria);

            cn.Open();
            return (int)cmd.ExecuteScalar();
        }

        public static void ActualizarProducto(int idProducto, string nombre, string categoria, int stockMinimo)
        {
            const string sql = @"UPDATE Producto
                                 SET Nombre = @nombre, Categoria = @categoria, StockMinimo = @minimo
                                 WHERE IdProducto = @id";

            using var cn = Conexion.ObtenerConexion();
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@categoria", categoria);
            cmd.Parameters.AddWithValue("@minimo", stockMinimo);
            cmd.Parameters.AddWithValue("@id", idProducto);

            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public static DataTable ObtenerProductosParaReposicion(int? idProducto)
        {
            string sql = @"SELECT Nombre, Categoria, StockActual, StockMinimo
                           FROM Producto
                           WHERE StockActual < StockMinimo"
                       + (idProducto.HasValue ? " AND IdProducto = @id" : "")
                       + " ORDER BY Nombre";

            using var cn = Conexion.ObtenerConexion();
            using var cmd = new SqlCommand(sql, cn);
            if (idProducto.HasValue)
                cmd.Parameters.AddWithValue("@id", idProducto.Value);

            cn.Open();
            using var rd = cmd.ExecuteReader();

            var tabla = new DataTable();
            tabla.Load(rd);
            return tabla;
        }

        public static bool RegistrarMovimiento(int idProducto, int idUsuario, bool esIngreso,
                                               int cantidad, DateTime fechaHora, string observacion)
        {
            using var cn = Conexion.ObtenerConexion();
            cn.Open();

            using var tx = cn.BeginTransaction();


            string sqlStock = esIngreso
                ? "UPDATE Producto SET StockActual = StockActual + @c WHERE IdProducto = @id"
                : "UPDATE Producto SET StockActual = StockActual - @c WHERE IdProducto = @id AND StockActual >= @c";

            using (var upd = new SqlCommand(sqlStock, cn, tx))
            {
                upd.Parameters.AddWithValue("@c", cantidad);
                upd.Parameters.AddWithValue("@id", idProducto);

                if (upd.ExecuteNonQuery() == 0)
                    return false;
            }

            const string sqlMov = @"INSERT INTO MovimientoStock
                                        (IdProducto, IdUsuario, TipoMovimiento, Cantidad, FechaHora, Observacion)
                                    VALUES (@prod, @usr, @tipo, @c, @fecha, @obs)";

            using (var ins = new SqlCommand(sqlMov, cn, tx))
            {
                ins.Parameters.AddWithValue("@prod", idProducto);
                ins.Parameters.AddWithValue("@usr", idUsuario);
                ins.Parameters.AddWithValue("@tipo", esIngreso ? "Ingreso" : "Egreso");
                ins.Parameters.AddWithValue("@c", cantidad);
                ins.Parameters.AddWithValue("@fecha", fechaHora);

                ins.Parameters.AddWithValue("@obs",
                    string.IsNullOrWhiteSpace(observacion) ? DBNull.Value : observacion.Trim());
                ins.ExecuteNonQuery();
            }

            tx.Commit();
            return true;
        }

    }
}
