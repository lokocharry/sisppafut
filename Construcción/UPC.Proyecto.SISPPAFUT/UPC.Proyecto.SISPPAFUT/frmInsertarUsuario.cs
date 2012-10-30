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
        private string usuario;

        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private int nuevoUser = 0;

        public int NuevoUser
        {
            get { return nuevoUser; }
            set { nuevoUser = value; }
        }

        private static frmInsertarUsuario frmUsuario = null;
        public static frmInsertarUsuario Instance()
        {
            if (frmUsuario == null)
            {
                frmUsuario = new frmInsertarUsuario();
            }
            return frmUsuario;
        }
        public frmInsertarUsuario()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar_usuario();
        }

        private Boolean ValidarCampos()
        {
            Boolean validacion = true;

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
                if (dtpFechaNacimiento.Value.Year > (System.DateTime.Now.Date.Year-18))
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
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
            return validacion;
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
                        UsuarioBC objUsuarioBC = new UsuarioBC();
                        UsuarioRolBC objUsuarioRolBC;

                        if (objUsuarioBC.Verificar_LoginExiste(txtIdentificacion.Text) == 0)
                        {
                            objUsuarioBE = new UsuarioBE();
                            objUsuarioBE.NombreUsuario = txtIdentificacion.Text;
                            objUsuarioBE.Nombre = txtNombre.Text;
                            objUsuarioBE.ApellidoPaterno = txtApellidoPaterno.Text;
                            objUsuarioBE.ApellidoMaterno = txtApellidoMaterno.Text;
                            objUsuarioBE.FechaNacimiento = Convert.ToDateTime(dtpFechaNacimiento.Value);
                            objUsuarioBE.Contrasenia = txtContrasenia.Text;

                            objUsuarioRolBC = new UsuarioRolBC();

                            int codNuevoUsuario = 0;
                            //if(objUsuarioBC.Verificar_LoginUsuario())
                            codNuevoUsuario = objUsuarioBC.insertar_Usuario(objUsuarioBE);
                            if (nuevoUser == 1)
                            {
                                List<UsuarioRolBE> lstUsuarioNuevo = new List<UsuarioRolBE>();
                                UsuarioRolBE objApostadorNuevo = new UsuarioRolBE();
                                objApostadorNuevo.IdUsuario = codNuevoUsuario;
                                objApostadorNuevo.IdRol = 3; //3 es el codigo del rol "CLIENTE"
                                lstUsuarioNuevo.Add(objApostadorNuevo);
                                objUsuarioRolBC.asignar_RolUsuario(lstUsuarioNuevo);
                                //-- Variable para listar las funcionalidades del rol Cliente
                                List<FuncionalidadBE> lstFuncionalidad = new List<FuncionalidadBE>();
                                RolXFuncionalidadBC objRolFunc = new RolXFuncionalidadBC();
                                //-- Listo las funcionalidades del rol Cliente
                                lstFuncionalidad = objRolFunc.Listar_FuncionalidadesXRol(3);
                                //-- Variables para registrar las funcionalidades al cliente nuevo
                                UsuarioFuncionalidadBC objUsuarioFuncion = new UsuarioFuncionalidadBC();
                                List<UsuarioFuncionalidadBE> objUserFunc = new List<UsuarioFuncionalidadBE>();
                                UsuarioFuncionalidadBE objUserFuncBE;
                                //-- Creo una lista de usuariofuncionalidades que debo registrar
                                foreach (FuncionalidadBE cDto in lstFuncionalidad)
                                {
                                    objUserFuncBE = new UsuarioFuncionalidadBE();
                                    objUserFuncBE.idUsuario = codNuevoUsuario;
                                    objUserFuncBE.idFuncionalidad = cDto.idFuncionalidad;
                                    objUserFunc.Add(objUserFuncBE);
                                }
                                if (objUserFunc.Count > 0)
                                {
                                    objUsuarioFuncion.Insertar_UsuarioFuncionalidad(objUserFunc);
                                }
                            }
                            if (codNuevoUsuario != 0)
                            {
                                MessageBox.Show("El usuario ha sido registrado satisfactoriamente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimpiarCampos();
                                if (NuevoUser == 1)
                                {
                                    this.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("El usuario no se registró debido a un error.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El usuario ya existe, use uno diferente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Introducir correctamente su contraseña.","Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        txtContrasenia.Text = "";
                        txtRepetirContrasenia.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Verifique sus datos personales.","Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inCerrar(object sender, FormClosingEventArgs e)
        {
            if (NuevoUser == 0)
            {
                if (MessageBox.Show("¿Seguro que desea salir?", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    e.Cancel = true;
            }
            else
            {
                SISPPAFUTlogin frm = SISPPAFUTlogin.Instance();
                frm.modoFormulario(true);
            }
        }

        private void inControlarTexto(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void InControlarTextNumerico(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }
    }
}
