using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio.Model
{
    public class RestriccionTransito
    {
        public string NombreTipoVehiculo { get; set; }

        public IList<string> NombreTipoViaList;

        public RestriccionTransito(string nombreTipoVehiculo, List<string> nombreTipoViaList)
        {
            this.NombreTipoVehiculo = nombreTipoVehiculo;
            this.NombreTipoViaList = nombreTipoViaList;
        }
    }
}

