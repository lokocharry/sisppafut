using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.BL.BC;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmConsultarEstadisticasEquipo : Form
    {
        List<LigaBE> lista_ligas;
        List<EquipoBE> lista_equipos;
        List<PartidoJugadoBE> lista_partidos;
        List<JugadorBE> lista_jugadores;

        public frmConsultarEstadisticasEquipo()
        {
            InitializeComponent();
        }

        private static frmConsultarEstadisticasEquipo frmEstadisticaEquipo;
        public static frmConsultarEstadisticasEquipo Instance()
        {
            if (frmEstadisticaEquipo == null)
            {
                frmEstadisticaEquipo = new frmConsultarEstadisticasEquipo();
            }
            return frmEstadisticaEquipo;
        }

        private void frmEstadisticasEquipo_Load(object sender, EventArgs e)
        {
            iniciarGrillaUltimosPartidos();
            iniciarGrillaJugadores();
            IniciarLigas();
        }

        public void iniciarGrillaUltimosPartidos()
        {
            try
            {
                dgv_ultimos_partidos.AllowUserToAddRows = false;
                dgv_ultimos_partidos.AllowUserToDeleteRows = false;
                dgv_ultimos_partidos.AllowUserToResizeColumns = false;
                dgv_ultimos_partidos.AllowUserToResizeRows = false;

                dgv_ultimos_partidos.AllowDrop = false;

                dgv_ultimos_partidos.MultiSelect = false; //-- Se protege la grilla para evitar seleccionar varios registros

                dgv_ultimos_partidos.ReadOnly = true; //-- Se protege la grilla para evitar poder modificar los datos de la grilla

                // Lo siguiente es para elegir toda la fila selecionada
                dgv_ultimos_partidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dgv_ultimos_partidos.Columns[0].Visible = true;
                dgv_ultimos_partidos.Columns[1].Visible = true;
                dgv_ultimos_partidos.Columns[2].Visible = true;
                dgv_ultimos_partidos.Columns[3].Visible = true;

                DataGridViewCellStyle csFilaPar = new DataGridViewCellStyle();
                DataGridViewCellStyle csFilaImpar = new DataGridViewCellStyle();

                csFilaPar.BackColor = dgv_ultimos_partidos.BackgroundColor;
                csFilaImpar.BackColor = dgv_ultimos_partidos.GridColor;

                int elemento;

                for (elemento = 0; elemento < dgv_ultimos_partidos.Rows.Count; elemento++)
                {
                    if (elemento % 2 == 0)
                    {
                        dgv_ultimos_partidos.Rows[elemento].DefaultCellStyle = csFilaPar;
                    }
                    else
                    {
                        dgv_ultimos_partidos.Rows[elemento].DefaultCellStyle = csFilaImpar;
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        public void iniciarGrillaJugadores()
        {
            try
            {
                dgv_jugadores.AllowUserToAddRows = false;
                dgv_jugadores.AllowUserToDeleteRows = false;
                dgv_jugadores.AllowUserToResizeColumns = false;
                dgv_jugadores.AllowUserToResizeRows = false;

                dgv_jugadores.AllowDrop = false;

                dgv_jugadores.MultiSelect = false; //-- Se protege la grilla para evitar seleccionar varios registros

                dgv_jugadores.ReadOnly = true; //-- Se protege la grilla para evitar poder modificar los datos de la grilla

                // Lo siguiente es para elegir toda la fila selecionada
                dgv_jugadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dgv_jugadores.Columns[0].Visible = true;
                dgv_jugadores.Columns[1].Visible = true;
                dgv_jugadores.Columns[2].Visible = true;

                DataGridViewCellStyle csFilaPar = new DataGridViewCellStyle();
                DataGridViewCellStyle csFilaImpar = new DataGridViewCellStyle();

                csFilaPar.BackColor = dgv_jugadores.BackgroundColor;
                csFilaImpar.BackColor = dgv_jugadores.GridColor;

                int elemento;

                for (elemento = 0; elemento < dgv_jugadores.Rows.Count; elemento++)
                {
                    if (elemento % 2 == 0)
                    {
                        dgv_jugadores.Rows[elemento].DefaultCellStyle = csFilaPar;
                    }
                    else
                    {
                        dgv_jugadores.Rows[elemento].DefaultCellStyle = csFilaImpar;
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void IniciarLigas()
        {
            try
            {
                lista_ligas = new List<LigaBE>();
                LigaBC objLigaBC = new LigaBC();
                lista_ligas = objLigaBC.listarLigas();

                cmb_liga.Items.Clear();
                cmb_liga.Items.Add("(Elija una liga)");

                for (int i = 0; i < lista_ligas.Count; i++)
                    cmb_liga.Items.Add(lista_ligas[i].NombreLiga);

                cmb_liga.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inLigaSeleccionada(object sender, EventArgs e)
        {
            try
            {
                lista_equipos = new List<EquipoBE>();

                EquipoBC objEquipoBC = new EquipoBC();

                if (cmb_liga.SelectedIndex > 0)
                    lista_equipos = objEquipoBC.listarEquiposDeLiga(lista_ligas[cmb_liga.SelectedIndex - 1].CodigoLiga);

                cmb_equipo.Items.Clear();
                cmb_equipo.Items.Add("(Elija un equipo)");

                for (int i = 0; i < lista_equipos.Count; i++)
                    cmb_equipo.Items.Add(lista_equipos[i].NombreEquipo);

                cmb_equipo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btn_refrescar_Click(object sender, EventArgs e)
        {
            try
            {
                lista_partidos = new List<PartidoJugadoBE>();
                lista_jugadores = new List<JugadorBE>();

                PartidoBC objPartidoBC = new PartidoBC();
                if (cmb_equipo.SelectedIndex > 0 && cmb_liga.SelectedIndex > 0)
                {
                    lista_partidos = objPartidoBC.lista_ultimosPartidos(lista_equipos[cmb_equipo.SelectedIndex - 1].CodigoEquipo, lista_ligas[cmb_liga.SelectedIndex - 1].CodigoLiga, DateTime.Today.Date);
                    JugadorBC objJugadorBC = new JugadorBC();
                    lista_jugadores = objJugadorBC.listar_Jugadores_xEquipo(lista_equipos[cmb_equipo.SelectedIndex - 1].CodigoEquipo);

                    if (lista_partidos.Count > 0)
                    {
                        dgv_ultimos_partidos.Rows.Clear();
                        for (int i = 0; i < lista_partidos.Count; i++)
                        {
                            dgv_ultimos_partidos.Rows.Add(lista_partidos[i].Equipo_local,
                                                          lista_partidos[i].Equipo_visita,
                                                          lista_partidos[i].Goles_local + " - " + lista_partidos[i].Goles_visita,
                                                          Convert.ToDateTime(lista_partidos[i].Fecha).ToShortDateString());
                        }

                        dgv_jugadores.Rows.Clear();
                        for (int i = 0; i < lista_jugadores.Count; i++)
                        {
                            dgv_jugadores.Rows.Add(lista_jugadores[i].Nombres + " " + lista_jugadores[i].Apellidos,
                                                   objJugadorBC.cantidadGolesxJugador(lista_jugadores[i].CodigoJugador, lista_ligas[cmb_liga.SelectedIndex - 1].CodigoLiga),
                                                   objJugadorBC.cantidadPartidosxJugador(lista_jugadores[i].CodigoJugador, lista_ligas[cmb_liga.SelectedIndex - 1].CodigoLiga));
                        }
                    }
                    else
                        MessageBox.Show("No hay datos para mostrar.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Debe seleccionar todos los campos.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
