using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace PataFacil.Datos
{
    public class Conexion
    {
        //Aca va la conexion con la base de datos cuando este lista.
               
            private const string Cadena =
                @"Server=localhost;Database=PataFacil;Integrated Security=True;TrustServerCertificate=True;";

            public static SqlConnection ObtenerConexion()
            {
                return new SqlConnection(Cadena);
            }
        
    }
}
