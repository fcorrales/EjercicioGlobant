using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio.Model
{
    public class TipoVehiculo
    {
        public string Nombre;

        public IList<string> TipoViaRestriccionList;

        public bool TipoViaValida(string tipoVia)
        {
            if (TipoViaRestriccionList != null && TipoViaRestriccionList.Count > 0)
                foreach (string TipoViaRestriccion in TipoViaRestriccionList)
                {
                    if (TipoViaRestriccion == tipoVia)
                        return false;
                }
            return true;
        }
    }
}
