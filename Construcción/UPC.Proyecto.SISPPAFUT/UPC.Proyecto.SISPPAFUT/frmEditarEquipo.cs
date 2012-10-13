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
    public partial class frmEditarEquipo : Form
    {
        //-- Variables globales
        List<PaisBE> listaPaises;
        private List<EquipoBE> listaEquipos;

        public List<EquipoBE> lstEquipos
        {
            get { return listaEquipos; }
            set { listaEquipos = value; }
        }

        private static frmEditarEquipo frmEquipos = null;
        public static frmEditarEquipo Instance()
        {
            if (frmEquipos == null)
            {
                frmEquipos = new frmEditarEquipo();
            }
            return frmEquipos;
        }

        public frmEditarEquipo()
        {
            InitializeComponent();
            iniciarPaises();
            iniciarGrilla();
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
            else
                if (cmbPais.SelectedIndex == 0)
                    dgEquipos.Rows.Clear();
        }

        public void iniciarEquipos()
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgEquipos.Rows.Count > 0 && cmbPais.SelectedIndex > 0)
            {
                frmInsertarEquipo frmEquipo = new frmInsertarEquipo();
                frmEquipo.MdiParent = this.MdiParent;
                frmEquipo.Modo = 2;
                frmEquipo.NombreEquipo = dgEquipos.SelectedRows[0].Cells["Nombre"].Value.ToString();
                frmEquipo.Show();
                frmEquipo.BringToFront();
            }
            else
            if(cmbPais.SelectedIndex == 0)
                MessageBox.Show("Seleccione un país.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("El país seleccionado no dispone de equipos para mostrar.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void inCerrar(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
        }

        private void frmEditarEquipo_Load(object sender, EventArgs e)
        {

        }
    }
}
