using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.BL.BC;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmEntrenarPronosticos : Form
    {
        //--Variables globales
        List<PartidoBE> listaPartidos;
        List<PronosticoBE> listaPronosticos;

        private static frmEntrenarPronosticos frmEntrenamiento = null;
        public static frmEntrenarPronosticos Instance()
        {
            if (frmEntrenamiento == null)
            {
                frmEntrenamiento = new frmEntrenarPronosticos();
            }
            return frmEntrenamiento;
        }

        public frmEntrenarPronosticos()
        {
            InitializeComponent();
        }

        private void frmEntrenarPronosticos_Load(object sender, EventArgs e)
        {
            try
            {
                dg_PronosticosConfigurar();
                dg_PronosticosDataBind();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void dg_PronosticosConfigurar()
        {
            dg_Pronosticos.AllowUserToAddRows = false;
            dg_Pronosticos.AllowUserToDeleteRows = false;

            dg_Pronosticos.AllowUserToResizeColumns = false;
            dg_Pronosticos.AllowUserToResizeRows = false;
            dg_Pronosticos.AllowDrop = false;

            dg_Pronosticos.MultiSelect = false;
            dg_Pronosticos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dg_Pronosticos.ReadOnly = true;
        }

        private void dg_PronosticosDataBind()
        {
            PartidoBC objPartidoBC = new PartidoBC();
            PronosticoBC objPronosticoBC = new PronosticoBC();

            listaPartidos = new List<PartidoBE>();
            listaPronosticos = new List<PronosticoBE>();

            listaPartidos = objPartidoBC.lista_todos_partidos();
            listaPronosticos = objPronosticoBC.listar_Pronosticos();


        }

    }
}
