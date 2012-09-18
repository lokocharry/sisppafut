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
    public partial class frmRegistrarRol : Form
    {
        public frmRegistrarRol()
        {
            InitializeComponent();
        }

        private static frmRegistrarRol frmRol = null;

        public static frmRegistrarRol Instance()
        {
            if (frmRol == null)
                frmRol = new frmRegistrarRol();
            return frmRol;
        }

        public bool ValidarCampos()
        {
            if (txtNombreRol.Text.Length == 0 || txtNombreRol.Text == " " || txtClaveRol.Text.Length == 0 || txtClaveRol.Text == " " || txtConfirmaClave.Text.Length == 0 || txtConfirmaClave.Text == " " || txtDescripcion.Text.Length == 0 || txtDescripcion.Text == " ")
                return false;
            return true;
        }

        public bool ValidarClaves()
        {
            if (String.Equals(txtConfirmaClave.Text, txtClaveRol.Text) == false)
                return false;
            return true;
        }

        public void LimpiarCampos()
        {
            txtNombreRol.Clear();
            txtClaveRol.Clear();
            txtConfirmaClave.Clear();
            txtDescripcion.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarCampos() == false)
            {
                MessageBox.Show("Complete los campos correctamente");
                return;
            }

            if (ValidarClaves() == false)
            {
                MessageBox.Show("Las claves para el Rol no coinciden");
                return;
            }

            RolBC objRolBC;

            try
            {
                objRolBC = new RolBC();

                String Nombre = txtNombreRol.Text;
                String Clave = txtClaveRol.Text;
                String Descripcion = txtDescripcion.Text;

                int Cantidad = objRolBC.Insertar_Rol(Nombre, Clave, Descripcion);

                if (Cantidad > 0)
                {
                    MessageBox.Show("Se registró el rol satisfactoriamente");
                    LimpiarCampos();
                }
                else if (Cantidad == -1)
                {
                    MessageBox.Show("El rol ingresado ya existe");
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inCerrar(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
        }
    }
}
