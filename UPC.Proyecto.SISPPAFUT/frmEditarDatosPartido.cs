using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmEditarDatosPartido : Form
    {
        private static frmEditarDatosPartido frm = null;
        public static frmEditarDatosPartido Instance()
        {
            if (frm == null)
            {
                frm = new frmEditarDatosPartido();
            }
            return frm;
        }

        public frmEditarDatosPartido()
        {
            InitializeComponent();
        }

        private void cargarCombos()
        {
            cmb_amonestaciones_equipo.SelectedIndex = 0;
            cmb_amonestaciones_jugador.SelectedIndex = 0;
            cmb_amonestaciones_minuto.SelectedIndex = 0;
            cmb_amonestaciones_amonestacion.SelectedIndex = 0;

            cmb_goles_equipos.SelectedIndex = 0;
            cmb_goles_jugadores.SelectedIndex = 0;
            cmb_goles_minuto.SelectedIndex = 0;

            cmb_lesiones_equipos.SelectedIndex = 0;
            cmb_lesiones_jugadores.SelectedIndex = 0;
            cmb_lesiones_minuto.SelectedIndex = 0;
        }

        private void EditarDatosPartido_Load(object sender, EventArgs e)
        {
            cargarCombos();
        }
    }
}
