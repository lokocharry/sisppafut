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
            try
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
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
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
            try
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
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void brn_Cancelar(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_GuardarEquipo(object sender, EventArgs e)
        {
            try
            {
                int iCodigo = 0;

                EquipoBE objEquipoBE;
                EquipoBC objEquipoBC;

                objEquipoBE = new EquipoBE();
                objEquipoBC = new EquipoBC();

                objEquipoBE.CodigoPais = listaPaises[cmb_pais.SelectedIndex - 1].CodigoPais;
                objEquipoBE.NombreEquipo = txt_nombre.Text;
                objEquipoBE.AnioFundacion = Convert.ToInt32(cmb_anio.SelectedItem.ToString());
                objEquipoBE.CiudadEquipo = txt_ciudad.Text;
                objEquipoBE.CodigoEstadioPrincipal = listaEstadios[cmb_estadioPrincipal.SelectedIndex - 1].Codigo_estadio;
                if (cmb_estadioAlterno.SelectedIndex > 0)
                    objEquipoBE.CodigoEstadioAlterno = listaEstadios[cmb_estadioAlterno.SelectedIndex - 1].Codigo_estadio;

                iCodigo = objEquipoBC.insertarEquipo(objEquipoBE);

                if (iCodigo == -1)
                {
                    MessageBox.Show("El equipo ya ha sido registrado anteriormente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                    else
                    if (iCodigo == 0 || objEquipoBE.CodigoEstadioPrincipal == objEquipoBE.CodigoEstadioAlterno)
                    {
                        MessageBox.Show("El equipo no ha sido registrada debido a un error.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("El equipo ha sido registrado satisfactoriamente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }
    }
}
