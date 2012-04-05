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
        private List<PaisBE> listaPaises;
        private List<EstadioBE> listaEstadios;

        private static frmEquipoInsertar frmEquipo = null;
        public static frmEquipoInsertar Instance()
        {
            if (frmEquipo == null)
            {
                frmEquipo = new frmEquipoInsertar();
            }
            return frmEquipo;
        }

        public frmEquipoInsertar()
        {
            InitializeComponent();

            iniciarPais();
            inicarAnio();
            iniciarEstadios();
        }

        private void iniciarPais()
        {
            cmb_pais.SelectedIndex = 0;
            listaPaises = new List<PaisBE>();
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
            for (int i = 1857; i < 2013; i++)
            {
                cmb_anio.Items.Add(i.ToString());
            }
        }

        private void iniciarEstadios()
        {
            cmb_estadioPrincipal.SelectedIndex = 0;
            cmb_estadioAlterno.SelectedIndex = 0;

            listaEstadios = new List<EstadioBE>();
            EstadioBC objEstadioBC = new EstadioBC();

            listaEstadios = objEstadioBC.listarEstadios();

            for (int i = 0; i < listaEstadios.Count; i++)
            {
                EstadioBE objEstadio = listaEstadios[i];
                cmb_estadioPrincipal.Items.Add(objEstadio.Nombre_estadio);
                cmb_estadioAlterno.Items.Add(objEstadio.Nombre_estadio);
            }
        }
                
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            int iCodigo = 0;

            EquipoBE objEquipoBE;
            EquipoBC objEquipoBC;

            objEquipoBE = new EquipoBE();
            objEquipoBC = new EquipoBC();

            objEquipoBE.CodigoPais = listaPaises[cmb_pais.SelectedIndex-1].CodigoPais;
            objEquipoBE.NombreEquipo = txt_nombre.Text;
            objEquipoBE.AnioFundacion = Convert.ToInt32(cmb_anio.SelectedItem.ToString());
            objEquipoBE.CiudadEquipo = txt_ciudad.Text;
            objEquipoBE.CodigoEstadioPrincipal = listaEstadios[cmb_estadioPrincipal.SelectedIndex-1].Codigo_estadio;
            if (cmb_estadioAlterno.SelectedIndex>0)
                objEquipoBE.CodigoEstadioAlterno = listaEstadios[cmb_estadioAlterno.SelectedIndex - 1].Codigo_estadio;

            iCodigo = objEquipoBC.insertarEquipo(objEquipoBE);

            if (iCodigo == -1)
            {
                MessageBox.Show("ESTE EQUIPO YA HA SIDO INGRESADO ANTERIORMENTE");
            }
            else if (iCodigo == 0 || objEquipoBE.CodigoEstadioPrincipal==objEquipoBE.CodigoEstadioAlterno)
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

        private void frmEquipoInsertar_Load(object sender, EventArgs e)
        {

        }
    }
}
