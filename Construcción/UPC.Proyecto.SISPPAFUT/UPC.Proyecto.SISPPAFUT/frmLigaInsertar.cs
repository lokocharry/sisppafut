using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmLigaInsertar : Form
    {
        private static frmLigaInsertar frmLiga = null;
        public static frmLigaInsertar Instance()
        {
            if (frmLiga == null)
            {
                frmLiga = new frmLigaInsertar();
            }
            return frmLiga;
        }

        public frmLigaInsertar()
        {
            InitializeComponent();
        }
    }
}
