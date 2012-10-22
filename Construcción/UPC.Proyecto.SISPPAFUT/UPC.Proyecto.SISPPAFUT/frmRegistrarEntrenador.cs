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
    public partial class frmRegistrarEntrenador : Form
    {
        public frmRegistrarEntrenador()
        {
            InitializeComponent();
        }

        EntrenadorBE objEntrenadorBE;
        private static frmRegistrarEntrenador frm = null;
        private int _Modo;
        public static frmRegistrarEntrenador Instance()
        {
            if (frm == null)
                frm = new frmRegistrarEntrenador();
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

        private void frmJugadorEdit()
        {
            CargarDatos();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EntrenadorBC objEntrenadorBC;
            EntrenadorBE objEntrenadorBE;
            try
            {
                objEntrenadorBC = new EntrenadorBC();
                objEntrenadorBE = new EntrenadorBE();

                objEntrenadorBE.Apellidos = txtApellidos.Text;
                objEntrenadorBE.Fecha = cmbFecha.Value;
                objEntrenadorBE.Nacionalidad = txtNacionalidad.Text;
                objEntrenadorBE.Nombres = txtNombres.Text;

                if (_Modo == 1)
                {
                    objEntrenadorBC.RegistrarEntrenador(objEntrenadorBE);
                    LimpiarCampos();
                }
                else if (_Modo == 2)
                    objEntrenadorBC.ActualizarEntrenador(objEntrenadorBE);
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
