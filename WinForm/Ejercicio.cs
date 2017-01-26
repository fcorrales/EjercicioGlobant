using Ejercicio.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio.WinForm
{
    public partial class Ejercicio : Form
    {
        public IList<Viaje> ViajeList;

        public IList<CiudadConexion> CiudadConexionList;

        public IList<Ciudad> CiudadList;

        public int TiempoTotal;
    
        const string CAMPO_OBLIGATORIO = "* Campo obligatorio";

        public Ejercicio()
        {
            InitializeComponent();

            InicializarControles();

            ViajeList = new List<Viaje>();

            CiudadConexionList = new List<CiudadConexion>();

            CiudadList = new List<Ciudad>();

            TiempoTotal = 0;
        }

        private void btnCiudades_Click(object sender, EventArgs e)
        {
            procesarArchivoCiudades();
            validaArchivoCiudades();
        }

        private void btnViajes_Click(object sender, EventArgs e)
        {
            procesarArchivoViaje();
            validaArchivoViajes();
        }

        private void procesarArchivoCiudades()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ofd.Filter = "Texto plano |*txt";
                File.ReadAllText(ofd.FileName);
                string linea;

                StreamReader archivo = new StreamReader(ofd.FileName);
                while ((linea = archivo.ReadLine()) != null)
                {
                    string[] palabras = linea.Split(',');

                    if (palabras.Count() != 4)
                        throw new InvalidOperationException("El formato del archivo de ciudades no es el correcto");

                    CiudadConexionList.Add(new CiudadConexion(palabras[0], palabras[1], Convert.ToInt32(palabras[2]), palabras[3]));
                }

                archivo.Close();
            }
        }

        private void procesarArchivoViaje()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ofd.Filter = "Texto plano |*txt";
                File.ReadAllText(ofd.FileName);
                string linea;

                StreamReader archivo = new StreamReader(ofd.FileName);
                while ((linea = archivo.ReadLine()) != null)
                {
                    string[] palabras = linea.Split(',');

                    if (palabras.Count() < 4)
                        throw new InvalidOperationException("El formato del archivo de viajes no es el correcto");

                    Viaje viaje = new Viaje(palabras[0], Convert.ToInt32(palabras[1]));

                    for (int i = 2; i < palabras.Count(); i++)
                        viaje.NombreCiudadesList.Add(palabras[i]);

                    ViajeList.Add(viaje);
                }

                archivo.Close();
            }
        }

        private void InicializarControles()
        {
            lblMensajeArchivoCiudades.Text = CAMPO_OBLIGATORIO;
            lblMensajeArchivoViajes.Text = CAMPO_OBLIGATORIO;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validaArchivoCiudades() && validaArchivoViajes())
            {
                procesarViajes();
                mostrarInforme();
            }
        }

        private void procesarViajes()
        {
            int i;
            foreach (Viaje viaje in ViajeList)
            {
                i = 0;
                CiudadConexion ciudadConexion;
                while (i < viaje.NombreCiudadesList.Count() && viaje.EsValido)
                {
                    if (i < (viaje.NombreCiudadesList.Count() - 1))
                    {
                        ciudadConexion = getCiudadConexionByCiudad1andCiudad2(viaje.NombreCiudadesList[i], viaje.NombreCiudadesList[i + 1]);
                        viaje.EsValido = (ciudadConexion != null && !existeRestriccionTipoViaVehiculo(ciudadConexion.NombreTipoVia, viaje.NombreTipoVehiculo));
                        if (viaje.EsValido)
                        {
                            TiempoTotal += ciudadConexion.Tiempo;

                            if (!actualizaCiudad(CiudadList, ciudadConexion.NombreCiudad1, viaje.CantidadPasajeros))
                                CiudadList.Add(new Ciudad(ciudadConexion.NombreCiudad1, viaje.CantidadPasajeros));
                            
                            // Grabo solo el ultimo registro de la lista de ciudades.
                            if (i == (viaje.NombreCiudadesList.Count() - 2))
                                if (!actualizaCiudad(CiudadList, ciudadConexion.NombreCiudad2, viaje.CantidadPasajeros))
                                    CiudadList.Add(new Ciudad(ciudadConexion.NombreCiudad2, viaje.CantidadPasajeros));
                        }
                    }                       
                    i++;
                }         
            }
        }

        private bool actualizaCiudad(IList<Ciudad> ciudadList, string NombreCiudad, int cantidadPasajeros)
        {
            if (ciudadList != null && ciudadList.Count > 0)
            {
                foreach (Ciudad ciudad in ciudadList)
                {
                    if (ciudad.Nombre == NombreCiudad)
                    {
                        ciudad.CantidadVisitantes += cantidadPasajeros;
                        return true;
                    }
                }
            }
            return false;
        }

        private void mostrarInforme()
        {
            Console.WriteLine("Tiempo total de viajes:" + Convert.ToString(TiempoTotal));

            foreach (Ciudad ciudad in CiudadList)
            {
                Console.WriteLine("Cantidad de pasajeros con destino " + ciudad.Nombre +": " + Convert.ToString(ciudad.CantidadVisitantes));
            }
        }

        private bool existeRestriccionTipoViaVehiculo(string tipoVia, string tipoVehiculo)
        {
            IList<RestriccionTransito> restriccionTransitoList = new List<RestriccionTransito>();
            restriccionTransitoList = getRestriccionTransitoList();

            if (restriccionTransitoList != null && restriccionTransitoList.Count > 0)
            {
                foreach (RestriccionTransito rt in restriccionTransitoList)
                {
                    if (rt.NombreTipoVehiculo == tipoVehiculo)
                    {
                        if (rt.NombreTipoViaList != null && rt.NombreTipoViaList.Count > 0)
                        {
                            foreach (string nombreTipoVia in rt.NombreTipoViaList)
                            {
                                if (nombreTipoVia == tipoVia)
                                    return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Restricciones del enunciado para los tipo de vehiculo
        /// </summary>
        private IList<RestriccionTransito> getRestriccionTransitoList()
        {
            IList<RestriccionTransito> RestriccionTransitoList = new List<RestriccionTransito>();

            RestriccionTransitoList.Add(new RestriccionTransito("micros", new List<string> { "autopistas", "calle" }));
            RestriccionTransitoList.Add(new RestriccionTransito("combis", new List<string> { "calle" }));
            RestriccionTransitoList.Add(new RestriccionTransito("taxi", null));
            return RestriccionTransitoList;
        }

        private CiudadConexion getCiudadConexionByCiudad1andCiudad2(string nombreCiudad1, string nombreCiudad2)
        {
            int i = 0;
            while ((i < CiudadConexionList.Count()))
            {
                if ((CiudadConexionList[i].NombreCiudad1 == nombreCiudad1 && CiudadConexionList[i].NombreCiudad2 == nombreCiudad2) ||
                    (CiudadConexionList[i].NombreCiudad1 == nombreCiudad2 && CiudadConexionList[i].NombreCiudad2 == nombreCiudad1))
                    return CiudadConexionList[i];
                i++;
            }
            return null;
        }

        private bool validaArchivoCiudades()
        {
            if (CiudadConexionList.Count() <= 0)
            {
                lblMensajeArchivoCiudades.Text = CAMPO_OBLIGATORIO;
                return false;
            }
            else
            {
                lblMensajeArchivoCiudades.Text = "";
                return true;
            }
         }

        private bool validaArchivoViajes()
        {
            if (ViajeList.Count() <= 0)
            {
                lblMensajeArchivoViajes.Text = CAMPO_OBLIGATORIO;
                return false;
            }
            else
            {
                lblMensajeArchivoViajes.Text = "";
                return true;
            }
        }
    }
}
