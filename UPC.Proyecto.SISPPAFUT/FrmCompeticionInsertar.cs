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
    public partial class frmCompeticionInsertar : Form
    {
        private static frmCompeticionInsertar frmCompeticion = null;
        public static frmCompeticionInsertar Instance()
        {
            if (frmCompeticion == null)
            {
                frmCompeticion = new frmCompeticionInsertar();
            }
            return frmCompeticion;
        }

        public frmCompeticionInsertar()
        {
            InitializeComponent();
        }

        private void FrmCompeticionInsertar_Load(object sender, EventArgs e)
        {
            try
            {
                PaisBC objPaisBC = new PaisBC();
                List<PaisBE> lista_paises = objPaisBC.listarPaises();

                for (int i = 0; i < lista_paises.Count; i++)
                {
                    cmb_paises.Items.Add(lista_paises[i].NombrePais);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }
        
        private void btn_GuardarCompeticion(object sender, EventArgs e)
        {
            try
            {
                int codigo = 0;

                CompeticionBE objCompeticionBE = new CompeticionBE();

                objCompeticionBE.Codigo_pais = Convert.ToInt32(cmb_paises.SelectedIndex + 1);
                objCompeticionBE.Nombre_competicion = txt_nombre.Text;

                CompeticionBC objCompeticionBC = new CompeticionBC();
                codigo = objCompeticionBC.insertar_Competicion(objCompeticionBE);

                if (codigo != 0)
                {
                    MessageBox.Show("La Competición ha sido registrada satisfactoriamente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("La Competición no ha sido registrada por un error interno.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btn_Salir(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
