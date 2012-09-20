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
    public partial class frmInsertarPartido : Form
    {
        //--Área de variables globales
        List<PaisBE> lista_paises;
        List<CompeticionBE> lista_competiciones;
        List<EquipoBE> lista_equipos;
        List<EstadioBE> lista_estadios;
        List<LigaBE> lista_temporadas;
        int _Modo;
        PartidoSinJugarBE _Partido;

        public int Modo
        {
            get { return _Modo; }
            set { _Modo = value; }
        }
        public PartidoSinJugarBE Partido
        {
            get { return _Partido; }
            set { _Partido = value; }
        }

        private static frmInsertarPartido frmPartido = null;
        public static frmInsertarPartido Instance()
        {
            if (frmPartido == null)
            {
                frmPartido = new frmInsertarPartido();
            }
            return frmPartido;
        }

        private void iniciarModo()
        {
            if (_Modo == 1)
            {
                frmPartidoInsert();
            }
            else if (_Modo == 2)
            {
                frmPartidoEdit();
            }
        }

        private void iniciarControles()
        {
            if (_Modo == 1)
            {
                cmb_pais.Enabled = true;
                cmb_competicion.Enabled = true;
                cmb_temporada.Enabled = true;
                cmb_local.Enabled = true;
                cmb_visitante.Enabled = true;
                cmb_estadio.Enabled = true;
                dtp_fecha.Enabled = true;
            }
            if (_Modo == 2)
            {
                cmb_pais.Enabled = false;
                cmb_competicion.Enabled = false;
                cmb_temporada.Enabled = false;
                cmb_local.Enabled = false;
                cmb_visitante.Enabled = false;
                cmb_estadio.Enabled = false;
                dtp_fecha.Enabled = true;

                lbl_liga.Visible = false;
                cmb_temporada.Visible = false;
                lbl_competicion.Text = "Liga:";
            }
        }

        public frmInsertarPartido()
        {
            InitializeComponent();
        }

        private void frmPartidoInsert()
        {
            iniciar_pais();
        }

        private void frmPartidoEdit()
        {
            llenarDatosPartido();
        }

        private void llenarDatosPartido()
        {
            try
            {
                PartidoBC objPartidoBC = new PartidoBC();
                PartidoBE objPartidoBE = objPartidoBC.obtener_Partido(Partido.Codigo_partido);

                cmb_pais.Items.Clear();
                cmb_pais.Items.Add(Partido.Pais);
                cmb_pais.SelectedIndex = 0;

                cmb_competicion.Items.Clear();
                cmb_competicion.Items.Add(Partido.Liga);
                cmb_competicion.SelectedIndex = 0;

                cmb_local.Items.Clear();
                cmb_local.Items.Add(Partido.Equipo_local);
                cmb_local.SelectedIndex = 0;

                cmb_visitante.Items.Clear();
                cmb_visitante.Items.Add(Partido.Equipo_visitante);
                cmb_visitante.SelectedIndex = 0;

                dtp_fecha.Value = Partido.Fecha;

                lista_estadios = new List<EstadioBE>();
                EstadioBC objEstadioBC = new EstadioBC();

                lista_estadios = objEstadioBC.listarEstadios();
                for (int i = 0; i < lista_estadios.Count; i++)
                {
                    if (lista_estadios[i].Codigo_estadio == objPartidoBE.Codigo_estadio)
                    {
                        cmb_estadio.Items.Clear();
                        cmb_estadio.Items.Add(lista_estadios[i].Nombre_estadio);
                        cmb_estadio.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void iniciar_pais()
        {
            try
            {
                cmb_pais.Items.Clear();
                cmb_pais.Items.Add("(Seleccione un equipo)");
                cmb_pais.SelectedIndex = 0;
                lista_paises = new List<PaisBE>();
                PaisBC objPaisBC = new PaisBC();

                lista_paises = objPaisBC.listarPaises();

                for (int i = 0; i < lista_paises.Count; i++)
                {
                    cmb_pais.Items.Add(lista_paises[i].NombrePais);
                }

            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        //Metodo temporal
        private void iniciar_equipos()
        {
            try
            {
                cmb_local.Items.Clear();
                cmb_local.Items.Add("(Seleccione un equipo)");
                cmb_local.SelectedIndex = 0;

                cmb_visitante.Items.Clear();
                cmb_visitante.Items.Add("(Seleccione un equipo)");
                cmb_visitante.SelectedIndex = 0;

                //-- No se muestran equipos ya que no se ha seleccionado ni competición ni temporada
                cmb_estadio.Items.Clear();

                lista_equipos = new List<EquipoBE>();
                EquipoBC objEquipoBC = new EquipoBC();

                lista_equipos = objEquipoBC.listarEquiposDeLiga(lista_temporadas[cmb_temporada.SelectedIndex - 1].CodigoLiga);

                for (int i = 0; i < lista_equipos.Count; i++)
                {
                    cmb_local.Items.Add(lista_equipos[i].NombreEquipo);
                    cmb_visitante.Items.Add(lista_equipos[i].NombreEquipo);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void iniciar_competicion()
        {
            try
            {
                cmb_competicion.Items.Clear();
                cmb_competicion.Items.Add("(Seleccione una competicion)");
                cmb_competicion.SelectedIndex = 0;

                //-- No se muestran equipos ya que no se ha seleccionado ni competición ni temporada
                cmb_local.Items.Clear();
                cmb_visitante.Items.Clear();
                cmb_estadio.Items.Clear();
                cmb_temporada.Items.Clear();

                lista_competiciones = new List<CompeticionBE>();
                CompeticionBC objCompeticionBC = new CompeticionBC();
                
                lista_competiciones = objCompeticionBC.ListarCompeticion(lista_paises[cmb_pais.SelectedIndex - 1].NombrePais);

                for (int i = 0; i < lista_competiciones.Count; i++)
                {
                    cmb_competicion.Items.Add(lista_competiciones[i].Nombre_competicion);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void iniciar_estadios()
        {
            try
            {
                cmb_estadio.Items.Clear();
                cmb_estadio.Items.Add("(Seleccione un estadio)");
                cmb_estadio.SelectedIndex = 0;

                lista_estadios = new List<EstadioBE>();
                EstadioBC objEstadioBC = new EstadioBC();

                lista_estadios = objEstadioBC.listarEstadiosDeEquipo(lista_equipos[cmb_local.SelectedIndex - 1].CodigoEquipo);

                for (int i = 0; i < lista_estadios.Count; i++)
                {
                    cmb_estadio.Items.Add(lista_estadios[i].Nombre_estadio);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void iniciar_temporadas()
        {
            try
            {
                cmb_temporada.Items.Clear();
                cmb_temporada.Items.Add("(Seleccione una temporada)");
                cmb_temporada.SelectedIndex = 0;

                //-- No se muestran equipos ya que no se ha seleccionado temporada
                cmb_local.Items.Clear();
                cmb_visitante.Items.Clear();
                cmb_estadio.Items.Clear();

                lista_temporadas = new List<LigaBE>();
                LigaBC objLigaBC = new LigaBC();

                lista_temporadas = objLigaBC.listaLigasPorCompeticion(lista_competiciones[cmb_competicion.SelectedIndex - 1].Codigo_competicion);

                for (int i = 0; i < lista_temporadas.Count; i++)
                {
                    cmb_temporada.Items.Add(lista_temporadas[i].TemporadaLiga);
                }

            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void cmb_SeleccionarPais(object sender, EventArgs e)
        {
            if (cmb_pais.SelectedIndex == 0)
            {
                cmb_competicion.Items.Clear();
                cmb_temporada.Items.Clear();
                cmb_local.Items.Clear();
                cmb_visitante.Items.Clear();
                cmb_estadio.Items.Clear();
                dtp_fecha.Text = DateTime.Today.ToShortDateString();
            }
            else
                if (cmb_pais.SelectedIndex > 0)
                {
                    iniciar_competicion();
                }
        }

        private void cmb_SeleccionarEquipoLocal(object sender, EventArgs e)
        {
            if (cmb_local.Text == cmb_visitante.Text)
            {
                cmb_local.SelectedIndex = 0;
                cmb_estadio.Items.Clear();
            }
            else
                if (cmb_local.SelectedIndex > 0)
                {
                    iniciar_estadios();
                }
        }

        private void cmb_SeleccionarEquipoVisitante(object sender, EventArgs e)
        {
            //-- Impedimento de seleccionar como equipo local y visitante al mismo equipo
            if (cmb_visitante.Text == cmb_local.Text)
            {
                cmb_visitante.SelectedIndex = 0;
            }
        }

        private void cmb_SeleccionarCompeticion(object sender, EventArgs e)
        {
            if (cmb_competicion.SelectedIndex > 0)
            {
                iniciar_temporadas();
            }
        }

        private void cmb_SeleccionarTemporada(object sender, EventArgs e)
        {
            if (cmb_temporada.SelectedIndex > 0)
            {
                iniciar_equipos();
            }
        }

        private void inGuardarPartido(object sender, EventArgs e)
        {
            if (_Modo == 1)
            {
                guardar_partido();
            }
            else if (_Modo == 2)
            {
                editar_partido();
                frmConsultaPartidosSinJugar frm = frmConsultaPartidosSinJugar.Instance();
                frm.dgvPatidosDataBind();
            }
        }

        private void guardar_partido()
        {
            try
            {
                if (ValidarCampos())
                {
                    int codigo_partido = 0;

                    PartidoBE objPartidoBE = new PartidoBE();
                    PartidoBC objPartidoBC = new PartidoBC();

                    //-- Se debería validar total de partidos registrados para esta temporada
                    //-- Se debería validar que no haya partido igual
                    if (cmb_local.Text != cmb_visitante.Text)
                    {
                        //-- Un partido siempre se guarda sin resultado, ya que o bien pudo haberse jugado, o aún no
                        //--objPartidoBE.Goles_local = 0;
                        //--objPartidoBE.Goles_visita = 0;
                        objPartidoBE.Codigo_liga = lista_temporadas[cmb_temporada.SelectedIndex - 1].CodigoLiga;
                        objPartidoBE.Codigo_equipo_local = lista_equipos[cmb_local.SelectedIndex - 1].CodigoEquipo;
                        objPartidoBE.Codigo_equipo_visitante = lista_equipos[cmb_visitante.SelectedIndex - 1].CodigoEquipo;
                        objPartidoBE.Codigo_estadio = lista_estadios[cmb_estadio.SelectedIndex - 1].Codigo_estadio;
                        objPartidoBE.Fecha_partido = dtp_fecha.Value.Date;

                        codigo_partido = objPartidoBC.insertar_Partido(objPartidoBE);

                        if (codigo_partido == -1)
                        {
                            MessageBox.Show("Partido ya ha sido registrado para dicha liga ó la cantidad de partidos para la liga ha llegado a su límite. Verifique los datos.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            if (codigo_partido == 0)
                                MessageBox.Show("No se pudo Registrar al Partido correctamente", "Sistema Inteligente para Pronósticos de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            else
                            {
                                MessageBox.Show("El Nuevo Partido ha sido Registrado correctamente", "Sistema Inteligente para Pronósticos de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimpiarCampos();
                            }
                    }
                    else
                        MessageBox.Show("El equipo local no puede ser el mismo que el equipo visitante", "Sistema Inteligente para Pronósticos de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Todos los campos son obligatorios", "Sistema Inteligente para Pronósticos de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void editar_partido()
        {
            try
            {
                PartidoBC objPartidoBC = new PartidoBC();
                objPartidoBC.editar_Partido(Partido.Codigo_partido, dtp_fecha.Value);
                MessageBox.Show("El Nuevo Partido ha sido Registrado correctamente", "Sistema Inteligente para Pronósticos de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private Boolean ValidarCampos()
        {
            return ((cmb_pais.SelectedIndex>=1) && (cmb_competicion.SelectedIndex>=1)
                    && (cmb_temporada.SelectedIndex >= 1) && (cmb_local.SelectedIndex >= 1)
                    && (cmb_visitante.SelectedIndex >= 1) && (cmb_estadio.SelectedIndex >= 1));
        }

        private void LimpiarCampos()
        {
            iniciar_pais();
            dtp_fecha.Text = DateTime.Today.ToShortDateString();
        }

        private void frmPartidoInsertar_Load(object sender, EventArgs e)
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
