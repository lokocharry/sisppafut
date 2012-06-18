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
    public partial class frmEstadisticasEquipo : Form
    {
        List<LigaBE> lista_ligas;
        List<EquipoBE> lista_equipos;
        List<PartidoJugadoBE> lista_partidos;
        List<JugadorBE> lista_jugadores;

        public frmEstadisticasEquipo()
        {
            InitializeComponent();
        }

        private static frmEstadisticasEquipo frmEstadisticaEquipo;
        public static frmEstadisticasEquipo Instance()
        {
            if (frmEstadisticaEquipo == null)
            {
                frmEstadisticaEquipo = new frmEstadisticasEquipo();
            }
            return frmEstadisticaEquipo;
        }

        private void frmEstadisticasEquipo_Load(object sender, EventArgs e)
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

        private void inLigaSeleccionada(object sender, EventArgs e)
        {
            lista_equipos = new List<EquipoBE>();

            EquipoBC objEquipoBC = new EquipoBC();

            if (cmb_liga.SelectedIndex > 0)
                lista_equipos = objEquipoBC.listarEquiposDeLiga(lista_ligas[cmb_liga.SelectedIndex-1].CodigoLiga);

            cmb_equipo.Items.Clear();
            cmb_equipo.Items.Add("(Elija un equipo)");

            for (int i = 0; i < lista_equipos.Count; i++)
                cmb_equipo.Items.Add(lista_equipos[i].NombreEquipo);

            cmb_equipo.SelectedIndex = 0;
        }

        private void btn_refrescar_Click(object sender, EventArgs e)
        {
            lista_partidos = new List<PartidoJugadoBE>();
            lista_jugadores = new List<JugadorBE>();

            PartidoBC objPartidoBC = new PartidoBC();
            dgv_ultimos_partidos.DataSource = objPartidoBC.lista_ultimosPartidos(lista_equipos[cmb_equipo.SelectedIndex - 1].CodigoEquipo, lista_ligas[cmb_liga.SelectedIndex - 1].CodigoLiga);

            JugadorBC objJugadorBC = new JugadorBC();
            lista_jugadores = objJugadorBC.listar_Jugadores_xEquipo(lista_equipos[cmb_equipo.SelectedIndex - 1].CodigoEquipo);

            for (int i = 0; i < dgv_jugadores.Rows.Count; i++)
            {
                dgv_jugadores.Rows.RemoveAt(i);
                i--;
            }

            for (int i = 0; i < lista_jugadores.Count; i++)
            {
                dgv_jugadores.Rows.Add(lista_jugadores[i].Nombres + " " +lista_jugadores[i].Apellidos,
                                       objJugadorBC.cantidadGolesxJugador(lista_jugadores[i].CodigoJugador, lista_ligas[cmb_liga.SelectedIndex-1].CodigoLiga),
                                       objJugadorBC.cantidadPartidosxJugador(lista_jugadores[i].CodigoJugador, lista_ligas[cmb_liga.SelectedIndex - 1].CodigoLiga));
            }
        }
    }
}
