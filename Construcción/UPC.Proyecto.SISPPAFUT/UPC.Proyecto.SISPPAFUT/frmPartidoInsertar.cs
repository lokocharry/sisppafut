using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmPartidoInsertar : Form
    {
        private static frmPartidoInsertar frmPartido = null;
        public static frmPartidoInsertar Instance()
        {
            if (frmPartido == null)
            {
                frmPartido = new frmPartidoInsertar();
            }
            return frmPartido;
        }


        public frmPartidoInsertar()
        {
            InitializeComponent();
        }
    }
}
