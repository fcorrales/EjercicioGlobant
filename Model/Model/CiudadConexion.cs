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

        public CiudadConexion(string NombreCiudad1, string NombreCiudad2, int Tiempo, string NombreTipoVia)
        {
            this.NombreCiudad1 = NombreCiudad1;
            this.NombreCiudad2 = NombreCiudad2;
            this.Tiempo = Tiempo;
            this.NombreTipoVia = NombreTipoVia;
        }
    }
}
