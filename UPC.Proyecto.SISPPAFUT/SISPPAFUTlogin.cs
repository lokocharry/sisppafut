using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using UPC.Seguridad.BL.BC;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.BL.BC;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class SISPPAFUTlogin : Form
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        private static SISPPAFUTlogin frmLogin = null;
        public static SISPPAFUTlogin Instance()
        {
            if (frmLogin == null)
            {
                frmLogin = new SISPPAFUTlogin();
            }
            return frmLogin;
        }

        public SISPPAFUTlogin()
        {
            InitializeComponent();
        }

        private void inCerrar(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
        }

        private void RegistrarNuevoApostador(object sender, LinkLabelLinkClickedEventArgs e)
        {            
            try
            {
                frmInsertarUsuario frm = frmInsertarUsuario.Instance();
                UsuarioBC.Propiedades.userLogged = "guest";
                UsuarioRolBC.Propiedades.userLogged = "guest";
                UsuarioFuncionalidadBC.Propiedades.userLogged = "guest";
                FuncionalidadBC.Propiedades.userLogged = "guest";
                RolXFuncionalidadBC.Propiedades.userLogged = "guest";
                frm.NuevoUser = 1;
                frm.Show();
                frm.BringToFront();
                modoFormulario(false);
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {                
                String usuario = txtUsuario.Text;
                String contrasenia = txtContrasenia.Text;

                SISPPAFUTlogin.Propiedades.userLogged = usuario;
                SISPPAFUTmdiPrincipal.Propiedades.userLogged = SISPPAFUTlogin.Propiedades.userLogged;

                UsuarioBC objUsuarioBC = new UsuarioBC();

                int idUsuario = objUsuarioBC.Verificar_LoginUsuario(usuario, contrasenia);

                if (idUsuario <= 0)
                {
                    MessageBox.Show("Datos de login incorrectos. Verifique sus datos");
                    txtContrasenia.Clear();
                    return;
                }                                
                
                SISPPAFUTmdiPrincipal frm = SISPPAFUTmdiPrincipal.Instance();
                frm.RecibirCodigoUsuario(idUsuario);
                frm.Usuario = SISPPAFUTlogin.Propiedades.userLogged;
                
                frm.Show();
                frm.BringToFront();
                txtUsuario.Clear();
                txtContrasenia.Clear();
                modoFormulario(false);
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        public void modoFormulario(Boolean estado)
        {
            Visible = estado;
        }
    }
}
