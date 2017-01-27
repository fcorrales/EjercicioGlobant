using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ejercicio.Model;

namespace Ejercicio.Test
{
    [TestClass]
    public class UnitTestTipoViaValida
    {
        [TestMethod]
        public void TestMicroVehiculoValido()
        {
            string TipoVia = "ruta";

            MicroVehiculo MicroVehiculo = new MicroVehiculo();

            Assert.IsTrue(MicroVehiculo.TipoViaValida(TipoVia));
        }

        [TestMethod]
        public void TestMicroVehiculoInvalido()
        {
            string TipoVia = "calle";

            MicroVehiculo MicroVehiculo = new MicroVehiculo();

            Assert.IsFalse(MicroVehiculo.TipoViaValida(TipoVia));
        }
    }
}
