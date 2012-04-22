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
    public partial class frmPartidoInsertar : Form
    {
        //--Área de variables globales
        List<PaisBE> lista_paises;
        List<CompeticionBE> lista_competiciones;
        List<EquipoBE> lista_equipos;
        List<EstadioBE> lista_estadios;
        List<LigaBE> lista_temporadas;

        private static frmPartidoInsertar frmPartido = null;
        public static frmPartidoInsertar Instance()
        {
            if (frmPartido == null)
            {
                frmPartido = new frmPartidoInsertar();
            }
            return frmPartido;
        }


        public frmPartidoInsertar()
        {
            InitializeComponent();
            iniciar_pais();
        }

        private void iniciar_pais()
        {
            try
            {
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
                cmb_local.Items.Add("(Seleccione un equipo...)");
                cmb_local.SelectedIndex = 0;

                cmb_visitante.Items.Clear();
                cmb_visitante.Items.Add("(Seleccione un equipo...)");
                cmb_visitante.SelectedIndex = 0;

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
                cmb_competicion.Items.Add("(Seleccione una competicion...)");
                cmb_competicion.SelectedIndex = 0;

                lista_competiciones = new List<CompeticionBE>();
                CompeticionBC objCompeticionBC = new CompeticionBC();

                lista_competiciones = objCompeticionBC.ListarCompeticion(lista_paises[cmb_pais.SelectedIndex-1].NombrePais);

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
                cmb_estadio.Items.Add("(Seleccione un estadio..)");
                cmb_estadio.SelectedIndex = 0;

                lista_estadios = new List<EstadioBE>();
                EstadioBC objEstadioBC = new EstadioBC();

                lista_estadios = objEstadioBC.listarEstadiosDeEquipo(lista_equipos[cmb_local.SelectedIndex-1].CodigoEquipo);

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
                cmb_temporada.Items.Add("(Seleccione una temporada...)");
                cmb_temporada.SelectedIndex = 0;

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

        private void cmb_pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_pais.SelectedIndex > 0)
            {
                iniciar_competicion();
            }
        }

        private void cmb_local_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_local.SelectedIndex > 0)
            {
                iniciar_estadios();
            }
        }

        private void cmb_competicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_competicion.SelectedIndex > 0)
            {
                iniciar_temporadas();
            }
        }

        private void cmb_temporada_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_temporada.SelectedIndex > 0)
            {
                iniciar_equipos();
            }
        }
    }
}
