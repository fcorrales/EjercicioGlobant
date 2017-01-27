using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio.Model
{
    public class MicroVehiculo : TipoVehiculo
    {
        public MicroVehiculo()
        {
            Nombre = "micro";
            TipoViaRestriccionList = new List<string> { "autopista", "calle" };
        }
    }
}
