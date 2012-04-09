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
    public partial class frmEstadioInsertar : Form
    {
        //--Área de variables globales
        List<PaisBE> lista_paises;

        private static frmEstadioInsertar frmEstadio = null;
        public static frmEstadioInsertar Instance()
        {
            if (frmEstadio == null)
            {
                frmEstadio = new frmEstadioInsertar();
            }
            return frmEstadio;
        }

        public frmEstadioInsertar()
        {
            InitializeComponent();
            iniciarPais();
        }
        
        private void iniciarPais()
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
        
        private void btn_GuardarEstadio(object sender, EventArgs e)
        {
            try
            {
                int codigo = 0;

                EstadioBE objEstadioBE = new EstadioBE();

                objEstadioBE.Codigo_pais = lista_paises[cmb_pais.SelectedIndex - 1].CodigoPais;
                objEstadioBE.Anho_fundacion = Convert.ToInt32(cmb_anho.Items[cmb_anho.SelectedIndex]);
                objEstadioBE.Nombre_estadio = txt_nombre.Text;
                objEstadioBE.Ciudad_estadio = txt_ciudad.Text;
                objEstadioBE.Aforo_estadio = Convert.ToInt32(txt_aforo.Text);

                EstadioBC objEstadioBC = new EstadioBC();
                codigo = objEstadioBC.insertar_Estadio(objEstadioBE);

                if (codigo != 0)
                {
                    MessageBox.Show("El estadio ha sido registrada satisfactoriamente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El estadio no ha sido registrada debido a un error.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btn_Cancelar(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
