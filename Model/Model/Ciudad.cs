using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio.Model
{
    public class Ciudad
    {
        public string Nombre { get; set; }

        public int CantidadVisitantes { get; set; }

        public Ciudad(string nombre, int cantidadVisitantes)
        {
            this.Nombre = nombre;
            this.CantidadVisitantes = cantidadVisitantes;
        }
    }
}
