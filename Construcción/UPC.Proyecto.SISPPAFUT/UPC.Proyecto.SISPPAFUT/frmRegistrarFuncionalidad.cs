using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UPC.Seguridad.BL.BC;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmRegistrarFuncionalidad : Form
    {
        public frmRegistrarFuncionalidad()
        {
            InitializeComponent();
        }

        private static frmRegistrarFuncionalidad frmFuncionalidad = null;

        public static frmRegistrarFuncionalidad Instance()
        {
            if (frmFuncionalidad == null)
                frmFuncionalidad = new frmRegistrarFuncionalidad();

            return frmFuncionalidad;
        }

        public bool ValidarControles()
        {
            if (txtNombreFuncionalidad.Text == " " || txtNombreFuncionalidad.Text.Length == 0 || txtDescripcionFuncionalidad.Text == " " || txtDescripcionFuncionalidad.Text.Length == 0)
                return false;
            return true;
        }

        public void LimpiarCampos()
        {
            txtDescripcionFuncionalidad.Clear();
            txtNombreFuncionalidad.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarControles() == false)
            {
                MessageBox.Show("Complete los campos corretamente");
                return;
            }

            FuncionalidadBC objFuncionalidadBC;            

            try
            {
                String Nombre = txtNombreFuncionalidad.Text;
                String Descripcion = txtDescripcionFuncionalidad.Text;

                objFuncionalidadBC = new FuncionalidadBC();

                int Cantidad = objFuncionalidadBC.Insertar_Funcionalidad(Nombre, Descripcion);

                if (Cantidad > 0)
                { 
                    MessageBox.Show("Se registró la funcionalidad correctamente");
                    LimpiarCampos();
                }
                else if(Cantidad == -1)
                    MessageBox.Show("La funcionalidad ingresada ya existe");


            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void frmRegistrarFuncionalidad_Load(object sender, EventArgs e)
        {

        }
    }
}
