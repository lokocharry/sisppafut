using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmListaPartidosSinJugar : Form
    {
        private static frmListaPartidosSinJugar frmListarPartidos = null;
        public static frmListaPartidosSinJugar Instance()
        {
            if (frmListarPartidos == null)
            {
                frmListarPartidos = new frmListaPartidosSinJugar();
            }
            return frmListarPartidos;
        }

        public frmListaPartidosSinJugar()
        {
            InitializeComponent();
        }

        private void btn_editar_partido_Click(object sender, EventArgs e)
        {

        }
    }
}
