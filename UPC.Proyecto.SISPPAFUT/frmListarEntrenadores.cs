using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        int FilaSeleccionada = -1;
        List<EntrenadorBE> lst_Entrenadores;
        private static frmListarEntrenadores frmListarEntrenador = null;

        public static frmListarEntrenadores Instance()
        {
            if (frmListarEntrenador == null)
                frmListarEntrenador = new frmListarEntrenadores();
            return frmListarEntrenador;
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

                for (int i = 0; i < lst_Entrenadores.Count; i++)
                {
                    dgvEntrenadores.Rows.Add(lst_Entrenadores[i].Nombres + " " + lst_Entrenadores[i].Apellidos, lst_Entrenadores[i].Fecha.ToShortDateString(), lst_Entrenadores[i].Nacionalidad);
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
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (FilaSeleccionada == -1)
                return;
            try
            {
                frmRegistrarEntrenador frm = frmRegistrarEntrenador.Instance();

                frm.Modo = 2;
                frm.RecibirEntrandor(lst_Entrenadores[FilaSeleccionada]);
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void dgvEntrenadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                    return;

                FilaSeleccionada = e.RowIndex;
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void inCerrar(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
        }
    }
}
