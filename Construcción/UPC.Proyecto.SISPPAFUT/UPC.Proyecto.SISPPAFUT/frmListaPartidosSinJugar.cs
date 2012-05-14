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
    public partial class frmListaPartidosSinJugar : Form
    {
        private static frmListaPartidosSinJugar frmListarPartidos = null;
        public static frmListaPartidosSinJugar Instance()
        {
            if (frmListarPartidos == null)
            {
                frmListarPartidos = new frmListaPartidosSinJugar();
            }
            return frmListarPartidos;
        }

        public frmListaPartidosSinJugar()
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

        }

        private void btn_editar_datos_partido_Click(object sender, EventArgs e)
        {
            try
            {
                frmEditarDatosPartido frm = frmEditarDatosPartido.Instance();
                frm.MdiParent = this.MdiParent;
                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                //Funciones.RegistrarExcepcion(ex);
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
    }
}
