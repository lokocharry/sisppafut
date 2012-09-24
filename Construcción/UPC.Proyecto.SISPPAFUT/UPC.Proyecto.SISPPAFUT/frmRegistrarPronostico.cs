using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UPC.Proyecto.SISPPAFUT.BL.BC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmRegistrarPronostico : Form
    {
        private static frmRegistrarPronostico frmRegistroPronosticos = null;
        public static frmRegistrarPronostico Instance()
        {
            if (frmRegistroPronosticos == null)
            {
                frmRegistroPronosticos = new frmRegistrarPronostico();
            }
            return frmRegistroPronosticos;
        }


        public frmRegistrarPronostico()
        {
            InitializeComponent();
        }

        private void frmRegistrarPronostico_Load(object sender, EventArgs e)
        {
            try
            {
                dgvPartidosDataBind();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void dgvPartidosDataBind()
        {
            //PartidoBC objPartidoBC;
            //objPartidoBC = new PartidoBC();
        }
    }
}
