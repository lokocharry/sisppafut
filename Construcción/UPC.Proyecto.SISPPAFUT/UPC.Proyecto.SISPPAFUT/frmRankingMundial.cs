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

                int anio = Convert.ToInt32(cmbAnio.Items[cmbAnio.SelectedIndex]);
                int mes = cmbMes.SelectedIndex;
                int pais = lista_paises[cmbPais.SelectedIndex - 1].CodigoPais;

                lista_ranking = objRankingBC.obtener_ranking(anio, mes, pais);

                for (int i = 0; i < lista_ranking.Count; i++)
                {
                    dgvRanking.Rows.Add(lista_ranking[i].Posicion, lista_ranking[i].NombreEquipo, lista_ranking[i].Pais);
                }
             }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

    }
}
