using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class SISPPAFUTmdi : Form
    {
        private static SISPPAFUTmdi MDI = null;
        public static SISPPAFUTmdi Instance()
        {
            if (MDI == null)
            {
                MDI = new SISPPAFUTmdi();
            }
            return MDI;
        }

        public SISPPAFUTmdi()
        {
            InitializeComponent();

        }

        private void inNuevoPais(object sender, EventArgs e)
        {
            try
            {
                frmPaisInsertar frmPais = frmPaisInsertar.Instance();
                frmPais.MdiParent = this;
                frmPais.Show();
                frmPais.BringToFront();
            }
            catch (Exception ex)
            {
                //Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inNuevaCompeticion(object sender, EventArgs e)
        {
            try
            {
                frmCompeticionInsertar frmCompeticion = frmCompeticionInsertar.Instance();
                frmCompeticion.MdiParent = this;
                frmCompeticion.Show();
                frmCompeticion.BringToFront();
            }
            catch (Exception ex)
            {
                //Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inNuevaLiga(object sender, EventArgs e)
        {
            try
            {
                frmLigaInsertar frmLiga = frmLigaInsertar.Instance();
                frmLiga.MdiParent = this;
                frmLiga.Show();
                frmLiga.BringToFront();
            }
            catch (Exception ex)
            {
                //Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inNuevoEstadio(object sender, EventArgs e)
        {
            try
            {
                frmEstadioInsertar frmEstadio = frmEstadioInsertar.Instance();
                frmEstadio.MdiParent = this;
                frmEstadio.Show();
                frmEstadio.BringToFront();
            }
            catch (Exception ex)
            {
                //Funciones.RegistrarExcepcion(ex);
            }
        }

        private void InNuevoEquipo(object sender, EventArgs e)
        {
            try
            {
                frmEquipoInsertar frmEquipo = frmEquipoInsertar.Instance();
                frmEquipo.NombreEquipo = null;
                frmEquipo.Modo = 1;
                frmEquipo.MdiParent = this;
                frmEquipo.Show();
                frmEquipo.BringToFront();
            }
            catch (Exception ex)
            {
                //Funciones.RegistrarExcepcion(ex);
            }
        }

        private void InNuevoJugador(object sender, EventArgs e)
        {
            try
            {
                frmJugadorInsertar frmJugador = frmJugadorInsertar.Instance();
                frmJugador.Jugador = null;
                frmJugador.Modo = 1;
                frmJugador.MdiParent = this;
                frmJugador.Show();
                frmJugador.BringToFront();
            }
            catch (Exception ex)
            {
                //Funciones.RegistrarExcepcion(ex);
            }
        }

        private void InNuevoPartido(object sender, EventArgs e)
        {
            try
            {
                frmPartidoInsertar frmPartido = frmPartidoInsertar.Instance();
                frmPartido.Partido = null;
                frmPartido.Modo = 1;
                frmPartido.MdiParent = this;
                frmPartido.Show();
                frmPartido.BringToFront();
            }
            catch (Exception ex)
            {
                //Funciones.RegistrarExcepcion(ex);
            }
        }

        private void InSalir(object sender, EventArgs e)
        {
            this.Close();
        }

        private void inAsignarJugadores(object sender, EventArgs e)
        {
            try
            {
                frmAsignarJugadoresaEquipo frm = frmAsignarJugadoresaEquipo.Instance();
                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                //Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inListarPartidosSinJugar(object sender, EventArgs e)
        {
            try
            {
                frmListaPartidosSinJugar frm = frmListaPartidosSinJugar.Instance();
                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                //Funciones.RegistrarExcepcion(ex);
            }
        }

        private void editarEquipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmEditarEquipos frm = frmEditarEquipos.Instance();
                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                //Funciones.RegistrarExcepcion(ex);
            }
        }

        private void editarJugadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmEditarJugadores frm = frmEditarJugadores.Instance();
                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                //Funciones.RegistrarExcepcion(ex);
            }
        }
    }
}
