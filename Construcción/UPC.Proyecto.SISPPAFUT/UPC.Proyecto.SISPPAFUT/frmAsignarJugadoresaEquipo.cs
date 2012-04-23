using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmAsignarJugadoresaEquipo : Form
    {
        private static frmAsignarJugadoresaEquipo frmAsignarJugador = null;
        public static frmAsignarJugadoresaEquipo Instance()
        {
            if (frmAsignarJugador == null)
            {
                frmAsignarJugador = new frmAsignarJugadoresaEquipo();
            }
            return frmAsignarJugador;
        }

        public frmAsignarJugadoresaEquipo()
        {
            InitializeComponent();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAsignarJugadoresaEquipo_Load(object sender, EventArgs e)
        {
            cmb_paises.SelectedIndex = 0;
            cmb_equipos.SelectedIndex = 0;
            cmb_jugadores.SelectedIndex = 0;
        }
    }
}
