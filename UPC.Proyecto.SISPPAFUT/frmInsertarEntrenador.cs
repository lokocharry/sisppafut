using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.BL.BC;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmInsertarEntrenador : Form
    {
        public frmInsertarEntrenador()
        {
            InitializeComponent();
        }

        EntrenadorBE objEntrenadorBE;
        private static frmInsertarEntrenador frm = null;
        private int _Modo;
        public static frmInsertarEntrenador Instance()
        {
            if (frm == null)
                frm = new frmInsertarEntrenador();
            return frm;
        }

        public int Modo
        {
            get { return _Modo; }
            set { _Modo = value; }
        }

        private void iniciarModo()
        {
            switch (_Modo)
            {
                case 1: //Insertar
                    frmJugadorInsert();
                    break;
                case 2: //Editar
                    frmJugadorEdit();
                    break;
            }
        }

        public void IniciarPosiciones()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtNacionalidad.Clear();
        }

        public void RecibirEntrandor(EntrenadorBE objEntrenadorBE)
        {
            this.objEntrenadorBE = objEntrenadorBE;
        }

        private void frmJugadorInsert()
        {
            IniciarPosiciones();
        }

        public void CargarDatos()
        {
            txtNombres.Text = objEntrenadorBE.Nombres;
            txtApellidos.Text = objEntrenadorBE.Apellidos;
            txtNacionalidad.Text = objEntrenadorBE.Nacionalidad;
            cmbFecha.Value = objEntrenadorBE.Fecha;
        }

        public void BloquearCampos()
        {
            txtNombres.Enabled = false;
            txtApellidos.Enabled = false;
            txtNacionalidad.Enabled = false;
        }

        private void frmJugadorEdit()
        {
            CargarDatos();
            BloquearCampos();
        }

        private void frmRegistrarEntrenador_Load(object sender, EventArgs e)
        {
            iniciarModo();
        }

        public void LimpiarCampos()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtNacionalidad.Clear();
        }

        public bool ValidarCampos()
        {
            if (txtApellidos.Text.Length == 0 || txtApellidos.Text == " " ||
                txtNacionalidad.Text.Length == 0 || txtNacionalidad.Text == " " ||
                txtNombres.Text.Length == 0 || txtNombres.Text == " ")
                return false;
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EntrenadorBC objEntrenadorBC;

            if (ValidarCampos() == false)
            {
                MessageBox.Show("Debe llenar todos los campos.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                objEntrenadorBC = new EntrenadorBC();
                if (cmbFecha.Value.Year < (DateTime.Today.Year - 18))
                {
                    if (_Modo == 1)
                    {
                        EntrenadorBE objEntrenadorBE;
                        objEntrenadorBE = new EntrenadorBE();

                        objEntrenadorBE.Apellidos = txtApellidos.Text;
                        objEntrenadorBE.Fecha = cmbFecha.Value;
                        objEntrenadorBE.Nacionalidad = txtNacionalidad.Text;
                        objEntrenadorBE.Nombres = txtNombres.Text;

                        int result = objEntrenadorBC.RegistrarEntrenador(objEntrenadorBE);
                        LimpiarCampos();
                        if (result != 0)
                            MessageBox.Show("Se registró el entrenador.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else if (_Modo == 2)
                    {
                        objEntrenadorBE.Fecha = cmbFecha.Value;
                        objEntrenadorBC.ActualizarEntrenador(objEntrenadorBE);
                        MessageBox.Show("Se actualizó el entrenador.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe verifique la edad del entrenador.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void inValidarTexto(object sender, KeyPressEventArgs e)
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
    }
}
