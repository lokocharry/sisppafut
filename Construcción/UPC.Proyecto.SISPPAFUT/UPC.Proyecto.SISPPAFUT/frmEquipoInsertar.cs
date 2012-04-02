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
    public partial class frmEquipoInsertar : Form
    {
        public frmEquipoInsertar()
        {
            InitializeComponent();

            iniciarPais();
            inicarAnio();
        }

        private void iniciarPais()
        {
            cmb_pais.SelectedIndex = 0;
            List<PaisBE> listaPaises = new List<PaisBE>();
            PaisBC objPaisBC = new PaisBC();

            listaPaises = objPaisBC.listarPaises();

            for (int i = 0; i < listaPaises.Count; i++)
            {
                PaisBE objPais = listaPaises[i];
                cmb_pais.Items.Add(objPais.NombrePais);
            }
        }

        private void inicarAnio()
        {
            cmb_anio.SelectedIndex = 0;
            for (int i = 1900; i < 2013; i++)
            {
                cmb_anio.Items.Add(i.ToString());
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            int iCodigo = 0;

            EquipoBE objEquipoBE;
            EquipoBC objEquipoBC;

            objEquipoBE = new EquipoBE();
            objEquipoBC = new EquipoBC();

            //objEquipoBE.CodigoPais = 
            objEquipoBE.NombreEquipo = txt_nombre.Text;
            objEquipoBE.AnioFundacion = Convert.ToInt32(cmb_anio.SelectedValue);
            objEquipoBE.CiudadEquipo = txt_nombre.Text;
            //objEquipoBE.CodigoEstadioPrincipal =
            //objEquipoBE.CodigoEstadioAlterno = 

            iCodigo = objEquipoBC.insertarEquipo(objEquipoBE);

            if (iCodigo == -1)
            {
                MessageBox.Show("ESTE EQUIPO YA HA SIDO INGRESADO ANTERIORMENTE");
            }
            else if (iCodigo == 0)
            {
                MessageBox.Show("NO SE PUDO REGISTRAR EL EQUIPO");
            }
            else
            {
                MessageBox.Show("EL EQUIPO SE REGISTRO SATISFACTORIAMENTE");
            }
        }

        private void brn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
