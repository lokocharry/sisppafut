using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using UPC.Seguridad.BL.BC;
using UPC.Seguridad.BL.BE;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmInsertarUsuario : Form
    {
        private static frmInsertarUsuario frmUsuario = null;

        public frmInsertarUsuario()
        {
            InitializeComponent();
        }

        public static frmInsertarUsuario Instance()
        {
            if (frmUsuario == null)
            {
                frmUsuario = new frmInsertarUsuario();
            }
            return frmUsuario;
        }

        private void frmInsertarUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
