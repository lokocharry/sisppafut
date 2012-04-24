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
    public partial class frmEditarEquipos : Form
    {
        //-- Variables globales
        List<PaisBE> listaPaises;
        List<EquipoBE> listaEquipos;

        private static frmEditarEquipos frmEquipos = null;
        public static frmEditarEquipos Instance()
        {
            if (frmEquipos == null)
            {
                frmEquipos = new frmEditarEquipos();
            }
            return frmEquipos;
        }

        public frmEditarEquipos()
        {
            InitializeComponent();
            iniciarPaises();
            iniciarGrilla();            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iniciarPaises()
        {
            try
            {
                cmbPais.Items.Clear();
                cmbPais.Items.Add("(Seleccione un pais...)");
                cmbPais.SelectedIndex = 0;
                PaisBC objPaisBC = new PaisBC();
                listaPaises = new List<PaisBE>();

                listaPaises = objPaisBC.listarPaises();
                for (int i = 0; i < listaPaises.Count; i++)
                {
                    cmbPais.Items.Add(listaPaises[i].NombrePais);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void iniciarGrilla()
        {
            try
            {
                dgEquipos.AllowUserToAddRows = false;
                dgEquipos.AllowUserToDeleteRows = false;
                dgEquipos.AllowUserToResizeColumns = false;
                dgEquipos.AllowUserToResizeRows = false;

                dgEquipos.AllowDrop = false;
                dgEquipos.MultiSelect = false;
                dgEquipos.ReadOnly = true;
                dgEquipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dgEquipos.Columns[0].Visible = false;
                dgEquipos.Columns[1].Visible = true;
                dgEquipos.Columns[2].Visible = true;
                dgEquipos.Columns[3].Visible = true;

                DataGridViewCellStyle csFilaPar = new DataGridViewCellStyle();
                DataGridViewCellStyle csFilaImpar = new DataGridViewCellStyle();

                csFilaPar.BackColor = dgEquipos.BackgroundColor;
                csFilaImpar.BackColor = dgEquipos.GridColor;

                int elemento;

                for (elemento = 0; elemento < dgEquipos.Rows.Count; elemento++)
                {
                    if (elemento % 2 == 0)
                    {
                        dgEquipos.Rows[elemento].DefaultCellStyle = csFilaPar;
                    }
                    else
                    {
                        dgEquipos.Rows[elemento].DefaultCellStyle = csFilaImpar;
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPais.SelectedIndex > 0)
            {
                iniciarEquipos();
            }
        }

        private void iniciarEquipos()
        {
            try
            {
                dgEquipos.Rows.Clear();

                EquipoBC objEquipoBC = new EquipoBC();
                listaEquipos = new List<EquipoBE>();

                listaEquipos = objEquipoBC.listarEquipos(listaPaises[cmbPais.SelectedIndex - 1].NombrePais);
                for (int i = 0; i < listaEquipos.Count; i++)
                {
                    dgEquipos.Rows.Add(listaEquipos[i].CodigoEquipo,listaEquipos[i].NombreEquipo,listaEquipos[i].AnioFundacion,listaEquipos[i].CiudadEquipo);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }



    }
}
