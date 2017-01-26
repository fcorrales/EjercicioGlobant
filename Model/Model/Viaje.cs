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

        public Viaje(string NombreTipoVehiculo, int CantidadPasajeros)
        {
            this.NombreTipoVehiculo = NombreTipoVehiculo;
            this.CantidadPasajeros = CantidadPasajeros;
            this.NombreCiudadesList = new List<string>();
            this.EsValido = true;
        }
    }
}