using Microsoft.Data.SqlClient;
using System;

namespace PataFacil.Datos
{
    internal class Dal
    {
        // Devuelve el rol del usuario ("Veterinario", "Recepcionista", etc.)
        // o null si el email/contraseña son incorrectos o el usuario está dado de baja.
        public string? ObtenerRol(string email, string password)
        {
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
    }
}