using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UPC.Proyecto.SISPPAFUT.BL.BE;
using UPC.Proyecto.SISPPAFUT.BL.BC;

namespace UPC.Proyecto.SISPPAFUT
{
    public partial class frmListarLog : Form
    {
        public frmListarLog()
        {
            InitializeComponent();
        }

        List<LogBE> lst_log;

        private static frmListarLog frmlog = null;
        public static frmListarLog Instance()
        {
            if (frmlog == null)
            {
                frmlog = new frmListarLog();
            }
            return frmlog;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogBC objLogBC;
            lst_log = new List<LogBE>();
            dgvLog.Rows.Clear();

            try
            {
                objLogBC = new LogBC();
                DateTime Fecha = dtFecha.Value;

                lst_log = objLogBC.ListarLogsFecha(Fecha);

                for (int i = 0; i < lst_log.Count; i++)
                {
                    dgvLog.Rows.Add(lst_log[i].CodOperacion.ToString(), lst_log[i].Tabla, lst_log[i].Usuario, lst_log[i].Fecha.ToString(), lst_log[i].IP.ToString(), lst_log[i].Razon);
                }

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
