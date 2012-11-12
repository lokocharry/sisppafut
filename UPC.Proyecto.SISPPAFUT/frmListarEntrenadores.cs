using System;
using System.Collections.Generic;
using System.Windows.Forms;

using UPC.Proyecto.SISPPAFUT.BL.BC;
using UPC.Proyecto.SISPPAFUT.BL.BE;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmListarEntrenadores : Form
    {
        public frmListarEntrenadores()
        {
            InitializeComponent();
        }

        List<EntrenadorBE> lst_Entrenadores;
        private static frmListarEntrenadores frmListarEntrenador = null;

        public static frmListarEntrenadores Instance()
        {
            if (frmListarEntrenador == null)
                frmListarEntrenador = new frmListarEntrenadores();
            return frmListarEntrenador;
        }

        private void dgvEntrenadoresConfigurar()
        {
            dgvEntrenadores.AllowUserToAddRows = false;
            dgvEntrenadores.AllowUserToDeleteRows = false;
            dgvEntrenadores.AllowUserToResizeColumns = false;
            dgvEntrenadores.AllowUserToResizeRows = false;

            dgvEntrenadores.AllowDrop = false;
            dgvEntrenadores.MultiSelect = false;
            dgvEntrenadores.ReadOnly = true;
            dgvEntrenadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvEntrenadores.Columns[0].Visible = false;
            dgvEntrenadores.Columns[1].Visible = true;
            dgvEntrenadores.Columns[2].Visible = true;
            dgvEntrenadores.Columns[3].Visible = true;

            DataGridViewCellStyle csFilaPar = new DataGridViewCellStyle();
            DataGridViewCellStyle csFilaImpar = new DataGridViewCellStyle();

            csFilaPar.BackColor = dgvEntrenadores.BackgroundColor;
            csFilaImpar.BackColor = dgvEntrenadores.GridColor;

            int elemento;

            for (elemento = 0; elemento < dgvEntrenadores.Rows.Count; elemento++)
            {
                if (elemento % 2 == 0)
                {
                    dgvEntrenadores.Rows[elemento].DefaultCellStyle = csFilaPar;
                }
                else
                {
                    dgvEntrenadores.Rows[elemento].DefaultCellStyle = csFilaImpar;
                }
            }
        }

        public void ListarEntrenadores()
        {
            EntrenadorBC objEntrenadorBC;
            lst_Entrenadores = new List<EntrenadorBE>();

            try
            { 
                objEntrenadorBC = new EntrenadorBC();
                lst_Entrenadores = objEntrenadorBC.ListarEntrenadores();

                dgvEntrenadores.Rows.Clear();

                if (lst_Entrenadores.Count > 0)
                {
                    for (int i = 0; i < lst_Entrenadores.Count; i++)
                    {
                        dgvEntrenadores.Rows.Add(lst_Entrenadores[i].CodEntrenador, String.Format("{0} {1}", lst_Entrenadores[i].Nombres, lst_Entrenadores[i].Apellidos), lst_Entrenadores[i].Nacionalidad, lst_Entrenadores[i].Fecha.ToShortDateString());
                    }                    
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void frmListarEntrenadores_Load(object sender, EventArgs e)
        {
            ListarEntrenadores();
            dgvEntrenadoresConfigurar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rowCollection = dgvEntrenadores.SelectedRows;
            if (rowCollection.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un entrenador.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                frmInsertarEntrenador frm = frmInsertarEntrenador.Instance();
                frm.MdiParent = MdiParent;
                frm.Modo = 2;
                frm.RecibirEntrandor(lst_Entrenadores[dgvEntrenadores.SelectedRows[0].Index]);
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inCerrar(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }
    }
}
