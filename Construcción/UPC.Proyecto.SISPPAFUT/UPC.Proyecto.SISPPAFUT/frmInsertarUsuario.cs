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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar_usuario();
        }

        private bool ValidarCampos()
        {
            bool validacion = true;

            try
            {
                if (txtIdentificacion.Text == "" || txtIdentificacion.Text.Length > 40)
                {
                    validacion = false;
                }
                if (txtNombre.Text == "" || txtNombre.Text.Length > 50)
                {
                    validacion = false;
                }
                if (txtApellidoPaterno.Text == "" || txtApellidoPaterno.Text.Length > 50)
                {
                    validacion = false;
                }
                if (txtApellidoMaterno.Text == "" || txtApellidoMaterno.Text.Length > 50)
                {
                    validacion = false;
                }
                if (dtpFechaNacimiento.Value > System.DateTime.Now.Date)
                {
                    validacion = false;
                }
                if (txtContrasenia.Text == "" || txtContrasenia.Text.Length > 15)
                {
                    validacion = false;
                }
                if (txtRepetirContrasenia.Text == "" || txtRepetirContrasenia.Text.Length > 15)
                {
                    validacion = false;
                }
                
                return validacion;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void guardar_usuario()
        {
            try
            {
                if (ValidarCampos())
                {

                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }
    }
}
