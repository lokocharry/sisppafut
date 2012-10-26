using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.BL.BC;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmApostadorVerPronosticos : Form
    {
        PaisBC objPaisBC;
        List<PaisBE> lstPais;
        CompeticionBC objCompeticionBC;
        List<CompeticionBE> lst_competiciones;
        LigaBC objLigaBC;
        List<LigaBE> lista_temporadas;
        PronosticoBC objPronosticoBC;
        List<PronosticoBE> lstPronosticos;

        private static frmApostadorVerPronosticos frmVerPronosticos = null;
        public static frmApostadorVerPronosticos Instance()
        {
            if (frmVerPronosticos == null)
            {
                frmVerPronosticos = new frmApostadorVerPronosticos();
            }
            return frmVerPronosticos;
        }

        public frmApostadorVerPronosticos()
        {
            InitializeComponent();
            iniciarGrilla();
            iniciarPais();
            objPronosticoBC = new PronosticoBC();
            lstPronosticos = new List<PronosticoBE>();
            lstPronosticos = objPronosticoBC.listar_PronosticosParaApostador();
        }

        private void iniciarGrilla()
        {
            try
            {
                dg_Pronosticos.AllowUserToAddRows = false;
                dg_Pronosticos.AllowUserToDeleteRows = false;
                dg_Pronosticos.AllowUserToResizeColumns = false;
                dg_Pronosticos.AllowUserToResizeRows = false;

                dg_Pronosticos.AllowDrop = false;

                dg_Pronosticos.MultiSelect = false; //-- Se protege la grilla para evitar seleccionar varios registros

                dg_Pronosticos.ReadOnly = true; //-- Se protege la grilla para evitar poder modificar los datos de la grilla

                // Lo siguiente es para elegir toda la fila selecionada
                dg_Pronosticos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dg_Pronosticos.Columns[0].Visible = false;
                dg_Pronosticos.Columns[1].Visible = false;
                dg_Pronosticos.Columns[2].Visible = true;
                dg_Pronosticos.Columns[3].Visible = true;
                dg_Pronosticos.Columns[4].Visible = true;
                dg_Pronosticos.Columns[5].Visible = true;

                DataGridViewCellStyle csFilaPar = new DataGridViewCellStyle();
                DataGridViewCellStyle csFilaImpar = new DataGridViewCellStyle();

                csFilaPar.BackColor = dg_Pronosticos.BackgroundColor;
                csFilaImpar.BackColor = dg_Pronosticos.GridColor;

                int elemento;

                for (elemento = 0; elemento < dg_Pronosticos.Rows.Count; elemento++)
                {
                    if (elemento % 2 == 0)
                    {
                        dg_Pronosticos.Rows[elemento].DefaultCellStyle = csFilaPar;
                    }
                    else
                    {
                        dg_Pronosticos.Rows[elemento].DefaultCellStyle = csFilaImpar;
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void iniciarPais()
        {
            try
            {
                cmb_pais.Items.Clear();
                cmb_pais.Items.Add("(Seleccione un país...)");
                cmb_pais.SelectedIndex = 0;
                lstPais = new List<PaisBE>();
                objPaisBC = new PaisBC();

                lstPais = objPaisBC.listarPaises();

                for (int i = 0; i < lstPais.Count; i++)
                {
                    cmb_pais.Items.Add(lstPais[i].NombrePais);
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
            }
            else
                if (cmb_pais.SelectedIndex > 0)
                {
                    iniciar_competicion();
                }
            dg_Pronosticos.Rows.Clear();
        }

        private void iniciar_competicion()
        {
            try
            {
                cmb_competicion.Items.Clear();
                cmb_competicion.Items.Add("(Seleccione una competicion)");
                cmb_competicion.SelectedIndex = 0;

                lst_competiciones = new List<CompeticionBE>();
                objCompeticionBC = new CompeticionBC();

                lst_competiciones = objCompeticionBC.ListarCompeticion(lstPais[cmb_pais.SelectedIndex - 1].NombrePais);

                for (int i = 0; i < lst_competiciones.Count; i++)
                {
                    cmb_competicion.Items.Add(lst_competiciones[i].Nombre_competicion);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void cmb_SeleccionarCompeticion(object sender, EventArgs e)
        {
            if (cmb_competicion.SelectedIndex > 0)
            {
                iniciar_temporadas();
            }
            else
                cmb_temporada.Items.Clear();
            dg_Pronosticos.Rows.Clear();
        }

        private void iniciar_temporadas()
        {
            try
            {
                cmb_temporada.Items.Clear();
                cmb_temporada.Items.Add("(Seleccione una temporada)");
                cmb_temporada.SelectedIndex = 0;

                lista_temporadas = new List<LigaBE>();
                objLigaBC = new LigaBC();

                lista_temporadas = objLigaBC.listaLigasPorCompeticion(lst_competiciones[cmb_competicion.SelectedIndex - 1].Codigo_competicion);

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

        private void inMostrarPredicciones(object sender, EventArgs e)
        {
            try
            {
                dg_Pronosticos.Rows.Clear();
                if (cmb_pais.SelectedIndex > 0)
                {
                    if (cmb_competicion.SelectedIndex > 0)
                    {
                        if (cmb_temporada.SelectedIndex > 0)
                        {
                            if (lstPronosticos.Count > 0)
                            {
                                foreach (PronosticoBE cDto in lstPronosticos)
                                {
                                    if (cDto.CodLiga == lista_temporadas[cmb_temporada.SelectedIndex - 1].CodigoLiga)
                                    {
                                        dg_Pronosticos.Rows.Add(cDto.CodigoPronostico, cDto.CodigoPartido, cDto.EquipoLocal, cDto.EquipoVisita, cDto.Pronostico, cDto.Fecha);
                                    }
                                }
                            }
                            
                            if (dg_Pronosticos.Rows.Count == 0 || lstPronosticos.Count == 0)
                            {
                                MessageBox.Show("No hay nuevos pronósticos para mostrar.", "Sistema Inteligente para Pronósticos de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                            MessageBox.Show("Debe seleccionar una temporada.", "Sistema Inteligente para Pronósticos de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Debe seleccionar una competición.", "Sistema Inteligente para Pronósticos de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Debe seleccionar un país.", "Sistema Inteligente para Pronósticos de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void inSeleccionarTemporada(object sender, EventArgs e)
        {
            dg_Pronosticos.Rows.Clear();
        }
    }
}
