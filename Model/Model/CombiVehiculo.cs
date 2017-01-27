using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio.Model
{
    public class CombiVehiculo : TipoVehiculo
    {
        public CombiVehiculo()
        {
            Nombre = "combi";
            TipoViaRestriccionList = new List<string> { "calle" };
        }
    }
}
