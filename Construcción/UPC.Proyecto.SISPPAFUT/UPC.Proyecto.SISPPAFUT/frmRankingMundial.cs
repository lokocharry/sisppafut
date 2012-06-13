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
    public partial class frmRankingMundial : Form
    {
        //--Variables globales
        List<PaisBE> lista_paises;
        List<RankingBE> lista_ranking;

        public frmRankingMundial()
        {
            InitializeComponent();
        }

        private static frmRankingMundial frmRankingM;
        public static frmRankingMundial Instance()
        {
            if (frmRankingM == null)
            {
                frmRankingM = new frmRankingMundial();
            }
            return frmRankingM;
        }

        private void iniciarPais()
        {
            try
            {
                cmbPais.Items.Clear();
                cmbPais.Items.Add("Seleccione un pais..");
                cmbPais.SelectedIndex = 0;

                lista_paises = new List<PaisBE>();
                PaisBC objPaisBC = new PaisBC();

                lista_paises = objPaisBC.listarPaises();

                for (int i = 0; i < lista_paises.Count; i++)
                {
                    PaisBE objPaisBE = lista_paises[i];
                    cmbPais.Items.Add(objPaisBE.NombrePais);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inicarMes()
        {
            cmbMes.Items.Clear();
            cmbMes.Items.Add("Seleccione un mes...");
            cmbMes.Items.Add("Enero");
            cmbMes.Items.Add("Febrero");
            cmbMes.Items.Add("Marzo");
            cmbMes.Items.Add("Abril");
            cmbMes.Items.Add("Mayo");
            cmbMes.Items.Add("Junio");
            cmbMes.Items.Add("Julio");
            cmbMes.Items.Add("Agosto");
            cmbMes.Items.Add("Setiembre");
            cmbMes.Items.Add("Octubre");
            cmbMes.Items.Add("Noviembre");
            cmbMes.Items.Add("Diciembre");
            cmbMes.SelectedIndex = 0;
        }

        private void iniciarAnio()
        {
            cmbAnio.Items.Clear();
            cmbAnio.Items.Add("Seleccione un año...");
            cmbAnio.Items.Add("2007");
            cmbAnio.Items.Add("2008");
            cmbAnio.Items.Add("2009");
            cmbAnio.Items.Add("2010");
            cmbAnio.Items.Add("2011");
            cmbAnio.Items.Add("2012");
            cmbAnio.SelectedIndex = 0;
        }

        private void iniciarGrilla()
        {
            try
            {
                dgvRanking.AllowUserToAddRows = false;
                dgvRanking.AllowUserToDeleteRows = false;
                dgvRanking.AllowUserToResizeColumns = false;
                dgvRanking.AllowUserToResizeRows = false;

                dgvRanking.AllowDrop = false;
                dgvRanking.MultiSelect = false;
                dgvRanking.ReadOnly = true;
                dgvRanking.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dgvRanking.Columns[0].Visible = true;
                dgvRanking.Columns[1].Visible = true;
                dgvRanking.Columns[2].Visible = true;
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void frmRankingMundial_Load(object sender, EventArgs e)
        {
            try
            {
                iniciarPais();
                inicarMes();
                iniciarAnio();
                iniciarGrilla();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                RankingEquipoBC objRankingBC;
                objRankingBC = new RankingEquipoBC();

                dgvRanking.Rows.Clear();

                if (ValidarDatos())
                {
                    int anio = Convert.ToInt32(cmbAnio.Items[cmbAnio.SelectedIndex]);
                    int mes = cmbMes.SelectedIndex;
                    int pais = lista_paises[cmbPais.SelectedIndex - 1].CodigoPais;

                    lista_ranking = objRankingBC.obtener_ranking(anio, mes, pais);

                    if (lista_ranking.Count > 0)
                    {
                        for (int i = 0; i < lista_ranking.Count; i++)
                        {
                            dgvRanking.Rows.Add(lista_ranking[i].Posicion, lista_ranking[i].NombreEquipo, lista_ranking[i].Pais);
                        }
                    }
                    else
                        MessageBox.Show("No hay datos para mostrar. Seleccione otros datos.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Debe seleccionar todos los datos.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private Boolean ValidarDatos()
        {
            return (cmbAnio.SelectedIndex > 0 && cmbMes.SelectedIndex > 0 && cmbPais.SelectedIndex > 0);
        }

        private void inSalir(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }
    }
}
