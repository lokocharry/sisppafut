using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UPC.Proyecto.SISPPAFUT
{
    public struct frmTransferir
    {
        static frmTransferir()
        {
            
        }
    }
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
                frmInsertarPais frmPais = frmInsertarPais.Instance();
                frmPais.MdiParent = this;
                frmPais.Show();
                frmPais.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inNuevaCompeticion(object sender, EventArgs e)
        {
            try
            {
                frmInsertarCompeticion frmCompeticion = frmInsertarCompeticion.Instance();
                frmCompeticion.MdiParent = this;
                frmCompeticion.Show();
                frmCompeticion.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inNuevaLiga(object sender, EventArgs e)
        {
            try
            {
                frmInsertarLiga frmLiga = frmInsertarLiga.Instance();
                frmLiga.MdiParent = this;
                frmLiga.Show();
                frmLiga.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inNuevoEstadio(object sender, EventArgs e)
        {
            try
            {
                frmInsertarEstadio frmEstadio = frmInsertarEstadio.Instance();
                frmEstadio.MdiParent = this;
                frmEstadio.Show();
                frmEstadio.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void InNuevoEquipo(object sender, EventArgs e)
        {
            try
            {
                frmInsertarEquipo frmEquipo = frmInsertarEquipo.Instance();
                frmEquipo.NombreEquipo = null;
                frmEquipo.Modo = 1;
                frmEquipo.MdiParent = this;
                frmEquipo.Show();
                frmEquipo.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void InNuevoJugador(object sender, EventArgs e)
        {
            try
            {
                frmInsertarJugador frmJugador = frmInsertarJugador.Instance();
                frmJugador.Jugador = null;
                frmJugador.Modo = 1;
                frmJugador.MdiParent = this;
                frmJugador.Show();
                frmJugador.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void InNuevoPartido(object sender, EventArgs e)
        {
            try
            {
                frmInsertarPartido frmPartido = frmInsertarPartido.Instance();
                frmPartido.Partido = null;
                frmPartido.Modo = 1;
                frmPartido.MdiParent = this;
                frmPartido.Show();
                frmPartido.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
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
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inListarPartidosSinJugar(object sender, EventArgs e)
        {
            try
            {
                frmConsultaPartidosSinJugar frm = frmConsultaPartidosSinJugar.Instance();
                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }        

        private void editarEquipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmEditarEquipo frm = frmEditarEquipo.Instance();
                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void editarJugadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmEditarJugador frm = frmEditarJugador.Instance();
                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void rankingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmActualizarRanking frm = frmActualizarRanking.Instance();
                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void verRankingMundialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmConsultarRankingMundial frm = frmConsultarRankingMundial.Instance();
                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void entrenarSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmModuloEntrenamiento frm = frmModuloEntrenamiento.Instance();
                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void estadísticasDeEquipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmConsultarEstadisticasEquipo frm = frmConsultarEstadisticasEquipo.Instance();
                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inTranferirJugador(object sender, EventArgs e)
        {
            try
            {
                frmInsertarTransferenciaJugador frm = frmInsertarTransferenciaJugador.Instance();
                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inConsultarHistorialJugador(object sender, EventArgs e)
        {
            try
            {
                frmConsultarHistorialJugador frm = frmConsultarHistorialJugador.Instance();

                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inPartidosSinJugar(object sender, EventArgs e)
        {
            try
            {
                frmConsultaPartidosSinJugar frm = frmConsultaPartidosSinJugar.Instance();

                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inVerPronosticosParaApostante(object sender, EventArgs e)
        {
            try
            {
                frmApostadorVerPronosticos frm = frmApostadorVerPronosticos.Instance();

                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void tablaDePosicionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmTablaPosiciones frm = frmTablaPosiciones.Instance();

                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void funcXRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegistrarAsociacionRolFuncionalidad frm = frmRegistrarAsociacionRolFuncionalidad.Instance();

                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void nuevoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmInsertarUsuario frm = frmInsertarUsuario.Instance();

                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void usuarioXFuncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegistrarAsociacionUsuarioFuncionalidad frm = frmRegistrarAsociacionUsuarioFuncionalidad.Instance();

                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void rolXUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegistrarAsociacionRolUsuario frm = frmRegistrarAsociacionRolUsuario.Instance();

                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void registrarPronosticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegistrarPronostico frm = frmRegistrarPronostico.Instance();

                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }        
    }
}
