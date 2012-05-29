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
    public partial class frmActualizarRanking : Form
    {
        //--Variables globales
        List<PaisBE> lista_paises;
        List<EquipoBE> lista_equipos;

        public frmActualizarRanking()
        {
            InitializeComponent();
        }

        private static frmActualizarRanking frmRanking = null;
        public static frmActualizarRanking Instance()
        {
            if (frmRanking == null)
            {
                frmRanking = new frmActualizarRanking();
            }
            return frmRanking;
        }

        private void frmActualizarRanking_Load(object sender, EventArgs e)
        {
            try
            {
                iniciarPais();
                iniciarAnio();
                iniciarMes();
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
            catch(Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
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

        private void iniciarMes()
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

        private void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPais.SelectedIndex > 0)
            {
                iniciarEquipos(cmbPais.SelectedItem.ToString());
            }
        }

        private void iniciarEquipos(String pais)
        {
            try
            {                
                cmbEquipo.Items.Clear();
                cmbEquipo.Items.Add("Seleccione un equipo...");
                cmbEquipo.SelectedIndex = 0;

                lista_equipos = new List<EquipoBE>();
                EquipoBC objEquipoBC = new EquipoBC();

                lista_equipos = objEquipoBC.listarEquipos(pais);

                for (int i = 0; i < lista_equipos.Count; i++)
                {
                    EquipoBE objEquipoBE = lista_equipos[i];
                    cmbEquipo.Items.Add(objEquipoBE.NombreEquipo);
                }

            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int iCodigo = 0;
                RankingEquipoBC objEquipoBC;
                RankingEquipoBE objEquipoBE;

                objEquipoBE = new RankingEquipoBE();
                objEquipoBC = new RankingEquipoBC();

                objEquipoBE.CodigoEquipo = lista_equipos[cmbEquipo.SelectedIndex - 1].CodigoEquipo;
                objEquipoBE.PosicionRanking = Convert.ToInt32(txtPosicion.Text);
                objEquipoBE.AnioRanking = Convert.ToInt32(cmbAnio.Text);
                objEquipoBE.MesRanking = cmbMes.SelectedIndex;
                objEquipoBE.PuntosRanking = Convert.ToInt32(txtPuntos.Text);

                iCodigo = objEquipoBC.insertar_ranking(objEquipoBE);
                if (iCodigo == 0)
                {
                    MessageBox.Show("El equipo no ha sido registrada debido a un error.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("El equipo ha sido registrado satisfactoriamente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }
    }
}
