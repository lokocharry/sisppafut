using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.BL.BC;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class PaisInsertar : Form
    {
        public PaisInsertar()
        {
            InitializeComponent();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            int iCodigo = 0;

            PaisBE objPaidBE = new PaisBE();
            PaisBC objPaisBC = new PaisBC();

            objPaidBE.NombrePais = txt_pais.Text;

            iCodigo = objPaisBC.insertarPais(objPaidBE);

            if(iCodigo == -1)
            {
                MessageBox.Show("ESTE PAIS YA HA SIDO INGRESADO ANTERIORMENTE");
            }

            else if (iCodigo == 0)
            {
                MessageBox.Show("NO SE PUDO REGISTRAR ESTE PAIS");
            }

            else
            {
                MessageBox.Show("EL PAIS HA SIDO REGISTRADO SATISFACTORIAMENTE");
            }
        }
    }
}
