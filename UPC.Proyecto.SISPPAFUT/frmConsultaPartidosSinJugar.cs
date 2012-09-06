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
    public partial class frmConsultaPartidosSinJugar : Form
    {
        private static frmConsultaPartidosSinJugar frmListarPartidos = null;
        public static frmConsultaPartidosSinJugar Instance()
        {
            if (frmListarPartidos == null)
            {
                frmListarPartidos = new frmConsultaPartidosSinJugar();
            }
            return frmListarPartidos;
        }

        public frmConsultaPartidosSinJugar()
        {
            InitializeComponent();
        }

        private void frmListaPartidosSinJugar_Load(object sender, EventArgs e)
        {
            try
            {
                dgvPatidosDataBind();
                dgvPartidosConfigurar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_editar_partido_Click(object sender, EventArgs e)
        {
            try
            {
                frmInsertarPartido frm = frmInsertarPartido.Instance();
                frm.MdiParent = this.MdiParent;
                PartidoSinJugarBE objPartido = new PartidoSinJugarBE();

                objPartido.Codigo_partido = Convert.ToInt32(dgv_lista_partidos.Rows[dgv_lista_partidos.CurrentRow.Index].Cells["cod_partido"].Value);
                objPartido.Pais = dgv_lista_partidos.Rows[dgv_lista_partidos.CurrentRow.Index].Cells["partido_pais"].Value.ToString();
                objPartido.Liga = dgv_lista_partidos.Rows[dgv_lista_partidos.CurrentRow.Index].Cells["partido_liga"].Value.ToString();
                objPartido.Equipo_local = dgv_lista_partidos.Rows[dgv_lista_partidos.CurrentRow.Index].Cells["partido_local"].Value.ToString();
                objPartido.Equipo_visitante = dgv_lista_partidos.Rows[dgv_lista_partidos.CurrentRow.Index].Cells["partido_visita"].Value.ToString();
                objPartido.Fecha = Convert.ToDateTime(dgv_lista_partidos.Rows[dgv_lista_partidos.CurrentRow.Index].Cells["partido_fecha"].Value);

                frm.Partido = objPartido;
                frm.Modo = 2;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void btn_editar_datos_partido_Click(object sender, EventArgs e)
        {
            try
            {
                frmEditarDatosPartido frm = frmEditarDatosPartido.Instance();
                frm.MdiParent = this.MdiParent;
                
                frm.Codigo_partido = Convert.ToInt32(dgv_lista_partidos.Rows[dgv_lista_partidos.CurrentRow.Index].Cells["cod_partido"].Value);
                frm.Equipo_local = dgv_lista_partidos.Rows[dgv_lista_partidos.CurrentRow.Index].Cells["partido_local"].Value.ToString();
                frm.Equipo_visita = dgv_lista_partidos.Rows[dgv_lista_partidos.CurrentRow.Index].Cells["partido_visita"].Value.ToString();
                
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Funciones.RegistrarExcepcion(ex);
            }
        }

        private void dgvPatidosDataBind()
        {
            PartidoBC objPartidoBC;
            objPartidoBC = new PartidoBC();

            dgv_lista_partidos.DataSource = objPartidoBC.lista_partidos_sinjugar();
        }

        private void dgvPartidosConfigurar()
        {
            dgv_lista_partidos.AllowUserToAddRows = false;
            dgv_lista_partidos.AllowUserToDeleteRows = false;

            dgv_lista_partidos.AllowUserToResizeColumns = false;
            dgv_lista_partidos.AllowUserToResizeRows = false;
            dgv_lista_partidos.AllowDrop = false;

            dgv_lista_partidos.MultiSelect = false;
            dgv_lista_partidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv_lista_partidos.ReadOnly = true;
        }

        private void inCerrar(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Sistema Inteligente para Pronóstico de Partidos de Fútbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
        }
    }
}
