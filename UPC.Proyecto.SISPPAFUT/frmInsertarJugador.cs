using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using UPC.Proyecto.SISPPAFUT.BL.BC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmInsertarJugador : Form
    {
        private JugadorBE _Jugador;
        private int _Modo;

        public JugadorBE Jugador
        {
            get { return _Jugador; }
            set { _Jugador = value; }
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

        private void iniciarControles()
        {
            if (_Modo == 1)
            {
                txt_nombre.Enabled = true;
                txt_apellido.Enabled = true;
                txt_nacionalidad.Enabled = true;
                txt_altura.Enabled = true;
                dtp_fecha.Enabled = true;
                txt_peso.Enabled = true;
                cmb_posicion.Enabled = true;
            }
            if (_Modo == 2)
            {
                txt_nombre.Enabled = false;
                txt_apellido.Enabled = false;
                txt_nacionalidad.Enabled = false;
                txt_altura.Enabled = true;
                dtp_fecha.Enabled = false;
                txt_peso.Enabled = true;
                cmb_posicion.Enabled = false;
            }
        }


        private void frmJugadorInsert()
        {
            IniciarPosiciones();
        }

        private void frmJugadorEdit()
        {
            llenarDatosJugador();
        }
        
        private static frmInsertarJugador frmJugador = null;
        public static frmInsertarJugador Instance()
        {
            if (frmJugador == null)
            {
                frmJugador = new frmInsertarJugador();
            }
            return frmJugador;
        }

        public frmInsertarJugador()
        {
            InitializeComponent();
        }

        private void IniciarPosiciones()
        {
            cmb_posicion.Items.Clear();
            cmb_posicion.Items.Add("Seleccione una posición...");
            cmb_posicion.Items.Add("Portero");
            cmb_posicion.Items.Add("Defensa");
            cmb_posicion.Items.Add("Centrocampista");
            cmb_posicion.Items.Add("Delantero");
            cmb_posicion.SelectedIndex = 0;
        }

        private void llenarDatosJugador()
        {
            try
            {
                txt_nombre.Text = _Jugador.Nombres;
                txt_apellido.Text = _Jugador.Apellidos;
                txt_nacionalidad.Text = _Jugador.Nacionalidad;
                dtp_fecha.Value = _Jugador.FechaNacimiento;
                txt_altura.Text = _Jugador.Altura.ToString();
                txt_peso.Text = _Jugador.Peso.ToString() ;

                cmb_posicion.Items.Clear();
                cmb_posicion.Items.Add("Seleccione una posición...");
                cmb_posicion.Items.Add(_Jugador.Posicion);
                cmb_posicion.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }
        
        private void inGuardarJugador(object sender, EventArgs e)
        {
            try
            {
                if (_Modo == 1)
                {
                    guardarJugador();
                }
                else if (_Modo == 2)
                {
                    editarJugador();
                    frmEditarJugador frm = frmEditarJugador.Instance();
                    frm.iniciarJugadores();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void guardarJugador()
        {
            try
            {
                if (ValidarCampos())
                {
                    //-- Basado el la altura máx. alcanzada por el hombre y peso máx. registrado en un jugador de fútbol.
                    if (Convert.ToDouble(txt_altura.Text) <= 2.72 && Convert.ToDouble(txt_peso.Text) <= 165 && dtp_fecha.Value.Date<DateTime.Today)
                    {
                        JugadorBE objJugadorBE;
                        JugadorBC objJugadorBC;

                        objJugadorBE = new JugadorBE();
                        objJugadorBE.Nombres = txt_nombre.Text;
                        objJugadorBE.Apellidos = txt_apellido.Text;
                        objJugadorBE.Nacionalidad = txt_nacionalidad.Text;
                        objJugadorBE.Altura = Convert.ToDecimal(txt_altura.Text);
                        objJugadorBE.Peso = Convert.ToDecimal(txt_peso.Text);
                        objJugadorBE.FechaNacimiento = Convert.ToDateTime(dtp_fecha.Value.Date);
                        objJugadorBE.Posicion = cmb_posicion.Text;

                        objJugadorBC = new JugadorBC();
                        int r = 0;
                        r = objJugadorBC.insertar_Jugador(objJugadorBE);

                        if (r != 0)
                        {
                            MessageBox.Show("El jugador ha sido registrado satisfactoriamente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
                        }
                        else
                            MessageBox.Show("El jugador no ha sido registrado debido a un error.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Corriga la altura y/o peso y/o fecha de nacimiento del jugador .", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void editarJugador()
        {
            try
            {
                if (ValidarCampos())
                {
                    if (Convert.ToDouble(txt_altura.Text) <= 2.72 && Convert.ToDouble(txt_peso.Text) <= 165)
                    {
                        JugadorBC objJugadorBC = new JugadorBC();
                        objJugadorBC.editar_Jugador(Jugador.CodigoJugador, Convert.ToDecimal(txt_altura.Text),
                            Convert.ToDecimal(txt_peso.Text));

                        MessageBox.Show("El jugador ha sido actualizado satisfactoriamente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                    else
                    {
                        MessageBox.Show("Corrija la altura y/o peso del jugador.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private Boolean ValidarCampos()
        {
            return (!(txt_nombre.Text == "") && !(txt_apellido.Text == "")
                    && !(txt_nacionalidad.Text == "") && !(txt_altura.Text == "") 
                    && !(txt_peso.Text == "") && (cmb_posicion.SelectedIndex > 0));
        }

        private void ValidarEntradaNumerico(object sender, KeyPressEventArgs e)
        {
            //-- fuente: http://social.msdn.microsoft.com/Forums/es/vcses/thread/0bfbee6c-219e-4895-a458-ae3d59c81079 --
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;
            for (int i = 0; i < txt_altura.Text.Length; i++)
            {
                if (txt_altura.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void ValidarEntradaNumerica(object sender, KeyPressEventArgs e)
        {
            //-- fuente: http://social.msdn.microsoft.com/Forums/es/vcses/thread/0bfbee6c-219e-4895-a458-ae3d59c81079 --
            if (e.KeyChar == 8){    
                e.Handled = false;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txt_peso.Text.Length; i++)
            {
                if (txt_peso.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void ValidarEntradaNombre(object sender, KeyPressEventArgs e)
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

        private void LimpiarCampos()
        {
            txt_nombre.Clear();
            txt_apellido.Clear();
            txt_nacionalidad.Clear();
            txt_peso.Clear();
            txt_altura.Clear();
            dtp_fecha.Text = DateTime.Today.ToShortDateString();
            IniciarPosiciones();
        }

        private void frmJugadorInsertar_Load(object sender, EventArgs e)
        {
            try
            {
                iniciarControles();
                iniciarModo();
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
