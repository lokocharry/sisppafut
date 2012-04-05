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
        }

        private void FrmEstadioInsertar_Load(object sender, EventArgs e)
        {
            PaisBC objPaisBC = new PaisBC();
            List<PaisBE> lista_paises = objPaisBC.listarPaises();

            for (int i = 0; i < lista_paises.Count; i++)
            {
                cmb_pais.Items.Add(lista_paises[i].NombrePais);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            int codigo = 0;

            EstadioBE objEstadioBE = new EstadioBE();

            objEstadioBE.Codigo_pais = Convert.ToInt32(cmb_pais.SelectedIndex + 1);
            objEstadioBE.Anho_fundacion = Convert.ToInt32(cmb_anho.Items[cmb_anho.SelectedIndex]);
            objEstadioBE.Nombre_estadio = txt_nombre.Text;
            objEstadioBE.Ciudad_estadio = txt_ciudad.Text;
            objEstadioBE.Aforo_estadio = Convert.ToInt32(txt_aforo.Text);

            EstadioBC objEstadioBC = new EstadioBC();
            codigo = objEstadioBC.insertar_Estadio(objEstadioBE);

            if (codigo != 0)
                MessageBox.Show("EL ESTADIO HA SIDO REGISTRADO SATISFACTORIAMENTE");

            else
                MessageBox.Show("HUBO UN PROBLEMA AL REGISTRAR EL ESTADIO");
        }
    }
}
