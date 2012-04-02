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
    public partial class FrmCompeticionInsertar : Form
    {
        public FrmCompeticionInsertar()
        {
            InitializeComponent();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCompeticionInsertar_Load(object sender, EventArgs e)
        {
            PaisBC objPaisBC = new PaisBC();
            List<PaisBE> lista_paises = objPaisBC.listarPaises();

            for (int i = 0; i < lista_paises.Count; i++)
            {
                cmb_paises.Items.Add(lista_paises[i].NombrePais);
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            int codigo = 0;

            CompeticionBE objCompeticionBE = new CompeticionBE();

            objCompeticionBE.Codigo_pais = Convert.ToInt32(cmb_paises.SelectedIndex + 1);
            objCompeticionBE.Nombre_competicion = txt_nombre.Text;

            CompeticionBC objCompeticionBC = new CompeticionBC();
            codigo = objCompeticionBC.insertar_Competicion(objCompeticionBE);

            if (codigo != 0)
                MessageBox.Show("LA COMPETICIÓN HA SIDO REGISTRADO SATISFACTORIAMENTE");

            else
                MessageBox.Show("HUBO UN PROBLEMA AL REGISTRAR LA COMPETICIÓN");
        }
    }
}
