using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using UPC.Proyecto.SISPPAFUT.BL.BC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmJugadorInsertar : Form
    {
        private static frmJugadorInsertar frmJugador = null;
        public static frmJugadorInsertar Instance()
        {
            if (frmJugador == null)
            {
                frmJugador = new frmJugadorInsertar();
            }
            return frmJugador;
        }

        public frmJugadorInsertar()
        {
            InitializeComponent();
        }

        private void frmJugadorInsertar_Load(object sender, EventArgs e)
        {

        }
    }
}
