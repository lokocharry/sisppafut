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
    public partial class frmInsertarTransferenciaJugador : Form
    {
        List<PaisBE> lista_paises;
        List<EquipoBE> lista_equipos;
        List<JugadorBE> lista_jugadores;

        List<PaisBE> lst_paises;
        List<EquipoBE> lst_equiposTransf;

        int modoTransf = 0;

        public int ModoTransf
        {
            get { return modoTransf; }
            set { modoTransf = value; }
        }

        public frmInsertarTransferenciaJugador()
        {
            InitializeComponent();
            iniciarPais();
            iniciarPaisTransf();
        }

        private static frmInsertarTransferenciaJugador frmTransferirJugador = null;
        public static frmInsertarTransferenciaJugador Instance()
        {
            if (frmTransferirJugador == null)
            {
                frmTransferirJugador = new frmInsertarTransferenciaJugador();
            }
            return frmTransferirJugador;
        }

        private void iniciarPais()
        {
            try
            {
                PaisBC objPaisBC = new PaisBC();
                lista_paises = new List<PaisBE>();
                lista_paises = objPaisBC.listarPaises();

                cmbPais.Items.Clear();
                cmbPais.Items.Add("Seleccione un pais...");
                cmbPais.SelectedIndex = 0;

                for (int i = 0; i < lista_paises.Count; i++)
                {
                    cmbPais.Items.Add(lista_paises[i].NombrePais);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inSeleccionPais(object sender, EventArgs e)
        {
            if (cmbPais.SelectedIndex > 0)
            {
                iniciarEquipos();
            }
            else
                if (cmbPais.SelectedIndex == 0)
                    cmbEquipo.Items.Clear();
        }

        public void iniciarEquipos()
        {
            try
            {
                cmbEquipo.Items.Clear();

                EquipoBC objEquipoBC = new EquipoBC();
                lista_equipos = new List<EquipoBE>();

                cmbEquipo.Items.Add("Seleccione un equipo...");

                lista_equipos = objEquipoBC.listarEquipos(lista_paises[cmbPais.SelectedIndex - 1].NombrePais);
                for (int i = 0; i < lista_equipos.Count; i++)
                {
                    cmbEquipo.Items.Add(lista_equipos[i].NombreEquipo);
                }

                cmbEquipo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void InSeleccionEquipo(object sender, EventArgs e)
        {
            if (cmbEquipo.SelectedIndex > 0)
            {
                iniciarJugadores();
            }
            else
                if (cmbEquipo.SelectedIndex == 0)
                    cmbJugador.Items.Clear();
        }

        public void iniciarJugadores()
        {
            try
            {
                cmbJugador.Items.Clear();

                cmbJugador.Items.Add("Seleccione un jugador...");

                JugadorBC objJugadorBC = new JugadorBC();
                lista_jugadores = new List<JugadorBE>();

                lista_jugadores = objJugadorBC.listar_Jugadores_xEquipo(lista_equipos[cmbEquipo.SelectedIndex - 1].CodigoEquipo);
                for (int i = 0; i < lista_jugadores.Count; i++)
                {
                    cmbJugador.Items.Add(String.Format("{0} {1}", lista_jugadores[i].Nombres, lista_jugadores[i].Apellidos));
                }

                cmbJugador.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void iniciarPaisTransf()
        {
            try
            {
                PaisBC objPaisBC = new PaisBC();
                lst_paises = new List<PaisBE>();
                lst_paises = objPaisBC.listarPaises();

                cmbPaisTransf.Items.Clear();
                cmbPaisTransf.Items.Add("Seleccione un pais...");
                cmbPaisTransf.SelectedIndex = 0;

                for (int i = 0; i < lst_paises.Count; i++)
                {
                    cmbPaisTransf.Items.Add(lst_paises[i].NombrePais);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inSeleccionPaisTransf(object sender, EventArgs e)
        {
            if (cmbPaisTransf.SelectedIndex > 0)
            {
                iniciarEquiposTransf();
            }
            else
                if (cmbPaisTransf.SelectedIndex == 0)
                    cmbEquipoTransf.Items.Clear();
        }

        public void iniciarEquiposTransf()
        {
            try
            {
                cmbEquipoTransf.Items.Clear();

                EquipoBC objEquipoBC = new EquipoBC();
                lst_equiposTransf = new List<EquipoBE>();

                cmbEquipoTransf.Items.Add("Seleccione un país...");

                lst_equiposTransf = objEquipoBC.listarEquipos(lst_paises[cmbPaisTransf.SelectedIndex - 1].NombrePais);
                for (int i = 0; i < lst_equiposTransf.Count; i++)
                {
                    cmbEquipoTransf.Items.Add(lst_equiposTransf[i].NombreEquipo);
                }

                cmbEquipoTransf.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void InSeleccionEquipoTransf(object sender, EventArgs e)
        {
            if (cmbEquipoTransf.SelectedIndex > 0)
            {
                modoTransf = 1;
                cbLiberar.Checked = false;
            }
            else
                modoTransf = ModoTransf;
        }

        private void inSeleccionSinEquipo(object sender, EventArgs e)
        {
            if (cbLiberar.Checked)
            {
                modoTransf = 2;
                cmbEquipoTransf.Text = "";
                cmbEquipoTransf.Items.Clear();
                cmbPaisTransf.SelectedIndex = 0;
            }
            else
                modoTransf = ModoTransf;
        }

        private bool ValidarFormulario()
        {
            if (cmbEquipo.SelectedIndex <= 0 || cmbEquipoTransf.SelectedIndex <= 0 || cmbJugador.SelectedIndex <= 0 || cmbPais.SelectedIndex <= 0 || cmbPaisTransf.SelectedIndex <= 0)
                return false;
            return true;
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            JugadorBC objJugadorBC = new JugadorBC();

            try
            {
                if (ValidarFormulario() == false)
                {
                    MessageBox.Show("Complete los datos solicitados");
                    return;
                }

                objJugadorBC.transferirJugadorNuevoEquipo(lista_jugadores[cmbJugador.SelectedIndex - 1].CodigoJugador, lst_equiposTransf[cmbEquipoTransf.SelectedIndex - 1].CodigoEquipo);

                cmbPais.SelectedIndex = 0;
                cmbEquipo.Items.Clear();
                cmbEquipo.Text = "Seleccione un equipo...";
                cmbJugador.Items.Clear();
                cmbJugador.Text = "Seleccione un jugador...";
                cmbPaisTransf.SelectedIndex = 0;
                cmbEquipoTransf.Items.Clear();
                cmbEquipoTransf.Text = "Seleccione un equipo...";

                MessageBox.Show("La transferencia se realizó con éxito");

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
