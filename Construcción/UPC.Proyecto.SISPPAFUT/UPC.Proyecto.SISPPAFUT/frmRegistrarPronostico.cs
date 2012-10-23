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
    public partial class frmRegistrarPronostico : Form
    {
        private static frmRegistrarPronostico frmRegistroPronosticos = null;
        public static frmRegistrarPronostico Instance()
        {
            if (frmRegistroPronosticos == null)
            {
                frmRegistroPronosticos = new frmRegistrarPronostico();
            }
            return frmRegistroPronosticos;
        }

        private int idusuario;

        public int idUsuario
        {
            get { return idusuario; }
            set { idusuario = value; }
        }

        public frmRegistrarPronostico()
        {
            InitializeComponent();
        }

        private void frmRegistrarPronostico_Load(object sender, EventArgs e)
        {
            iniciarGrillaPartidos();
            dgvPartidosDataBind();            
        }

        private void iniciarGrillaPartidos()
        {
            try
            {
                dgvPronosticos.AllowUserToAddRows = false;
                dgvPronosticos.AllowUserToDeleteRows = false;
                dgvPronosticos.AllowUserToResizeColumns = false;
                dgvPronosticos.AllowUserToResizeRows = false;
                dgvPronosticos.AllowDrop = false;
                dgvPronosticos.MultiSelect = false;
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void dgvPartidosDataBind()
        {
            try
            {
                PartidoBC objPartidoBC;
                objPartidoBC = new PartidoBC();

                List<PartidoSinJugarBE> listaPartidos;
                listaPartidos = new List<PartidoSinJugarBE>();

                listaPartidos = objPartidoBC.lista_partidos_sinjugar();

                if (listaPartidos.Count > 0)
                {
                    dgvPronosticos.Rows.Clear();
                    for (int i = 0; i < listaPartidos.Count; i++)
                    {
                        dgvPronosticos.Rows.Add(listaPartidos[i].Codigo_partido,
                                                listaPartidos[i].Equipo_local,
                                                listaPartidos[i].Equipo_visitante, false, false, false);

                    }
                }
                else
                {
                    MessageBox.Show("No hay datos para mostrar.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                PronosticoClienteBC objPronosticoClienteBC;
                PronosticoClienteBE objPronosticoClienteBE;
                String pronostico = "";
                List<PronosticoClienteBE> listaPronosticos = new List<PronosticoClienteBE>();
                Boolean proosticado = false;
                for (int i = 0; i < dgvPronosticos.RowCount; i++)
                {
                    objPronosticoClienteBE = new PronosticoClienteBE();
                    objPronosticoClienteBE.CodigoPartido = Convert.ToInt32(dgvPronosticos.Rows[i].Cells[0].Value);
                    objPronosticoClienteBE.CodigoUsuario = idusuario;

                    if (Convert.ToBoolean(dgvPronosticos.Rows[i].Cells[3].Value) == true)
                    {
                        if (Convert.ToBoolean(dgvPronosticos.Rows[i].Cells[4].Value) == true)
                            pronostico = "LE";
                        else
                            if (Convert.ToBoolean(dgvPronosticos.Rows[i].Cells[5].Value) == true)
                                pronostico = "LV";
                            else
                                pronostico = "L";
                        proosticado = true;
                    }
                    else
                    if (Convert.ToBoolean(dgvPronosticos.Rows[i].Cells[4].Value) == true)
                    {
                        if (Convert.ToBoolean(dgvPronosticos.Rows[i].Cells[3].Value) == true)
                            pronostico = "LE";
                        else
                            if (Convert.ToBoolean(dgvPronosticos.Rows[i].Cells[5].Value) == true)
                                pronostico = "EV";
                            else
                                pronostico = "E";
                        proosticado = true;
                    }
                    if (Convert.ToBoolean(dgvPronosticos.Rows[i].Cells[5].Value) == true)
                    {
                        if (Convert.ToBoolean(dgvPronosticos.Rows[i].Cells[3].Value) == true)
                            pronostico = "LV";
                        else
                            if (Convert.ToBoolean(dgvPronosticos.Rows[i].Cells[4].Value) == true)
                                pronostico = "EV";
                            else
                                pronostico = "V";
                        proosticado = true;
                    }

                    if (proosticado == true)
                    {
                        objPronosticoClienteBE.Pronostico = pronostico;
                        listaPronosticos.Add(objPronosticoClienteBE);
                        proosticado = false;
                    }
                }

                objPronosticoClienteBC = new PronosticoClienteBC();
                if (listaPronosticos.Count > 0)
                {
                    for (int i = 0; i < listaPronosticos.Count; i++)
                    {
                        objPronosticoClienteBC.inssertarPronosticoCliente(listaPronosticos[i]);
                    }
                    MessageBox.Show("Los pronosticos han sido registrados satisfactoriamente.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void inSeleccionarTipo(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell check_l = new DataGridViewCheckBoxCell();

            if (dgvPronosticos.Columns["Local"].Index == e.ColumnIndex)
            {
                check_l = (DataGridViewCheckBoxCell)dgvPronosticos.Rows[e.RowIndex].Cells["Local"];

                if (Convert.ToBoolean(dgvPronosticos.Rows[e.RowIndex].Cells["Empate"].Value) == true &&
                    Convert.ToBoolean(dgvPronosticos.Rows[e.RowIndex].Cells["Visita"].Value) == true)
                {
                    MessageBox.Show("No es posible ese tipo de pronóstico.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvPronosticos.Rows[e.RowIndex].Cells["Local"].DataGridView.CancelEdit();
                }
            }
            else
                if (dgvPronosticos.Columns["Empate"].Index == e.ColumnIndex)
                {
                    check_l = (DataGridViewCheckBoxCell)dgvPronosticos.Rows[e.RowIndex].Cells["Empate"];

                    if (Convert.ToBoolean(dgvPronosticos.Rows[e.RowIndex].Cells["Local"].Value) == true &&
                        Convert.ToBoolean(dgvPronosticos.Rows[e.RowIndex].Cells["Visita"].Value) == true)
                    {
                        MessageBox.Show("No es posible ese tipo de pronóstico.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvPronosticos.Rows[e.RowIndex].Cells["Empate"].DataGridView.CancelEdit();
                    }
                }
                else
                    if (dgvPronosticos.Columns["Visita"].Index == e.ColumnIndex)
                    {
                        check_l = (DataGridViewCheckBoxCell)dgvPronosticos.Rows[e.RowIndex].Cells["Visita"];

                        if (Convert.ToBoolean(dgvPronosticos.Rows[e.RowIndex].Cells["Local"].Value) == true &&
                            Convert.ToBoolean(dgvPronosticos.Rows[e.RowIndex].Cells["Empate"].Value) == true)
                        {
                            MessageBox.Show("No es posible ese tipo de pronóstico.", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvPronosticos.Rows[e.RowIndex].Cells["Visita"].DataGridView.CancelEdit();
                        }
                    }
            check_l.Dispose();
        }
    }
}
