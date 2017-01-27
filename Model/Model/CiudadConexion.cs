using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio.Model
{
    public class CiudadConexion
    {
        public string NombreCiudad1 { get; set; }

        public string NombreCiudad2 { get; set; }

        public int Tiempo { get; set; }

        public string NombreTipoVia { get; set; }

        public CiudadConexion(string nombreCiudad1, string nombreCiudad2, int tiempo, string nombreTipoVia)
        {
            NombreCiudad1 = nombreCiudad1;
            NombreCiudad2 = nombreCiudad2;
            Tiempo = tiempo;
            NombreTipoVia = nombreTipoVia;
        }
    }
}
