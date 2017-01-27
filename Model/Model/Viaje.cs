using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio.Model
{
    public class Viaje
    {
        public string NombreTipoVehiculo { get; set; }

        public int CantidadPasajeros { get; set; }

        public bool EsValido { get; set; }

        public IList<string> NombreCiudadesList;

        public Viaje(string nombreTipoVehiculo, int cantidadPasajeros)
        {
            NombreTipoVehiculo = nombreTipoVehiculo;
            CantidadPasajeros = cantidadPasajeros;
            NombreCiudadesList = new List<string>();
            EsValido = true;
        }
    }
}