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
    public partial class frmEditarJugadores : Form
    {
        //--Variables globales
        List<JugadorBE> listaJugadores;

        private static frmEditarJugadores frmJugadores = null;
        public static frmEditarJugadores Instance()
        {
            if (frmJugadores == null)
            {
                frmJugadores = new frmEditarJugadores();
            }
            
            return frmJugadores;
        }
        
        public frmEditarJugadores()
        {
            InitializeComponent();
            iniciarGrilla();
            iniciarJugadores();            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iniciarJugadores()
        {
            try
            {
                dgJugadores.Rows.Clear();

                JugadorBC objJugadorBC = new JugadorBC();
                listaJugadores = new List<JugadorBE>();

                listaJugadores=objJugadorBC.listar_Jugadores();
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

    }
}
