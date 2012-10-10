using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using UPC.Seguridad.BL.BC;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class SISPPAFUTlogin : Form
    {
        public SISPPAFUTlogin()
        {
            InitializeComponent();
        }

        private void inCerrar(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInsertarUsuario frm = frmInsertarUsuario.Instance();

            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                String usuario = txtUsuario.Text;
                String contrasenia = txtContrasenia.Text;

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
                frm.Usuario = usuario;
                frm.Show();
                frm.BringToFront();

                txtUsuario.Clear();
                txtContrasenia.Clear();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }
    }
}
