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
    public partial class frmConsultarHistorialJugador : Form
    {

        List<String> lista_nacionalidades;
        List<JugadorBE> lista_jugadores;

        public frmConsultarHistorialJugador()
        {
            InitializeComponent();
            IniciarNacionalidades();
        }

        private void frmConsultarHistorialJugador_Load(object sender, EventArgs e)
        {

        }

        private static frmConsultarHistorialJugador frmConsultarHistorial= null;
        public static frmConsultarHistorialJugador Instance()
        {
            if (frmConsultarHistorial == null)
            {
                frmConsultarHistorial = new frmConsultarHistorialJugador();
            }
            return frmConsultarHistorial;
        }

        public void IniciarNacionalidades()
        {
            JugadorBC objJugadorBC;

            try
            {
                cmbNacionalidad.Items.Clear();
                objJugadorBC = new JugadorBC();
                lista_nacionalidades = new List<String>();
                lista_nacionalidades = objJugadorBC.listar_Nacionalidades();

                cmbNacionalidad.Items.Add("--- Seleccione una nacionalidad ---");
                cmbNacionalidad.SelectedIndex = 0;

                for (int i = 0; i < lista_nacionalidades.Count; i++)
                {
                    cmbNacionalidad.Items.Add(lista_nacionalidades[i]);
                }                
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void selectedNacionalidad(object sender, EventArgs e)
        {
            JugadorBC objJugadorBC;

            try
            {
                cmbJugador.Items.Clear();
                objJugadorBC = new JugadorBC();
                lista_jugadores = objJugadorBC.listar_JugadoresXNacionalidad(cmbNacionalidad.Text);

                cmbJugador.Items.Add("--- Seleccione un jugador ---");
                cmbJugador.SelectedIndex = 0;

                for (int i = 0; i < lista_jugadores.Count; i++)
                {
                    cmbJugador.Items.Add(lista_jugadores[i].Nombres + " " + lista_jugadores[i].Apellidos);
                }                
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btnConsultarHistorial_Click(object sender, EventArgs e)
        {
            JugadorBC objJugadorBC;
            List<HistorialJugadorBE> lista_historial;
            try
            {
                objJugadorBC = new JugadorBC();
                lista_historial = new List<HistorialJugadorBE>();
                lista_historial = objJugadorBC.listar_HistorialDeJugador(lista_jugadores[cmbJugador.SelectedIndex - 1].CodigoJugador);

                dgvHistorial.Rows.Clear();

                if(lista_historial.Count > 0)
                {
                    foreach (HistorialJugadorBE cDto in lista_historial)
                    {
                        dgvHistorial.Rows.Add(cDto.CodJugador, cDto.NombresJugador, cDto.ApellidosJugador, cDto.NombreEquipo);
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }
    }
}
