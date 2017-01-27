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

        CombiVehiculo CombiVehiculo;

        TaxiVehiculo TaxiVehiculo;

        MicroVehiculo MicroVehiculo;

        /// <summary>
        /// Diccionario de Ciudad compuesto por nombre y cantidad de visitantes
        /// </summary>
        Dictionary<string, int> Ciudad;

        public int TiempoTotal;
    
        const string CAMPO_OBLIGATORIO = "* Campo obligatorio";

        public Ejercicio()
        {
            InitializeComponent();

            InicializarControles();

            ViajeList = new List<Viaje>();

            CiudadConexionList = new List<CiudadConexion>();

            Ciudad = new Dictionary<string, int>();

            CombiVehiculo = new CombiVehiculo();

            TaxiVehiculo = new TaxiVehiculo();

            MicroVehiculo = new MicroVehiculo();

            TiempoTotal = 0;
        }

        private void ProcesarArchivoCiudades()
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
                        throw new Exception("El formato del archivo de ciudades no es el correcto");

                    CiudadConexionList.Add(new CiudadConexion(palabras[0], palabras[1], Convert.ToInt32(palabras[2]), palabras[3]));
                }

                archivo.Close();
            }
        }

        private void ProcesarArchivoViaje()
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
                        throw new Exception("El formato del archivo de viajes no es el correcto");

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

        // Se comenta este código y se deja el método indicado abajo. Es el mismo código con diferencia que el otro utiliza paralelismo
        /*private void ProcesarViajes()
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
                        ciudadConexion = GetCiudadConexionByCiudad1andCiudad2(viaje.NombreCiudadesList[i], viaje.NombreCiudadesList[i + 1]);
                        viaje.EsValido = (ciudadConexion != null && TipoViaValida(ciudadConexion.NombreTipoVia, viaje.NombreTipoVehiculo));
                        if (viaje.EsValido)
                        {
                            TiempoTotal += ciudadConexion.Tiempo;

                            if (!Ciudad.ContainsKey(ciudadConexion.NombreCiudad1))  
                                Ciudad.Add(ciudadConexion.NombreCiudad1, viaje.CantidadPasajeros);
                            else
                                Ciudad[ciudadConexion.NombreCiudad1] += viaje.CantidadPasajeros;
                            
                            // Grabo solo el ultimo registro de la lista de ciudades.
                            if (i == (viaje.NombreCiudadesList.Count() - 2))
                                if (!Ciudad.ContainsKey(ciudadConexion.NombreCiudad2))
                                    Ciudad.Add(ciudadConexion.NombreCiudad2, viaje.CantidadPasajeros);
                                else
                                    Ciudad[ciudadConexion.NombreCiudad2] += viaje.CantidadPasajeros;
                        }
                    }                       
                    i++;
                }         
            }
        }*/

        private void ProcesarViajes()
        {
            int i;
            Parallel.ForEach(ViajeList, viaje =>
            {
                i = 0;
                CiudadConexion ciudadConexion;
                while (i < viaje.NombreCiudadesList.Count() && viaje.EsValido)
                {
                    if (i < (viaje.NombreCiudadesList.Count() - 1))
                    {
                        ciudadConexion = GetCiudadConexionByCiudad1andCiudad2(viaje.NombreCiudadesList[i], viaje.NombreCiudadesList[i + 1]);
                        viaje.EsValido = (ciudadConexion != null && TipoViaValida(ciudadConexion.NombreTipoVia, viaje.NombreTipoVehiculo));
                        if (viaje.EsValido)
                        {
                            TiempoTotal += ciudadConexion.Tiempo;

                            if (!Ciudad.ContainsKey(ciudadConexion.NombreCiudad1))
                                Ciudad.Add(ciudadConexion.NombreCiudad1, viaje.CantidadPasajeros);
                            else
                                Ciudad[ciudadConexion.NombreCiudad1] += viaje.CantidadPasajeros;

                            // Grabo solo el ultimo registro de la lista de ciudades.
                            if (i == (viaje.NombreCiudadesList.Count() - 2))
                                if (!Ciudad.ContainsKey(ciudadConexion.NombreCiudad2))
                                    Ciudad.Add(ciudadConexion.NombreCiudad2, viaje.CantidadPasajeros);
                                else
                                    Ciudad[ciudadConexion.NombreCiudad2] += viaje.CantidadPasajeros;
                        }
                    }
                    i++;
                }
            });
        }

        private bool TipoViaValida(string tipoVia, string tipoVehiculo)
        {
            switch (tipoVehiculo)
            {
                case "combi": return CombiVehiculo.TipoViaValida(tipoVia);
                case "taxi": return TaxiVehiculo.TipoViaValida(tipoVia);
                case "micro": return MicroVehiculo.TipoViaValida(tipoVia);
                default: return false;        
            }
        }

        private CiudadConexion GetCiudadConexionByCiudad1andCiudad2(string nombreCiudad1, string nombreCiudad2)
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

        private void MostrarInforme()
        {
            Console.WriteLine("Tiempo total de viajes:" + Convert.ToString(TiempoTotal));

            foreach (KeyValuePair<string, int> ciudad in Ciudad)
            {
                Console.WriteLine("Cantidad de pasajeros con destino {0}: {1}", ciudad.Key, ciudad.Value);
            }
        }

        private bool ValidaArchivoCiudades()
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

        private bool ValidaArchivoViajes()
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

        #region Eventos controles

        private void BtnCiudades_Click(object sender, EventArgs e)
        {
            ProcesarArchivoCiudades(); 
            ValidaArchivoCiudades();
        }

        private void BtnViajes_Click(object sender, EventArgs e)
        {
            ProcesarArchivoViaje();
            ValidaArchivoViajes();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidaArchivoCiudades() && ValidaArchivoViajes())
            {
                ProcesarViajes();
                MostrarInforme();
            }
        }
        #endregion
    }
}
