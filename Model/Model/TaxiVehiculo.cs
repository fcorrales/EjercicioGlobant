using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio.Model
{
    public class TaxiVehiculo : TipoVehiculo
    {
        public TaxiVehiculo()
        {
            Nombre = "taxi";
            TipoViaRestriccionList = null;
        }
    }
}
