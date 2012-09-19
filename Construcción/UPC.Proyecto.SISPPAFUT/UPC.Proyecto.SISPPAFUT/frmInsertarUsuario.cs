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

        private void LimpiarCampos()
        {
            txtIdentificacion.Text = "";
            txtNombre.Text = "";
            txtApellidoPaterno.Text = "";
            txtApellidoMaterno.Text = "";
            txtContrasenia.Text = "";
            txtRepetirContrasenia.Text = "";
        }

        private void guardar_usuario()
        {
            try
            {
                if (ValidarCampos())
                {
                    if (txtContrasenia.Text == txtRepetirContrasenia.Text)
                    {
                        UsuarioBE objUsuarioBE;
                        UsuarioBC objUsuarioBC;
                        UsuarioRolBC objUsuarioRolBC;

                        objUsuarioBE = new UsuarioBE();
                        objUsuarioBE.NombreUsuario = txtIdentificacion.Text;
                        objUsuarioBE.Nombre = txtNombre.Text;
                        objUsuarioBE.ApellidoPaterno = txtApellidoPaterno.Text;
                        objUsuarioBE.ApellidoMaterno = txtApellidoMaterno.Text;
                        objUsuarioBE.FechaNacimiento = Convert.ToDateTime(dtpFechaNacimiento.Value);
                        objUsuarioBE.Contrasenia = txtContrasenia.Text;

                        objUsuarioBC = new UsuarioBC();
                        objUsuarioRolBC = new UsuarioRolBC();

                        int codNuevoUsuario = 0;
                        codNuevoUsuario = objUsuarioBC.insertar_Usuario(objUsuarioBE);
                        objUsuarioRolBC.asignar_RolUsuario(codNuevoUsuario, 3); //3 es el codigo del rol "CLIENTE"

                        if (codNuevoUsuario != 0)
                        {
                            MessageBox.Show("El usuario ha sido registrado satisfactoriamente.",
                                "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("El usuario no se regsitro debido a un error.",
                                "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Introducir correctamente su contraseña.",
                            "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        txtContrasenia.Text = "";
                        txtRepetirContrasenia.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Todos los campos son obligatorios.", 
                        "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }
    }
}
