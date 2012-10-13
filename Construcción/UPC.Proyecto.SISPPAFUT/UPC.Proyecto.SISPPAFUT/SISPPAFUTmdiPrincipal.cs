using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UPC.Seguridad.BL.BC;
using UPC.Seguridad.BL.BE;
using UPC.Proyecto.SISPPAFUT.BL.BC;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class SISPPAFUTmdiPrincipal : Form
    {
        public static class Propiedades
        {
            public static string userLogged { get; set; }
        }

        public SISPPAFUTmdiPrincipal()
        {
            InitializeComponent();
            estado_Funcionalidades = new List<int>(); //Valores -> 0: desactivado , 1: activado

            for (int i = 0; i < 27; i++)
                estado_Funcionalidades.Add(0);
            //-- En cada BC asigno el usuario que se logueó
            AmonestacionBC.Propiedades.userLogged = Propiedades.userLogged;
            CompeticionBC.Propiedades.userLogged = Propiedades.userLogged;
            EquipoBC.Propiedades.userLogged = Propiedades.userLogged;
            EstadioBC.Propiedades.userLogged = Propiedades.userLogged;
            GolBC.Propiedades.userLogged = Propiedades.userLogged;
            JugadorBC.Propiedades.userLogged = Propiedades.userLogged;
            JugadorEquipoBC.Propiedades.userLogged = Propiedades.userLogged;
            JugadorPartidoBC.Propiedades.userLogged = Propiedades.userLogged;
            LesionPartidoBC.Propiedades.userLogged = Propiedades.userLogged;
            LigaBC.Propiedades.userLogged = Propiedades.userLogged;
            LigaEquipoBC.Propiedades.userLogged = Propiedades.userLogged;
            PaisBC.Propiedades.userLogged = Propiedades.userLogged;
            PartidoBC.Propiedades.userLogged = Propiedades.userLogged;
            PronosticoClienteBC.Propiedades.userLogged = Propiedades.userLogged;
            RankingEquipoBC.Propiedades.userLogged = Propiedades.userLogged;
            SuspensionBC.Propiedades.userLogged = Propiedades.userLogged;
            TablaPosicionesBC.Propiedades.userLogged = Propiedades.userLogged;
        }
        int CodigoUsuario = 0;
        String NombreUsuario;
        List<FuncionalidadBE> lst_funcionalidades;
        List<int> estado_Funcionalidades;

        private static SISPPAFUTmdiPrincipal frm = null;

        public static SISPPAFUTmdiPrincipal Instance()
        {
            if (frm == null)
                frm = new SISPPAFUTmdiPrincipal();
            return frm;
        }

        public void RecibirCodigoUsuario(int CodigoUsuario)
        {
            this.CodigoUsuario = CodigoUsuario;
        }

        public String Usuario
        {
            get { return NombreUsuario; }
            set { NombreUsuario = value; }
        }

        public void CargarFuncionalidadesUsuario()
        {
            UsuarioFuncionalidadBC objUsuarioFuncionalidadBC;

            try
            {
                objUsuarioFuncionalidadBC = new UsuarioFuncionalidadBC();

                lst_funcionalidades = new List<FuncionalidadBE>();

                lst_funcionalidades = objUsuarioFuncionalidadBC.Listar_FuncionalidadesXUsuario(CodigoUsuario);

                for (int i = 0; i < lst_funcionalidades.Count; i++)
                {
                    estado_Funcionalidades[lst_funcionalidades[i].idFuncionalidad - 1] = 1;
                }

                DiseñarMenu();
                
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        public void DiseñarMenu()
        {
            try
            {
                if (estado_Funcionalidades[0] == 0) //Func 1
                {
                    btnRegistrarPais.Visible = false;
                    btnGestionPaises.Visible = false;
                }

                if (estado_Funcionalidades[1] == 0)//Func 2
                {
                    btnRegistrarCompeticion.Visible = false;
                    btnGestionCompeticion.Visible = false;
                }

                if (estado_Funcionalidades[2] == 0)//Func 3
                {
                    btnNuevaLiga.Visible = false;
                }

                if (estado_Funcionalidades[3] == 0)//Func 4
                {
                    btnTablaPosiciones.Visible = false;
                }

                if (estado_Funcionalidades[2] == 0 && estado_Funcionalidades[3] == 0) //Gestión 
                {
                    btnGestionLigas.Visible = false;
                }

                if (estado_Funcionalidades[4] == 0)//Func 5
                {
                    btnNuevoEstadio.Visible = false;
                    btnGestionEstadios.Visible = false;
                }

                if (estado_Funcionalidades[5] == 0)
                {
                    btnNuevoEquipo.Visible = false;
                }

                if (estado_Funcionalidades[6] == 0)
                {
                    btnEditarEquipo.Visible = false;
                }

                if (estado_Funcionalidades[7] == 0)
                {
                    btnAsignarJugadores.Visible = false;
                }

                if (estado_Funcionalidades[8] == 0)
                {
                    btnActualizarRanking.Visible = false;
                }

                if (estado_Funcionalidades[9] == 0)
                {
                    btnVerRanking.Visible = false;
                }

                if (estado_Funcionalidades[10] == 0)
                {
                    btnEstadisticaEquipo.Visible = false;
                }

                if (estado_Funcionalidades[5] == 0 && estado_Funcionalidades[6] == 0 && estado_Funcionalidades[7] == 0 && estado_Funcionalidades[8] == 0 && estado_Funcionalidades[9] == 0 && estado_Funcionalidades[10] == 0)
                {
                    btnGestionEquipos.Visible = false;
                }

                if (estado_Funcionalidades[11] == 0)
                {
                    btnNuevoJugador.Visible = false;
                }

                if (estado_Funcionalidades[12] == 0)
                {
                    btnEditarJugador.Visible = false;
                }

                if (estado_Funcionalidades[13] == 0)
                {
                    btnTransferirJugador.Visible = false;
                }

                if (estado_Funcionalidades[14] == 0)
                {
                    btnConsultarHistorial.Visible = false;
                }

                if (estado_Funcionalidades[11] == 0 && estado_Funcionalidades[12] == 0 && estado_Funcionalidades[13] == 0 && estado_Funcionalidades[14] == 0)
                {
                    btnGestionJugadores.Visible = false;
                }

                if (estado_Funcionalidades[15] == 0)
                {
                    btnNuevoPartido.Visible = false;
                    btnGestionPartidos.Visible = false;
                }

                if (estado_Funcionalidades[16] == 0)
                {
                    btnListarPartidos.Visible = false;
                    btnGestionDesarrollo.Visible = false;
                }

                if (estado_Funcionalidades[17] == 0)
                {
                    btnEntrenarSistema.Visible = false;
                }

                if (estado_Funcionalidades[18] == 0)
                {
                    btnVerPronostico.Visible = false;
                    btnVisualizacionPronostico.Visible = false;
                }

                if (estado_Funcionalidades[20] == 0)
                {
                    btnNuevoRol.Visible = false;
                }

                if (estado_Funcionalidades[21] == 0)
                {
                    btnNuevaFuncionalidad.Visible = false;
                }

                if (estado_Funcionalidades[22] == 0)
                {
                    btnAsociarRolFuncionalidad.Visible = false;
                }

                if (estado_Funcionalidades[23] == 0)
                {
                    btnAsociarRolUsuario.Visible = false;
                }

                if (estado_Funcionalidades[24] == 0)
                {
                    btnAsociarFuncionalidadUsuario.Visible = false;
                }

                if (estado_Funcionalidades[20] == 0 && estado_Funcionalidades[21] == 0 && estado_Funcionalidades[22] == 0 && estado_Funcionalidades[23] == 0 && estado_Funcionalidades[24] == 0)
                {
                    btnGestionPermisos.Visible = false;
                }

                if (estado_Funcionalidades[25] == 0)
                {
                    btnNuevoCliente.Visible = false;
                    btnRegistroClientes.Visible = false;
                }

                if (estado_Funcionalidades[26] == 0)
                {
                    btnNuevoPronostico.Visible = false;
                }

                if (estado_Funcionalidades[26] == 0 && estado_Funcionalidades[17] == 0)
                {
                    btnEntrenamiento.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void SISPPAFUTmdiPrincipal_Load(object sender, EventArgs e)
        {
            CargarFuncionalidadesUsuario();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrarPais_Click(object sender, EventArgs e)
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

        private void btnRegistrarCompeticion_Click(object sender, EventArgs e)
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

        private void btnNuevaLiga_Click(object sender, EventArgs e)
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

        private void btnTablaPosiciones_Click(object sender, EventArgs e)
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

        private void btnNuevoEstadio_Click(object sender, EventArgs e)
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

        private void btnNuevoEquipo_Click(object sender, EventArgs e)
        {
            try
            {
                frmInsertarEquipo frmEquipo = frmInsertarEquipo.Instance();
                frmEquipo.NombreEquipo = null;
                frmEquipo.Modo = 1;
                frmEquipo.Usuario = Propiedades.userLogged;
                frmEquipo.MdiParent = this;
                frmEquipo.Show();
                frmEquipo.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btnEditarEquipo_Click(object sender, EventArgs e)
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

        private void btnAsignarJugadores_Click(object sender, EventArgs e)
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

        private void btnConsultarHistorial_Click(object sender, EventArgs e)
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

        private void btnActualizarRanking_Click(object sender, EventArgs e)
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

        private void btnVerRanking_Click(object sender, EventArgs e)
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

        private void btnEstadisticaEquipo_Click(object sender, EventArgs e)
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

        private void btnNuevoJugador_Click(object sender, EventArgs e)
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

        private void btnEditarJugador_Click(object sender, EventArgs e)
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

        private void btnTransferirJugador_Click(object sender, EventArgs e)
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

        private void btnNuevoPartido_Click(object sender, EventArgs e)
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

        private void btnListarPartidos_Click(object sender, EventArgs e)
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

        private void btnEntrenarSistema_Click(object sender, EventArgs e)
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

        private void btnVerPronostico_Click(object sender, EventArgs e)
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

        private void btnNuevoCliente_Click(object sender, EventArgs e)
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

        private void btnNuevoRol_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegistrarRol frm = frmRegistrarRol.Instance();

                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btnNuevaFuncionalidad_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegistrarFuncionalidad frm = frmRegistrarFuncionalidad.Instance();

                frm.MdiParent = this;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btnAsociarRolFuncionalidad_Click(object sender, EventArgs e)
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

        private void btnAsociarRolUsuario_Click(object sender, EventArgs e)
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

        private void btnAsociarFuncionalidadUsuario_Click(object sender, EventArgs e)
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

        private void btnNuevoPronostico_Click(object sender, EventArgs e)
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
