using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PataFacil.Clases
{
    // "Sesion" guarda quién inició sesión, para que cualquier formulario lo pueda consultar
    public static class Sesion
    {
        // Email con el que entró la persona. Vacío ("") significa que NO hay nadie con sesión iniciada.
        public static string Email = "";
        // Nombre para mostrar en pantalla (por ejemplo "Dra. Maria Gomez").
        public static string Nombre = "";
    }
}
