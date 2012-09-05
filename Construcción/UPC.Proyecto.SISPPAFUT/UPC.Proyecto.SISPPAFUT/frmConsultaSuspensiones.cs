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
    public partial class frmConsultaSuspensiones : Form
    {
        private List<JugadorBE> lista_jugadores;

        private static frmConsultaSuspensiones frmSuspension = null;
        public static frmConsultaSuspensiones Instance()
        {
            if (frmSuspension == null)
            {
                frmSuspension = new frmConsultaSuspensiones();
            }
            return frmSuspension;
        }

        public frmConsultaSuspensiones()
        {
            InitializeComponent();
        }

        private void frmConsultaSuspensiones_Load(object sender, EventArgs e)
        {
            lista_jugadores = new List<JugadorBE>();

            cmb_jugadores.Items.Add("(Elija un jugador)");
            cmb_jugadores.SelectedIndex = 0;

            JugadorBC objJugadorBC = new JugadorBC();
            lista_jugadores = objJugadorBC.listar_Jugadores();

            for (int i = 0; i < lista_jugadores.Count; i++)
            {
                cmb_jugadores.Items.Add(lista_jugadores[i].Nombres + " " + lista_jugadores[i].Apellidos);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            
            //JugadorBC objJugadorBC = new JugadorBC();
            //MessageBox.Show("Jugador: " + objJugadorBC.ver(lista_jugadores[cmb_jugadores.SelectedIndex-1].CodigoJugador), 
            //            "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
        }
    }
}
