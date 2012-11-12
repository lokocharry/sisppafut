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
    public partial class frmEditarJugador : Form
    {
        //--Variables globales
        private List<JugadorBE> listaJugadores;

        public List<JugadorBE> lstJugadores
        {
            get { return listaJugadores; }
            set { listaJugadores = value; }
        }

        private static frmEditarJugador frmJugadores = null;
        public static frmEditarJugador Instance()
        {
            if (frmJugadores == null)
            {
                frmJugadores = new frmEditarJugador();
            }
            
            return frmJugadores;
        }
        
        public frmEditarJugador()
        {
            InitializeComponent();
            iniciarGrilla();
            iniciarJugadores();
        }

        public void iniciarJugadores()
        {
            try
            {
                dgJugadores.Rows.Clear();

                JugadorBC objJugadorBC = new JugadorBC();
                listaJugadores = new List<JugadorBE>();

                listaJugadores = objJugadorBC.listar_Jugadores();
                for(int i = 0; i < listaJugadores.Count; i++)
                {
                    dgJugadores.Rows.Add(listaJugadores[i].CodigoJugador,listaJugadores[i].Nombres,
                        listaJugadores[i].Apellidos,listaJugadores[i].FechaNacimiento,
                        listaJugadores[i].Nacionalidad);
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
                dgJugadores.AllowUserToAddRows = false;
                dgJugadores.AllowUserToDeleteRows = false;
                dgJugadores.AllowUserToResizeColumns = false;
                dgJugadores.AllowUserToResizeRows = false;

                dgJugadores.AllowDrop = false;
                dgJugadores.MultiSelect = false;
                dgJugadores.ReadOnly = true;
                dgJugadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dgJugadores.Columns[0].Visible = false;
                dgJugadores.Columns[1].Visible = true;
                dgJugadores.Columns[2].Visible = true;
                dgJugadores.Columns[3].Visible = true;
                dgJugadores.Columns[4].Visible = true;

                DataGridViewCellStyle csFilaPar = new DataGridViewCellStyle();
                DataGridViewCellStyle csFilaImpar = new DataGridViewCellStyle();

                csFilaPar.BackColor = dgJugadores.BackgroundColor;
                csFilaImpar.BackColor = dgJugadores.GridColor;

                int elemento;

                for (elemento = 0; elemento < dgJugadores.Rows.Count; elemento++)
                {
                    if (elemento % 2 == 0)
                    {
                        dgJugadores.Rows[elemento].DefaultCellStyle = csFilaPar;
                    }
                    else
                    {
                        dgJugadores.Rows[elemento].DefaultCellStyle = csFilaImpar;
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                frmInsertarJugador frmjugador = new frmInsertarJugador();
                frmjugador.MdiParent = this.MdiParent;
                frmjugador.Modo = 2;

                JugadorBE objJugador;
                objJugador = lstJugadores[dgJugadores.SelectedRows[0].Index];

                frmjugador.Jugador = objJugador;
                frmjugador.Show();
                frmjugador.BringToFront();
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

        private void frmEditarJugador_Load(object sender, EventArgs e)
        {

        }

    }
}
