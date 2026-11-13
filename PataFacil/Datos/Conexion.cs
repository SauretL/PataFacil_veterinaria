using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace PataFacil.Datos
{
    internal class Conexion
    {
        //Aca va la conexion con la base de datos cuando este lista.

        public static string sConnection =
                @"Server=localhost;Database=PataFacil;Integrated Security=True;TrustServerCertificate=True;";

        
    }
}
