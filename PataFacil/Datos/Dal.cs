using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace PataFacil.Datos
{
    internal class Dal
    {
        // Devuelve el rol del usuario ("Veterinario", "Recepcionista", etc.)
        // o null si el email/contraseña son incorrectos o el usuario está dado de baja.
        public string? ObtenerRol(string email, string password)
        {
            // La consulta SQL. Los @email y @password son PARÁMETROS: lugares que se
            // completan después. Así nadie puede "colar" código SQL escribiendo en el textbox.
            // "Activo = 1" excluye a los usuarios dados de baja.
            using (SqlConnection conexion = new SqlConnection(Conexion.sConnection))
            {
                SqlCommand comando = new SqlCommand(
                    "SELECT Rol FROM Usuario WHERE Email = @email AND PasswordHash = @password AND Activo = 1",
                    conexion);

                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@password", password);

                conexion.Open();
                object? resultado = comando.ExecuteScalar();

                if (resultado == null)
                    return null;

                return resultado.ToString();
            }
        }

        //-----------------------------------------------------------------------------------//

        // Devuelve el nombre guardado en la base para un email (para mostrarlo en pantalla).
        public string ObtenerNombre(string email)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.sConnection))
            {
                SqlCommand comando = new SqlCommand(
                    "SELECT Nombre FROM Usuario WHERE Email = @email", conexion);
                comando.Parameters.AddWithValue("@email", email);

                conexion.Open();
                object? resultado = comando.ExecuteScalar();
                return resultado?.ToString() ?? "";
            }
        }

        //-----------------------------------------------------------------------------------//

        // Devuelve los turnos de UN veterinario (identificado por su email) para UN día.
        // Devuelve un DataTable: una tabla en memoria con filas y columnas.
        public DataTable ObtenerAgenda(string email, DateTime fecha, bool soloPendientes)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.sConnection))
            {
                // Los JOIN unen tablas: el turno se une con el usuario (veterinario), la mascota
                // y el cliente (dueño), para traer todo en una sola consulta.
                // El filtro de fecha es un RANGO: desde las 00:00 de ese día hasta las 00:00 del siguiente,
                // porque FechaHora guarda fecha y hora juntas.
                // (@soloPend = 0 OR ...) : si no tildaron "Solo pendientes", no filtra por estado.
                SqlCommand comando = new SqlCommand(@"
                SELECT t.IdTurno, t.FechaHora, t.IdMascota, m.Nombre AS Mascota, m.Especie,c.Nombre + ' ' + c.Apellido AS Dueno, t.Motivo, t.Estado
                FROM Turno t
                JOIN Usuario u ON u.IdUsuario = t.IdUsuario
                JOIN Mascota m ON m.IdMascota = t.IdMascota
                JOIN Cliente c ON c.IdCliente = m.IdCliente
                WHERE u.Email = @email
                AND t.FechaHora >= @desde AND t.FechaHora < @hasta
                AND (@soloPend = 0 OR t.Estado = 'Pendiente')
                ORDER BY t.FechaHora", conexion);

                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@desde", fecha.Date);
                comando.Parameters.AddWithValue("@hasta", fecha.Date.AddDays(1));
                comando.Parameters.AddWithValue("@soloPend", soloPendientes);

                
                DataTable tabla = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
                return tabla;
            }
        }

        //-----------------------------------------------------------------------------------//

        // Devuelve nombre, especie y dueño de una mascota.
        public DataTable ObtenerMascota(int idMascota)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.sConnection))
            {
                SqlCommand comando = new SqlCommand(@"
            SELECT m.Nombre, m.Especie, c.Nombre + ' ' + c.Apellido AS Dueno
            FROM Mascota m
            JOIN Cliente c ON c.IdCliente = m.IdCliente
            WHERE m.IdMascota = @id", conexion);
                comando.Parameters.AddWithValue("@id", idMascota);

                DataTable tabla = new DataTable();
                new SqlDataAdapter(comando).Fill(tabla);
                return tabla;
            }
        }

        //-----------------------------------------------------------------------------------//

        // Devuelve las consultas anteriores de una mascota, la más reciente primero.
        // El motivo se toma del turno de esa consulta (la tabla Consulta no tiene Motivo).
        public DataTable ObtenerConsultas(int idMascota)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.sConnection))
            {
                SqlCommand comando = new SqlCommand(@"
            SELECT c.IdConsulta, c.FechaHora, u.Nombre AS Veterinario,
                   t.Motivo, c.Diagnostico, c.Tratamiento
            FROM Consulta c
            JOIN Usuario u ON u.IdUsuario = c.IdUsuario
            JOIN Turno t ON t.IdTurno = c.IdTurno
            WHERE c.IdMascota = @id
            ORDER BY c.FechaHora DESC", conexion);
                comando.Parameters.AddWithValue("@id", idMascota);

                DataTable tabla = new DataTable();
                new SqlDataAdapter(comando).Fill(tabla);
                return tabla;
            }
        }

        //-----------------------------------------------------------------------------------//

        // Guarda la consulta Y marca el turno como Atendido. Las dos cosas, o ninguna (transacción).
        public void GuardarConsulta(int idTurno, int idMascota, string email, string diagnostico, string tratamiento)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.sConnection))
            {
                conexion.Open();
                using (SqlTransaction tx = conexion.BeginTransaction())
                {
                    try
                    {
                        // El IdUsuario se busca por email con una subconsulta: no hace falta guardarlo en C#.
                        SqlCommand insertar = new SqlCommand(@"
                    INSERT INTO Consulta (IdTurno, IdMascota, IdUsuario, Diagnostico, Tratamiento)
                    VALUES (@turno, @mascota, (SELECT IdUsuario FROM Usuario WHERE Email = @email), @diag, @trat)",
                            conexion, tx);
                        insertar.Parameters.AddWithValue("@turno", idTurno);
                        insertar.Parameters.AddWithValue("@mascota", idMascota);
                        insertar.Parameters.AddWithValue("@email", email);
                        insertar.Parameters.AddWithValue("@diag", diagnostico);
                        // Si el tratamiento está vacío se guarda NULL en la base.
                        insertar.Parameters.AddWithValue("@trat",
                            string.IsNullOrWhiteSpace(tratamiento) ? DBNull.Value : (object)tratamiento.Trim());
                        insertar.ExecuteNonQuery();

                        SqlCommand actualizar = new SqlCommand(
                            "UPDATE Turno SET Estado = 'Atendido' WHERE IdTurno = @turno", conexion, tx);
                        actualizar.Parameters.AddWithValue("@turno", idTurno);
                        actualizar.ExecuteNonQuery();

                        tx.Commit();      // confirma las dos operaciones
                    }
                    catch
                    {
                        tx.Rollback();    // si algo falló, deshace todo
                        throw;            // y vuelve a lanzar el error para que lo muestre el botón
                    }
                }
            }
        }

    }
}