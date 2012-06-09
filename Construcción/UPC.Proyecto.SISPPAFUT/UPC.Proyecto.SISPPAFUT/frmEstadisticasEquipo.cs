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
    public partial class frmEstadisticasEquipo : Form
    {
        List<LigaBE> lista_ligas;
        List<EquipoBE> lista_equipos;

        public frmEstadisticasEquipo()
        {
            InitializeComponent();
        }

        private static frmEstadisticasEquipo frm;
        public static frmEstadisticasEquipo Instance()
        {
            if (frm == null)
            {
                frm = new frmEstadisticasEquipo();
            }
            return frm;
        }

        private void frmEstadisticasEquipo_Load(object sender, EventArgs e)
        {

        }
    }
}
